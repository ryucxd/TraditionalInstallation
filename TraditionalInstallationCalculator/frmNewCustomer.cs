﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlimlineInstallationCalculator
{
    public partial class frmNewCustomer : Form
    {
        public frmNewCustomer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            newCustomer nc = new newCustomer(txtAccRef.Text, txtName.Text, txtAdd1.Text, txtAdd2.Text, txtAdd3.Text, txtAdd4.Text, txtAdd5.Text, txtTel1.Text, txtTel2.Text, txtFax.Text);

            if (nc.validateAccRef() == false)
            {
                nc.addCustomer();
                this.Close();
            }
            else
            {
                MessageBox.Show("A customer in the Sales Ledger already uses this account reference. Please choose another to continue.", "Choose a different sales ledger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Login._customerAdded = 0;
            }

        }
    }
}
