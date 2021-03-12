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
    public partial class Form1 : Form
    {

        public int skipWarning { get; set; }
        public int _id { get; set; }
        public int _quoteNumber { get; set; }
        public int validation { get; set; }
        public int dataPopulated { get; set; }
        public int valueCalulated { get; set; }
        public Form1(int id, int quoteNumber, int loadData)
        {
            InitializeComponent();
            _id = id;
            _quoteNumber = quoteNumber;

            if (loadData == -1)
                populateData();
        }

        private void populateData()
        {
            //theres already information about entry so we're gonna load it
            string sql = "SELECT * FROM dbo.[slimline_install_door] WHERE quote_id = " + _quoteNumber + " AND id = " + _id;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //go through each of the columns
                    foreach (DataRow row in dt.Rows)
                    {
                        txtDoorReference.Text = row["door_reference"].ToString();
                        txtWidth.Text = row["structural_opening_width"].ToString();
                        txtHeight.Text = row["structural_opening_height"].ToString();
                        txtTravelMiles.Text = row["mileage_one_way"].ToString();
                        cmbInstallLocation.Text = row["install_location"].ToString();
                        txtDiscount.Text = row["discount_percent"].ToString();
                        txtExtraCost.Text = Math.Round(Convert.ToDouble(row["extra_cost"].ToString()), 2).ToString();
                        txtNote.Text = (row["extra_cost_note"].ToString());
                        txtQty.Text = (row["quantity_same"].ToString());
                        // txtSalesValue.Text = row["total_value"].ToString();    //clicking the button will be nicer imo

                        var temp = row["london"].ToString();
                        if (temp == "1")
                            chkLondon.Checked = true;
                        temp = row["heavy_large_glass"].ToString();
                        if (temp == "1")
                            chkHeavyGlass.Checked = true;
                        temp = row["shaped_glass"].ToString();
                        if (temp == "1")
                            chkShapedGlass.Checked = true;
                        temp = row["removal_required"].ToString();
                        if (temp == "1")
                            chkRemoval.Checked = true;
                        temp = row["disposal_required"].ToString();
                        if (temp == "1")
                            chkDisposal.Checked = true;
                        temp = row["mastic_required"].ToString();
                        if (temp == "1")
                            chkMastic.Checked = true;

                        validation = -1;
                        dataPopulated = -1;

                    }

                    conn.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWidth.Text) || string.IsNullOrWhiteSpace(txtHeight.Text) && skipWarning == -1)
            {
                valueCalulated = 0;
                skipWarning = 0;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtWidth.Text) || string.IsNullOrWhiteSpace(txtHeight.Text))
            {
                MessageBox.Show("Please ensure you have entered the structural sizes and the travel distance", "Missing information", MessageBoxButtons.OK);
                btnSave.Enabled = false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtExtraCost.Text))
                    txtExtraCost.Text = "0";

                int sqmCost = 250;
                double travelCostPerMile = 1;
                double masticCostPerSqm = 13;

                double sqmValue = Convert.ToDouble(sqmCost * ((Convert.ToDouble(txtHeight.Text) * Convert.ToDouble(txtWidth.Text))) / 1000000);
                double travelValue;
                double masticValue;

                double awkwardGlassPercent = 0.15;
                double shapedGlassPercent = 0.1;
                double removalPercent = 0.05;
                double disposalPercent = 0.1;
                double londonPercent = 0.25;
                double nonGroundFloorLocationPercent = 0.05;

                double overallAdditionalPercent = 1;

                double discountPercent = 1;

                if (string.IsNullOrWhiteSpace(txtTravelMiles.Text))
                {
                    travelValue = 0;
                }
                else
                {
                    travelValue = (travelCostPerMile * Convert.ToInt32(txtTravelMiles.Text) * 2);
                }

                if (chkMastic.Checked == true)
                {
                    masticValue = masticCostPerSqm * ((Convert.ToInt32(txtHeight.Text) + Convert.ToInt32(txtHeight.Text) + Convert.ToInt32(txtWidth.Text))) / 1000;
                }
                else
                {
                    masticValue = 0;
                }

                if (chkHeavyGlass.Checked == true)
                {
                    overallAdditionalPercent = overallAdditionalPercent + awkwardGlassPercent;
                }

                if (chkShapedGlass.Checked == true)
                {
                    overallAdditionalPercent = overallAdditionalPercent + shapedGlassPercent;
                }

                if (chkRemoval.Checked == true)
                {
                    overallAdditionalPercent = overallAdditionalPercent + removalPercent;
                }

                if (chkDisposal.Checked == true)
                {
                    overallAdditionalPercent = overallAdditionalPercent + disposalPercent;
                }

                if (chkLondon.Checked == true)
                {
                    overallAdditionalPercent = overallAdditionalPercent + londonPercent;
                }


                if (cmbInstallLocation.Text != "Ground Floor")
                {
                    overallAdditionalPercent = overallAdditionalPercent + nonGroundFloorLocationPercent;
                }

                if (string.IsNullOrWhiteSpace(txtDiscount.Text))
                {
                    discountPercent = 1;
                }
                else
                {
                    discountPercent = 1 - (Convert.ToDouble(txtDiscount.Text)) / 100;
                }


                txtSalesValue.Text = ((((sqmValue + travelValue + masticValue + Convert.ToDouble(txtExtraCost.Text)) * overallAdditionalPercent)) * discountPercent).ToString();
                btnSave.Enabled = true;
                if (valueCalulated == 2)
                {//does nothing
                }
                else
                    valueCalulated = -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (string.IsNullOrWhiteSpace(txtDiscount.Text))
                txtDiscount.Text = "0";
            if (string.IsNullOrWhiteSpace(txtExtraCost.Text))
                txtExtraCost.Text = "0";
            if (string.IsNullOrWhiteSpace(txtNote.Text))
                txtNote.Text = " ";
            if (string.IsNullOrWhiteSpace(txtQty.Text))
                txtQty.Text = "1";
            btnGenerate.PerformClick();
            if (string.IsNullOrWhiteSpace(txtDoorReference.Text))
            {
                sql = "UPDATE dbo.[slimline_install_door] SET  structural_opening_width = " + txtWidth.Text + ",  structural_opening_height = " + txtHeight.Text + ", " +
                                    "london = " + Convert.ToInt32(chkLondon.Checked).ToString() + ", install_location = '" + cmbInstallLocation.Text + "' , heavy_large_glass = " + Convert.ToInt32(chkHeavyGlass.Checked).ToString() + ", " +
                                    "shaped_glass = " + Convert.ToInt32(chkShapedGlass.Checked).ToString() + " , removal_required = " + Convert.ToInt32(chkRemoval.Checked).ToString() + " , disposal_required = " + Convert.ToInt32(chkDisposal.Checked).ToString() + " , " +
                                    "mastic_required = " + Convert.ToInt32(chkMastic.Checked).ToString() + " , discount_percent = " + txtDiscount.Text + " , total_value = " + txtSalesValue.Text + ", " +
                                    "extra_cost = " + txtExtraCost.Text + ", extra_cost_note = '" + txtNote.Text + "',quantity_same = " + txtQty.Text + " WHERE quote_id = " + _quoteNumber + " AND id =" + _id;
            }
            else
            {
                sql = "UPDATE dbo.[slimline_install_door] SET door_reference = '" + txtDoorReference.Text + "', structural_opening_width = " + txtWidth.Text + ",  structural_opening_height = " + txtHeight.Text + ", " +
                    "london = " + Convert.ToInt32(chkLondon.Checked).ToString() + ", install_location = '" + cmbInstallLocation.Text + "' , heavy_large_glass = " + Convert.ToInt32(chkHeavyGlass.Checked).ToString() + ", " +
                    "shaped_glass = " + Convert.ToInt32(chkShapedGlass.Checked).ToString() + " , removal_required = " + Convert.ToInt32(chkRemoval.Checked).ToString() + " , disposal_required = " + Convert.ToInt32(chkDisposal.Checked).ToString() + " , " +
                    "mastic_required = " + Convert.ToInt32(chkMastic.Checked).ToString() + " , discount_percent = " + txtDiscount.Text + " , total_value = " + txtSalesValue.Text + "," +
                    "extra_cost = " + txtExtraCost.Text + ", extra_cost_note = '" + txtNote.Text + "' ,quantity_same = " + txtQty.Text + " WHERE quote_id = " + _quoteNumber + " AND id =" + _id;
            }
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    validation = -1;
                    this.Close();
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (validation == -1) //this can only be executed here (performclick() doesnt work until the form has loaded)
            {
                btnGenerate.PerformClick();

                validation = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (valueCalulated == -1) // if the calulate button was pressed we can assume that it was intended to save this information
            {
                valueCalulated = 2;
                btnSave.PerformClick();
            }
            if (dataPopulated != -1)
            {
                if (validation != -1) // if validation = -1 then its been commited (if its 0 then the user closed this form so we need to delete the entry that was inserted on load
                {
                    string sql = "DELETE FROM dbo.[slimline_install_door] WHERE  id = " + _id;
                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            validation = -1;
                        }
                    }
                }
            }

        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalesValue_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDoorReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("'")) e.Handled = true;
        }

        private void txtDoorReference_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            skipWarning = -1;
            btnGenerate.PerformClick();
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            skipWarning = -1;
            btnGenerate.PerformClick();
        }

        private void txtTravelMiles_TextChanged(object sender, EventArgs e)
        {
            skipWarning = -1;
            btnGenerate.PerformClick();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            skipWarning = -1;
            btnGenerate.PerformClick();
        }

        private void txtExtraCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkHeavyGlass_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        private void chkShapedGlass_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        private void chkRemoval_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        private void chkDisposal_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        private void chkMastic_CheckedChanged(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        private void txtExtraCost_TextChanged(object sender, EventArgs e)
        {
            btnGenerate.PerformClick();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
