using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TraditionalInstallationCalculator
{
    class calculations
    {
        public int _width { get; set; }
        public int _height { get; set; }
        public string _installLocation { get; set; }
        public int _HLGlass { get; set; }
        public int _shapedGlass { get; set; }
        public int _removal { get; set; }
        public int _disposal { get; set; }
        public int _mastic { get; set; }
        public double _discount { get; set; }
        public double _totalValue { get; set; }
        public double _mileageTotal{ get; set; }
        public double _extraCost { get; set; }

        public void getValue(int itemID)
        {
            //first step is to get the values used in the calculation
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT COALESCE(structural_opening_height,0),COALESCE(structural_opening_width,0),COALESCE(install_location,'Ground floor'), " +
                             "heavy_large_glass,shaped_glass,removal_required,disposal_required,mastic_required,COALESCE(discount_percent,0),COALESCE(extra_cost,0) FROM dbo.slimline_install_door   WHERE id = " + itemID;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    _height = Convert.ToInt32(dt.Rows[0][0].ToString());
                    _width = Convert.ToInt32(dt.Rows[0][1].ToString());
                    _installLocation = Convert.ToString(dt.Rows[0][2].ToString());
                    _HLGlass = Convert.ToInt32(dt.Rows[0][3].ToString());
                    _shapedGlass = Convert.ToInt32(dt.Rows[0][4].ToString());
                    _removal = Convert.ToInt32(dt.Rows[0][5].ToString());
                    _disposal = Convert.ToInt32(dt.Rows[0][6].ToString());
                    _mastic = Convert.ToInt32(dt.Rows[0][7].ToString());
                    _discount = Convert.ToDouble(dt.Rows[0][8].ToString());
                    _extraCost = Convert.ToDouble(dt.Rows[0][9].ToString());
                }
                conn.Close();
            }

            int sqmCost = 250;
            double travelCostPerMile = 1;
            double masticCostPerSqm = 13;

            double sqmValue = Convert.ToDouble(sqmCost * ((Convert.ToDouble(_height) * Convert.ToDouble(_width))) / 1000000);
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


                travelValue = 0; //leaving this as 0 because we dont want to work this out rn


            if (_mastic == 1)
            {
                masticValue = masticCostPerSqm * ((Convert.ToInt32(_height) + Convert.ToInt32(_height) + Convert.ToInt32(_width))) / 1000;
            }
            else
            {
                masticValue = 0;
            }

            if (_HLGlass == 1)
            {
                overallAdditionalPercent = overallAdditionalPercent + awkwardGlassPercent;
            }

            if (_shapedGlass == 1)
            {
                overallAdditionalPercent = overallAdditionalPercent + shapedGlassPercent;
            }

            if (_removal == 1)
            {
                overallAdditionalPercent = overallAdditionalPercent + removalPercent;
            }

            if (_disposal == 1)
            {
                overallAdditionalPercent = overallAdditionalPercent + disposalPercent;
            }

            //if (chkLondon.Checked == true)
            //{
            //    overallAdditionalPercent = overallAdditionalPercent + londonPercent;   -- london is going to be done at project level
            //}


            if (_installLocation != "Ground Floor")
            {
                overallAdditionalPercent = overallAdditionalPercent + nonGroundFloorLocationPercent;
            }

            if (_discount == 0)
            {
                discountPercent = 1;
            }
            else
            {
                discountPercent = 1 - (Convert.ToDouble(_discount)) / 100;
            }
            _totalValue = ((((sqmValue + travelValue + masticValue + _extraCost) * overallAdditionalPercent)) * discountPercent);
        }

        public void mileage(/*int itemID,*/int quote_id)
        {
            double travelCostPerMile = 1;
            double overallAdditionalPercent = 1;
            double londonPercent = 0.25;
            double _total_miles = 0;
            double travelValue = 0 ;
            int _london = 0;

            //first step is to get the values used in the calculation
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                string sql = "SELECT COALESCE(total_mileage,0),london FROM dbo.slimline_install_quote   WHERE id = " + quote_id;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    _total_miles = Convert.ToInt32(dt.Rows[0][0].ToString());
                    _london = Convert.ToInt32(dt.Rows[0][1].ToString());
                }
                conn.Close();
            }
            if (_london == 1)
            {
                overallAdditionalPercent = overallAdditionalPercent + londonPercent;
            }
            travelValue = (travelCostPerMile * _total_miles);
            _mileageTotal = travelValue * overallAdditionalPercent;
        }
    }
}
