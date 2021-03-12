namespace SlimlineInstallationCalculator
{
    partial class frmLinkCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectReference = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNewCustomer = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(12, 55);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(383, 21);
            this.cmbCustomer.TabIndex = 0;
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(196, 123);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(97, 23);
            this.btnLink.TabIndex = 3;
            this.btnLink.Text = "Link Customer";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtProjectReference
            // 
            this.txtProjectReference.Location = new System.Drawing.Point(93, 97);
            this.txtProjectReference.Name = "txtProjectReference";
            this.txtProjectReference.Size = new System.Drawing.Size(219, 20);
            this.txtProjectReference.TabIndex = 1;
            this.txtProjectReference.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProjectReference_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(93, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Project Reference:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblNewCustomer
            // 
            this.lblNewCustomer.AutoSize = true;
            this.lblNewCustomer.LinkColor = System.Drawing.Color.Teal;
            this.lblNewCustomer.Location = new System.Drawing.Point(155, 15);
            this.lblNewCustomer.Name = "lblNewCustomer";
            this.lblNewCustomer.Size = new System.Drawing.Size(98, 13);
            this.lblNewCustomer.TabIndex = 26;
            this.lblNewCustomer.TabStop = true;
            this.lblNewCustomer.Text = "Add New Customer";
            this.lblNewCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewCustomer_LinkClicked);
            // 
            // frmLinkCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 158);
            this.ControlBox = false;
            this.Controls.Add(this.lblNewCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjectReference);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.cmbCustomer);
            this.Name = "frmLinkCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Link";
            this.Load += new System.EventHandler(this.frmLinkCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectReference;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblNewCustomer;
    }
}