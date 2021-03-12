using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TraditionalInstallationCalculator
{
    class Login
    {
        public static int _userID;
        public static string _fullName;
        public static int _customerAdded;
        public static string _accRef;
        public string username { get; set; }
        public string password { get; set; }

        public Login(string _username, string _password)
        {
            username = _username;
            password = _password;
        }


        public bool loginAttempt()
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                string sql = "SELECT id FROM dbo.[user] WHERE username = '" + username + "' AND password = '" + password + "'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var temp = Convert.ToString(cmd.ExecuteScalar());
                    if (temp != "")
                        _userID = Convert.ToInt32(temp);
                    else
                        _userID = 0;

                    if (_userID > 0)
                    {
                        sql = "SELECT forename + ' ' + surname from dbo.[user] WHERE id = " + _userID;
                        using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                            _fullName = Convert.ToString(cmd2.ExecuteScalar());
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }


                }
            }
        }
    }
}
