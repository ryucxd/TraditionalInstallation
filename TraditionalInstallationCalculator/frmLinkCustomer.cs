using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SlimlineInstallationCalculator
{
    public partial class frmLinkCustomer : Form
    {
        public int  _id { get; set; }
        public frmLinkCustomer(int id)
        {
            InitializeComponent();
            _id = id;
            loadData();
        }


        private void loadData()
        {
            string sql = "SELECT NAME from [dsl_fitting].[dbo].[SALES_LEDGER]";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                        cmbCustomer.Items.Add(row["NAME"].ToString());
                }
                //WHILE WE are here we also need to check if there is already a account ref linked AND project ref linked to this ID - if there is then we need to populate 
                sql = "SELECT a.projectReference,b.NAME from dbo.slimline_install_quote a LEFT JOIN [dsl_fitting].[dbo].[SALES_LEDGER] b ON a.custAccRef = b.ACCOUNT_REF WHERE a.id = " + _id;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //check each entry 
                    string tempData = "";
                    tempData = dt.Rows[0][0].ToString();
                    if (tempData != "")
                        txtProjectReference.Text = tempData;
                    tempData = dt.Rows[0][1].ToString();
                    if (tempData != "")
                        cmbCustomer.Text = tempData;

                }

                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            //get ACC REF and link it up
            string accRef = "";
            string sql = "SELECT ACCOUNT_REF FROM [dsl_fitting].[dbo].[SALES_LEDGER] WHERE [NAME] LIKE '%" + cmbCustomer.Text + "%'";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                if (cmbCustomer.Text != "")
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        accRef = Convert.ToString(cmd.ExecuteScalar());
                    }
                    sql = "UPDATE dbo.slimline_install_quote SET custAccRef = '" + accRef + "' WHERE id =  " + _id.ToString(); //if cmb was left blank it would autopick the very first entry
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                if (txtProjectReference.Text != "")
                {
                    sql = "UPDATE dbo.slimline_install_quote SET projectReference = '" + txtProjectReference.Text + "' WHERE id =  " + _id.ToString(); 
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
                this.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProjectReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("'")) e.Handled = true;
        }

        private void lblNewCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //add a new customer
            frmNewCustomer frm = new frmNewCustomer();
            frm.ShowDialog();

            if (Login._customerAdded == -1)
            {
                //preselect the customer
                loadData();
                string sql = "SELECT TOP 1 [NAME] FROM [dsl_fitting].[dbo].[SALES_LEDGER] WHERE ACCOUNT_REF = '" + Login._accRef + "'";
                using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        string temp = Convert.ToString(cmd.ExecuteScalar());
                        if (temp != null)
                            cmbCustomer.Text = temp;
                        conn.Close();
                    }
                }
            }

            //set customer back to 0
            Login._customerAdded = 0;
        }

        private void frmLinkCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
