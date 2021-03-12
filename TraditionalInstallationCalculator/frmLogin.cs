using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraditionalInstallationCalculator
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login loginClass = new Login(txtUsername.Text,txtPassword.Text);
            loginClass.loginAttempt();
            
            if (Login._userID > 0)
            {
                //login successful
                frmMain frm = new frmMain();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username/Password is inocorrect", "Error: 401", MessageBoxButtons.OK);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
            
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Login._userID == 0)
                Application.Exit();

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
