namespace TraditionalInstallationCalculator
{
    partial class frmChkUpdate
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmbInstallLocation = new System.Windows.Forms.ComboBox();
            this.chkMastic = new System.Windows.Forms.CheckBox();
            this.chkDisposal = new System.Windows.Forms.CheckBox();
            this.chkRemoval = new System.Windows.Forms.CheckBox();
            this.chkShapedGlass = new System.Windows.Forms.CheckBox();
            this.chkHeavyGlass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Install Location:";
            // 
            // cmbInstallLocation
            // 
            this.cmbInstallLocation.FormattingEnabled = true;
            this.cmbInstallLocation.Items.AddRange(new object[] {
            "Ground Floor",
            "Basement",
            "Upper Floors"});
            this.cmbInstallLocation.Location = new System.Drawing.Point(99, 29);
            this.cmbInstallLocation.Name = "cmbInstallLocation";
            this.cmbInstallLocation.Size = new System.Drawing.Size(113, 21);
            this.cmbInstallLocation.TabIndex = 20;
            this.cmbInstallLocation.Text = "Ground Floor";
            // 
            // chkMastic
            // 
            this.chkMastic.AutoSize = true;
            this.chkMastic.Location = new System.Drawing.Point(12, 159);
            this.chkMastic.Name = "chkMastic";
            this.chkMastic.Size = new System.Drawing.Size(103, 17);
            this.chkMastic.TabIndex = 25;
            this.chkMastic.Text = "Mastic Required";
            this.chkMastic.UseVisualStyleBackColor = true;
            // 
            // chkDisposal
            // 
            this.chkDisposal.AutoSize = true;
            this.chkDisposal.Location = new System.Drawing.Point(12, 136);
            this.chkDisposal.Name = "chkDisposal";
            this.chkDisposal.Size = new System.Drawing.Size(112, 17);
            this.chkDisposal.TabIndex = 24;
            this.chkDisposal.Text = "Disposal Required";
            this.chkDisposal.UseVisualStyleBackColor = true;
            // 
            // chkRemoval
            // 
            this.chkRemoval.AutoSize = true;
            this.chkRemoval.Location = new System.Drawing.Point(12, 113);
            this.chkRemoval.Name = "chkRemoval";
            this.chkRemoval.Size = new System.Drawing.Size(114, 17);
            this.chkRemoval.TabIndex = 23;
            this.chkRemoval.Text = "Removal Required";
            this.chkRemoval.UseVisualStyleBackColor = true;
            // 
            // chkShapedGlass
            // 
            this.chkShapedGlass.AutoSize = true;
            this.chkShapedGlass.Location = new System.Drawing.Point(12, 90);
            this.chkShapedGlass.Name = "chkShapedGlass";
            this.chkShapedGlass.Size = new System.Drawing.Size(92, 17);
            this.chkShapedGlass.TabIndex = 22;
            this.chkShapedGlass.Text = "Shaped Glass";
            this.chkShapedGlass.UseVisualStyleBackColor = true;
            // 
            // chkHeavyGlass
            // 
            this.chkHeavyGlass.AutoSize = true;
            this.chkHeavyGlass.Location = new System.Drawing.Point(12, 67);
            this.chkHeavyGlass.Name = "chkHeavyGlass";
            this.chkHeavyGlass.Size = new System.Drawing.Size(118, 17);
            this.chkHeavyGlass.TabIndex = 21;
            this.chkHeavyGlass.Text = "Heavy/Large Glass";
            this.chkHeavyGlass.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "This will affect ALL line items";
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(119, 192);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(75, 23);
            this.btnToggle.TabIndex = 28;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(18, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmChkUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 227);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbInstallLocation);
            this.Controls.Add(this.chkMastic);
            this.Controls.Add(this.chkDisposal);
            this.Controls.Add(this.chkRemoval);
            this.Controls.Add(this.chkShapedGlass);
            this.Controls.Add(this.chkHeavyGlass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChkUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Toggle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbInstallLocation;
        private System.Windows.Forms.CheckBox chkMastic;
        private System.Windows.Forms.CheckBox chkDisposal;
        private System.Windows.Forms.CheckBox chkRemoval;
        private System.Windows.Forms.CheckBox chkShapedGlass;
        private System.Windows.Forms.CheckBox chkHeavyGlass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnCancel;
    }
}