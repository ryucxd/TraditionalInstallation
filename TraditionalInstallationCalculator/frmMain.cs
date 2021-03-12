using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SlimlineInstallationCalculator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            loadDGV();
        }

        private void loadDGV()
        {
            dgvMain.DataSource = null;
            string sql = "SELECT a.id as ID,'£' + CAST(COALESCE(a.sumTotal,0) as nvarchar(max)) as [Total Value],a.projectReference as [Project Reference],b.[NAME] as [Customer] from dbo.slimline_install_quote a LEFT JOIN [dsl_fitting].[dbo].[SALES_LEDGER] b ON a.custAccRef = b.ACCOUNT_REF " +
                "WHERE COALESCE(b.[NAME],'') LIKE '%" + txtCustomer.Text + "%' AND a.id LIKE '%" + txtID.Text + "%' AND COALESCE(a.projectReference,'') LIKE '%" + txtProjectReference.Text + "%' ORDER BY id desc"; //this maybe needs a link or something because rn its two rows :<
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMain.DataSource = dt;
                }
                conn.Close();
            }
            format();
        }

        private void format()
        {
            dgvMain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMain.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            //frmNewQuote frm = new frmNewQuote();
            //frm.ShowDialog();
            //loadDGV();            
            DialogResult result = MessageBox.Show("Are you sure you want to add a new quote?", "New Quote", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string sql = "INSERT INTO dbo.slimline_install_quote  (custAccRef) VALUES(' ')";
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        loadDGV();
                        //here we emulate clicking the new quote 
                        int quoteNumber = 0;
                        quoteNumber = Convert.ToInt32(dgvMain.Rows[0].Cells[0].Value.ToString());
                        frmManageQuote frm = new frmManageQuote(quoteNumber, -1);
                        this.Hide();
                        frm.ShowDialog();
                        this.Show();
                        loadDGV();
                    }
                    conn.Close();
                }
            }

        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmManageQuote frm = new frmManageQuote(Convert.ToInt32(dgvMain.Rows[e.RowIndex].Cells[0].Value), 0);
            this.Hide();
            frm.ShowDialog();
            loadDGV();
            this.Show();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void txtProjectReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            loadDGV();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string csv;
            string filepath;
            string textLine = string.Empty;
            string[] splitLine;

            OpenFileDialog openFileName = new OpenFileDialog();
            openFileName.FilterIndex = 1;
            openFileName.RestoreDirectory = true;

            if (openFileName.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filepath = openFileName.FileName;
                    csv = openFileName.FileName;

                }
                catch
                {
                    MessageBox.Show("Error loading file, please check the filetype is correct.");
                    csv = "Error!";
                    return;
                }
                var data = new DataTable();
                data.Columns.AddRange(new[]
                {
                new DataColumn ("doorReference"),
                new DataColumn ("width"),
                new DataColumn ("height"),
                new DataColumn ("mastic"),
            });

                data.Rows.Clear();

                if (System.IO.File.Exists(filepath))
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(filepath, new UTF8Encoding(true));
                    var contents = reader.ReadToEnd();
                    var strReader = new System.IO.StringReader(contents);
                    strReader.ReadLine();

                    do
                    {
                        textLine = strReader.ReadLine();
                        if (textLine != string.Empty)
                        {
                            splitLine = textLine.Split(';');
                            if (splitLine[0] != string.Empty || splitLine[1] != string.Empty)
                            {
                                data.Rows.Add(splitLine);
                            }
                        }

                      
                    } while (strReader.Peek() != -1);

                    ///////////////////////////////
                    //dgvMain.DataSource = null;
                    //dgvMain.DataSource = data;            //this code that is commented out is only used to view the csv (bug checking)
                    //return;
                    ///////////////////////////////
                    

                    //datatable is ready
                    if (data.Rows.Count > 0)
                        insertData(data);
                    else
                        MessageBox.Show("No data found, action aborted.", "ERROR!", MessageBoxButtons.OK);
                }
            }
        }

        private void insertData(DataTable dt)
        {
            //first up we need to insert a new quote
            int quote_id = 0;
            string sql = "INSERT INTO dbo.slimline_install_quote  (custAccRef) VALUES(' ')";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                //grab max id rq
                sql = "SELECT MAX(ID) from dbo.slimline_install_quote";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    quote_id = Convert.ToInt32(cmd.ExecuteScalar());

                //now we go through the datatable and insert the items it has 
                foreach(DataRow row in dt.Rows)  //    doorReference  - width - height - mastic
                {
                    int mastic = 0;
                    if (row["mastic"].ToString() == "yes")
                        mastic = -1;
                    else
                        mastic = 0;
                    sql = "INSERT INTO dbo.slimline_install_door (door_reference,structural_opening_width,structural_opening_height,mastic_required,quote_id) VALUES(" +
                        "'" + row["doorReference"].ToString() + "'," + row["width"].ToString() + "," + row["height"].ToString() + "," + mastic.ToString() + "," + quote_id.ToString() + " ) "; ;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }
                    conn.Close();
                frmManageQuote frm = new frmManageQuote(quote_id, -2);
                this.Hide();
                frm.ShowDialog();
                this.Show();
                loadDGV();
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Text = "Main Menu - " + Login._fullName + " - Logged in: " + DateTime.Now.ToString();
        }
    }
}
