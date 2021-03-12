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
    public partial class frmFreeHandNote : Form
    {
        public int quote_number { get; set; }
        public int allowClose { get; set; }
        public int textChanged { get; set; }
        public frmFreeHandNote(int qnum)
        {
            InitializeComponent();
            quote_number = qnum;

            //grab the text if its already there
            string sql = "SELECT free_hand_note FROM dbo.slimline_install_quote WHERE id = " + qnum;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string text = "";
                    var getData = Convert.ToString(cmd.ExecuteScalar());
                    if (getData != null)
                        text = getData;
                    txtNote.Text = text;
                }
                conn.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (textChanged == -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit? Any changes will be lost!", "Warning!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    allowClose = -1;
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void frmFreeHandNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textChanged == -1)
            {
                if (allowClose != -1)
                {
                    btnClose.PerformClick();
                    if (allowClose != -1) //if its still 'no' then dont close
                        e.Cancel = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE dbo.slimline_install_quote SET free_hand_note = '" + txtNote.Text + "' WHERE id = " + quote_number.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    allowClose = -1;
                    this.Close();
                }
            }
        }

        private void txtNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("'")) e.Handled = true; //dont allow ' to save it breaking the sql string
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            textChanged = -1;
        }
    }
}
