using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TraditionalInstallationCalculator
{
    class newCustomer
    {

        public int customerAdded { get; set; }
        public string _accRef { get; set; }
        public string _custName { get; set; }
        public string _add1 { get; set; }
        public string _add2 { get; set; }
        public string _add3 { get; set; }
        public string _add4 { get; set; }
        public string _add5 { get; set; }
        public string _tel1 { get; set; }
        public string _tel2 { get; set; }
        public string _fax { get; set; }

        public newCustomer(string accRef, string custName, string add1, string add2, string add3, string add4, string add5, string tel1, string tel2, string fax)
        {
            _accRef = accRef;
            _custName = custName;
            _add1 = add1;
            _add2 = add2;
            _add3 = add3;
            _add4 = add4;
            _add5 = add5;
            _tel1 = tel1;
            _tel2 = tel2;
            _fax = fax;
        }

        public void addCustomer()
        {
            SqlConnection conn = new SqlConnection(CONNECT.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO [dsl_fitting].[dbo].[SALES_LEDGER] (account_ref, name, address_1, address_2, address_3, address_4, address_5, telephone, telephone_2, fax) " +
                              "VALUES(@accRef,@custName,@add1,@add2,@add3,@add4,@add5,@tel1,@tel2,@fax);";

            cmd.Parameters.AddWithValue("@accRef", _accRef);
            cmd.Parameters.AddWithValue("@custName", _custName);
            cmd.Parameters.AddWithValue("@add1", _add1);
            cmd.Parameters.AddWithValue("@add2", _add2);
            cmd.Parameters.AddWithValue("@add3", _add3);
            cmd.Parameters.AddWithValue("@add4", _add4);
            cmd.Parameters.AddWithValue("@add5", _add5);
            cmd.Parameters.AddWithValue("@tel1", _tel1);
            cmd.Parameters.AddWithValue("@tel2", _tel2);
            cmd.Parameters.AddWithValue("@fax", _fax);

            cmd.ExecuteNonQuery();
            Login._customerAdded = -1;
            Login._accRef = _accRef;
            conn.Close();
        }

        public bool validateAccRef()
        {
            SqlConnection conn = new SqlConnection(CONNECT.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = "SELECT [ACCOUNT_REF] from [dsl_fitting].[dbo].[SALES_LEDGER] where [ACCOUNT_REF] =@accRef;";
            cmd.Parameters.AddWithValue("@accRef", _accRef);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
