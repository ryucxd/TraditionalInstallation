namespace TraditionalInstallationCalculator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtTravelMiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHeavyGlass = new System.Windows.Forms.CheckBox();
            this.chkShapedGlass = new System.Windows.Forms.CheckBox();
            this.chkRemoval = new System.Windows.Forms.CheckBox();
            this.chkDisposal = new System.Windows.Forms.CheckBox();
            this.chkLondon = new System.Windows.Forms.CheckBox();
            this.chkMastic = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtSalesValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbInstallLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDoorReference = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExtraCost = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(147, 71);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(68, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWidth_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Structural Opening Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Structural Opening Height:";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(147, 98);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(68, 20);
            this.txtHeight.TabIndex = 1;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeight_KeyPress);
            // 
            // txtTravelMiles
            // 
            this.txtTravelMiles.Location = new System.Drawing.Point(147, 112);
            this.txtTravelMiles.Name = "txtTravelMiles";
            this.txtTravelMiles.Size = new System.Drawing.Size(68, 20);
            this.txtTravelMiles.TabIndex = 2;
            this.txtTravelMiles.Visible = false;
            this.txtTravelMiles.TextChanged += new System.EventHandler(this.txtTravelMiles_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mileage One way:";
            this.label2.Visible = false;
            // 
            // chkHeavyGlass
            // 
            this.chkHeavyGlass.AutoSize = true;
            this.chkHeavyGlass.Location = new System.Drawing.Point(15, 176);
            this.chkHeavyGlass.Name = "chkHeavyGlass";
            this.chkHeavyGlass.Size = new System.Drawing.Size(118, 17);
            this.chkHeavyGlass.TabIndex = 6;
            this.chkHeavyGlass.Text = "Heavy/Large Glass";
            this.chkHeavyGlass.UseVisualStyleBackColor = true;
            this.chkHeavyGlass.CheckedChanged += new System.EventHandler(this.chkHeavyGlass_CheckedChanged);
            // 
            // chkShapedGlass
            // 
            this.chkShapedGlass.AutoSize = true;
            this.chkShapedGlass.Location = new System.Drawing.Point(15, 199);
            this.chkShapedGlass.Name = "chkShapedGlass";
            this.chkShapedGlass.Size = new System.Drawing.Size(92, 17);
            this.chkShapedGlass.TabIndex = 7;
            this.chkShapedGlass.Text = "Shaped Glass";
            this.chkShapedGlass.UseVisualStyleBackColor = true;
            this.chkShapedGlass.CheckedChanged += new System.EventHandler(this.chkShapedGlass_CheckedChanged);
            // 
            // chkRemoval
            // 
            this.chkRemoval.AutoSize = true;
            this.chkRemoval.Location = new System.Drawing.Point(15, 222);
            this.chkRemoval.Name = "chkRemoval";
            this.chkRemoval.Size = new System.Drawing.Size(114, 17);
            this.chkRemoval.TabIndex = 8;
            this.chkRemoval.Text = "Removal Required";
            this.chkRemoval.UseVisualStyleBackColor = true;
            this.chkRemoval.CheckedChanged += new System.EventHandler(this.chkRemoval_CheckedChanged);
            // 
            // chkDisposal
            // 
            this.chkDisposal.AutoSize = true;
            this.chkDisposal.Location = new System.Drawing.Point(15, 245);
            this.chkDisposal.Name = "chkDisposal";
            this.chkDisposal.Size = new System.Drawing.Size(112, 17);
            this.chkDisposal.TabIndex = 9;
            this.chkDisposal.Text = "Disposal Required";
            this.chkDisposal.UseVisualStyleBackColor = true;
            this.chkDisposal.CheckedChanged += new System.EventHandler(this.chkDisposal_CheckedChanged);
            // 
            // chkLondon
            // 
            this.chkLondon.AutoSize = true;
            this.chkLondon.Location = new System.Drawing.Point(147, 112);
            this.chkLondon.Name = "chkLondon";
            this.chkLondon.Size = new System.Drawing.Size(62, 17);
            this.chkLondon.TabIndex = 3;
            this.chkLondon.Text = "London";
            this.chkLondon.UseVisualStyleBackColor = true;
            this.chkLondon.Visible = false;
            // 
            // chkMastic
            // 
            this.chkMastic.AutoSize = true;
            this.chkMastic.Location = new System.Drawing.Point(15, 268);
            this.chkMastic.Name = "chkMastic";
            this.chkMastic.Size = new System.Drawing.Size(103, 17);
            this.chkMastic.TabIndex = 10;
            this.chkMastic.Text = "Mastic Required";
            this.chkMastic.UseVisualStyleBackColor = true;
            this.chkMastic.CheckedChanged += new System.EventHandler(this.chkMastic_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Discount %:";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(426, 338);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(68, 20);
            this.txtDiscount.TabIndex = 11;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // txtSalesValue
            // 
            this.txtSalesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesValue.Location = new System.Drawing.Point(395, 393);
            this.txtSalesValue.Name = "txtSalesValue";
            this.txtSalesValue.ReadOnly = true;
            this.txtSalesValue.Size = new System.Drawing.Size(100, 29);
            this.txtSalesValue.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(158, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Installation Sales Value:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(419, 364);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 16;
            this.btnGenerate.Text = "Calculate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // cmbInstallLocation
            // 
            this.cmbInstallLocation.FormattingEnabled = true;
            this.cmbInstallLocation.Items.AddRange(new object[] {
            "Ground Floor",
            "Basement",
            "Upper Floors"});
            this.cmbInstallLocation.Location = new System.Drawing.Point(102, 138);
            this.cmbInstallLocation.Name = "cmbInstallLocation";
            this.cmbInstallLocation.Size = new System.Drawing.Size(113, 21);
            this.cmbInstallLocation.TabIndex = 4;
            this.cmbInstallLocation.Text = "Ground Floor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Install Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Door Reference";
            // 
            // txtDoorReference
            // 
            this.txtDoorReference.Location = new System.Drawing.Point(147, 17);
            this.txtDoorReference.Name = "txtDoorReference";
            this.txtDoorReference.Size = new System.Drawing.Size(68, 20);
            this.txtDoorReference.TabIndex = 20;
            this.txtDoorReference.TextChanged += new System.EventHandler(this.txtDoorReference_TextChanged);
            this.txtDoorReference.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoorReference_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(395, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save Information";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(221, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(342, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "EXTRA COST:";
            // 
            // txtExtraCost
            // 
            this.txtExtraCost.Location = new System.Drawing.Point(426, 199);
            this.txtExtraCost.Name = "txtExtraCost";
            this.txtExtraCost.Size = new System.Drawing.Size(68, 20);
            this.txtExtraCost.TabIndex = 25;
            this.txtExtraCost.TextChanged += new System.EventHandler(this.txtExtraCost_TextChanged);
            this.txtExtraCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExtraCost_KeyPress);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(162, 251);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(333, 73);
            this.txtNote.TabIndex = 27;
            this.txtNote.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(162, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(332, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Please Enter Information About the Extra Cost";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(66, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Quantity:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(147, 44);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(68, 20);
            this.txtQty.TabIndex = 29;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 463);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtExtraCost);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDoorReference);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbInstallLocation);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSalesValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.chkMastic);
            this.Controls.Add(this.chkLondon);
            this.Controls.Add(this.chkDisposal);
            this.Controls.Add(this.chkRemoval);
            this.Controls.Add(this.chkShapedGlass);
            this.Controls.Add(this.chkHeavyGlass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTravelMiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slimline Install Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtTravelMiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkHeavyGlass;
        private System.Windows.Forms.CheckBox chkShapedGlass;
        private System.Windows.Forms.CheckBox chkRemoval;
        private System.Windows.Forms.CheckBox chkDisposal;
        private System.Windows.Forms.CheckBox chkLondon;
        private System.Windows.Forms.CheckBox chkMastic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtSalesValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbInstallLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDoorReference;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExtraCost;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQty;
    }
}

