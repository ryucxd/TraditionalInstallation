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

namespace TraditionalInstallationCalculator
{
    public partial class frmChkUpdate : Form
    {
        public int quoteNumber { get; set; }
        public frmChkUpdate(int qnum)
        {
            InitializeComponent();
            quoteNumber = qnum;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update **ALL** items with this data?", "Update", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            string sql = "UPDATE dbo.[slimline_install_door] SET install_location = '" + cmbInstallLocation.Text + "' , heavy_large_glass = " + Convert.ToInt32(chkHeavyGlass.Checked).ToString() + ", " +
                                "shaped_glass = " + Convert.ToInt32(chkShapedGlass.Checked).ToString() + " , removal_required = " + Convert.ToInt32(chkRemoval.Checked).ToString() + " , disposal_required = " + Convert.ToInt32(chkDisposal.Checked).ToString() + " , " +
                                "mastic_required = " + Convert.ToInt32(chkMastic.Checked).ToString() + "   WHERE quote_id = " + quoteNumber.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            this.Close();
            
        }
    }
}
