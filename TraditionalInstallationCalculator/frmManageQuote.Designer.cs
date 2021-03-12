namespace TraditionalInstallationCalculator
{
    partial class frmManageQuote
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageQuote));
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvExport = new System.Windows.Forms.DataGridView();
            this.chkLondon = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMiles = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVisits = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalMiles = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSiteAddress1 = new System.Windows.Forms.TextBox();
            this.txtSiteAddress2 = new System.Windows.Forms.TextBox();
            this.txtSiteAddress3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.btnHLglass = new System.Windows.Forms.Button();
            this.btnShapedGlass = new System.Windows.Forms.Button();
            this.btnRemoval = new System.Windows.Forms.Button();
            this.btnDisposal = new System.Windows.Forms.Button();
            this.btnMastic = new System.Windows.Forms.Button();
            this.btnFreeNotes = new System.Windows.Forms.Button();
            this.txtHiddenBox = new System.Windows.Forms.RichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtTravelCost = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(12, 162);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.Size = new System.Drawing.Size(1289, 413);
            this.dgvItems.TabIndex = 1;
            this.dgvItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellDoubleClick);
            // 
            // btnNewItem
            // 
            this.btnNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewItem.Location = new System.Drawing.Point(1206, 133);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(95, 23);
            this.btnNewItem.TabIndex = 2;
            this.btnNewItem.Text = "Add New Item";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(12, 107);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(145, 23);
            this.btnLink.TabIndex = 3;
            this.btnLink.Text = "Link Quote with Customer";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "No Customer has been linked";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1069, 133);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(131, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export to word";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1019, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 67);
            this.label4.TabIndex = 10;
            this.label4.Text = "Quote Items";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvExport
            // 
            this.dgvExport.AllowUserToAddRows = false;
            this.dgvExport.AllowUserToDeleteRows = false;
            this.dgvExport.AllowUserToResizeColumns = false;
            this.dgvExport.AllowUserToResizeRows = false;
            this.dgvExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExport.Location = new System.Drawing.Point(12, 354);
            this.dgvExport.Name = "dgvExport";
            this.dgvExport.ReadOnly = true;
            this.dgvExport.RowHeadersVisible = false;
            this.dgvExport.Size = new System.Drawing.Size(1289, 155);
            this.dgvExport.TabIndex = 11;
            this.dgvExport.Visible = false;
            // 
            // chkLondon
            // 
            this.chkLondon.AutoSize = true;
            this.chkLondon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLondon.Location = new System.Drawing.Point(289, 12);
            this.chkLondon.Name = "chkLondon";
            this.chkLondon.Size = new System.Drawing.Size(133, 22);
            this.chkLondon.TabIndex = 12;
            this.chkLondon.Text = "Install in London";
            this.chkLondon.UseVisualStyleBackColor = true;
            this.chkLondon.CheckedChanged += new System.EventHandler(this.chkLondon_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mileage One way:";
            // 
            // txtMiles
            // 
            this.txtMiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiles.Location = new System.Drawing.Point(342, 40);
            this.txtMiles.Name = "txtMiles";
            this.txtMiles.Size = new System.Drawing.Size(80, 24);
            this.txtMiles.TabIndex = 13;
            this.txtMiles.TextChanged += new System.EventHandler(this.txtMiles_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(217, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Number of visits:";
            // 
            // txtVisits
            // 
            this.txtVisits.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisits.Location = new System.Drawing.Point(342, 70);
            this.txtVisits.Name = "txtVisits";
            this.txtVisits.Size = new System.Drawing.Size(80, 24);
            this.txtVisits.TabIndex = 15;
            this.txtVisits.TextChanged += new System.EventHandler(this.txtVisits_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(236, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Total Mileage:";
            // 
            // txtTotalMiles
            // 
            this.txtTotalMiles.Enabled = false;
            this.txtTotalMiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMiles.Location = new System.Drawing.Point(342, 100);
            this.txtTotalMiles.Name = "txtTotalMiles";
            this.txtTotalMiles.Size = new System.Drawing.Size(80, 24);
            this.txtTotalMiles.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(577, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "Site Address";
            // 
            // txtSiteAddress1
            // 
            this.txtSiteAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiteAddress1.Location = new System.Drawing.Point(674, 9);
            this.txtSiteAddress1.Name = "txtSiteAddress1";
            this.txtSiteAddress1.Size = new System.Drawing.Size(175, 24);
            this.txtSiteAddress1.TabIndex = 19;
            // 
            // txtSiteAddress2
            // 
            this.txtSiteAddress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiteAddress2.Location = new System.Drawing.Point(674, 38);
            this.txtSiteAddress2.Name = "txtSiteAddress2";
            this.txtSiteAddress2.Size = new System.Drawing.Size(175, 24);
            this.txtSiteAddress2.TabIndex = 25;
            // 
            // txtSiteAddress3
            // 
            this.txtSiteAddress3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiteAddress3.Location = new System.Drawing.Point(674, 67);
            this.txtSiteAddress3.Name = "txtSiteAddress3";
            this.txtSiteAddress3.Size = new System.Drawing.Size(175, 24);
            this.txtSiteAddress3.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(585, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Post Code:";
            // 
            // txtPostCode
            // 
            this.txtPostCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostCode.Location = new System.Drawing.Point(674, 96);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(112, 24);
            this.txtPostCode.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(613, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "County:";
            // 
            // txtCounty
            // 
            this.txtCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCounty.Location = new System.Drawing.Point(674, 125);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(112, 24);
            this.txtCounty.TabIndex = 30;
            // 
            // btnHLglass
            // 
            this.btnHLglass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHLglass.Location = new System.Drawing.Point(865, 11);
            this.btnHLglass.Name = "btnHLglass";
            this.btnHLglass.Size = new System.Drawing.Size(143, 22);
            this.btnHLglass.TabIndex = 31;
            this.btnHLglass.Text = "Add Heavy/Large Glass";
            this.toolTip.SetToolTip(this.btnHLglass, "Glass over 100KG\r\nGlass with either width or height over 2.2 meters\r\n\r\n\r\n");
            this.btnHLglass.UseVisualStyleBackColor = true;
            this.btnHLglass.Click += new System.EventHandler(this.btnHLglass_Click);
            // 
            // btnShapedGlass
            // 
            this.btnShapedGlass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShapedGlass.Location = new System.Drawing.Point(865, 40);
            this.btnShapedGlass.Name = "btnShapedGlass";
            this.btnShapedGlass.Size = new System.Drawing.Size(143, 22);
            this.btnShapedGlass.TabIndex = 32;
            this.btnShapedGlass.Text = "Add Shaped Glass";
            this.btnShapedGlass.UseVisualStyleBackColor = true;
            this.btnShapedGlass.Click += new System.EventHandler(this.btnShapedGlass_Click);
            // 
            // btnRemoval
            // 
            this.btnRemoval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoval.Location = new System.Drawing.Point(865, 69);
            this.btnRemoval.Name = "btnRemoval";
            this.btnRemoval.Size = new System.Drawing.Size(143, 22);
            this.btnRemoval.TabIndex = 33;
            this.btnRemoval.Text = "Add Removal";
            this.btnRemoval.UseVisualStyleBackColor = true;
            this.btnRemoval.Click += new System.EventHandler(this.btnRemoval_Click);
            // 
            // btnDisposal
            // 
            this.btnDisposal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisposal.Location = new System.Drawing.Point(865, 98);
            this.btnDisposal.Name = "btnDisposal";
            this.btnDisposal.Size = new System.Drawing.Size(143, 22);
            this.btnDisposal.TabIndex = 34;
            this.btnDisposal.Text = "Add Disposal";
            this.btnDisposal.UseVisualStyleBackColor = true;
            this.btnDisposal.Click += new System.EventHandler(this.btnDisposal_Click);
            // 
            // btnMastic
            // 
            this.btnMastic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMastic.Location = new System.Drawing.Point(865, 127);
            this.btnMastic.Name = "btnMastic";
            this.btnMastic.Size = new System.Drawing.Size(143, 22);
            this.btnMastic.TabIndex = 35;
            this.btnMastic.Text = "Add Mastic";
            this.btnMastic.UseVisualStyleBackColor = true;
            this.btnMastic.Click += new System.EventHandler(this.btnMastic_Click);
            // 
            // btnFreeNotes
            // 
            this.btnFreeNotes.Location = new System.Drawing.Point(345, 130);
            this.btnFreeNotes.Name = "btnFreeNotes";
            this.btnFreeNotes.Size = new System.Drawing.Size(131, 23);
            this.btnFreeNotes.TabIndex = 36;
            this.btnFreeNotes.Text = "Free Hand Notes";
            this.btnFreeNotes.UseVisualStyleBackColor = true;
            this.btnFreeNotes.Click += new System.EventHandler(this.btnFreeNotes_Click);
            // 
            // txtHiddenBox
            // 
            this.txtHiddenBox.Location = new System.Drawing.Point(345, 263);
            this.txtHiddenBox.Name = "txtHiddenBox";
            this.txtHiddenBox.Size = new System.Drawing.Size(507, 59);
            this.txtHiddenBox.TabIndex = 37;
            this.txtHiddenBox.Text = "";
            this.txtHiddenBox.Visible = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(428, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Travel Cost";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTravelCost
            // 
            this.txtTravelCost.Enabled = false;
            this.txtTravelCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTravelCost.Location = new System.Drawing.Point(428, 70);
            this.txtTravelCost.Name = "txtTravelCost";
            this.txtTravelCost.ReadOnly = true;
            this.txtTravelCost.Size = new System.Drawing.Size(100, 24);
            this.txtTravelCost.TabIndex = 38;
            // 
            // frmManageQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 587);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTravelCost);
            this.Controls.Add(this.txtHiddenBox);
            this.Controls.Add(this.btnFreeNotes);
            this.Controls.Add(this.btnMastic);
            this.Controls.Add(this.btnDisposal);
            this.Controls.Add(this.btnRemoval);
            this.Controls.Add(this.btnShapedGlass);
            this.Controls.Add(this.btnHLglass);
            this.Controls.Add(this.txtCounty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPostCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSiteAddress3);
            this.Controls.Add(this.txtSiteAddress2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSiteAddress1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalMiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVisits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMiles);
            this.Controls.Add(this.chkLondon);
            this.Controls.Add(this.dgvExport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.btnNewItem);
            this.Controls.Add(this.dgvItems);
            this.Name = "frmManageQuote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmManageQuote_FormClosing);
            this.Shown += new System.EventHandler(this.frmManageQuote_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvExport;
        private System.Windows.Forms.CheckBox chkLondon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVisits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalMiles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSiteAddress1;
        private System.Windows.Forms.TextBox txtSiteAddress2;
        private System.Windows.Forms.TextBox txtSiteAddress3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPostCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCounty;
        private System.Windows.Forms.Button btnHLglass;
        private System.Windows.Forms.Button btnShapedGlass;
        private System.Windows.Forms.Button btnRemoval;
        private System.Windows.Forms.Button btnDisposal;
        private System.Windows.Forms.Button btnMastic;
        private System.Windows.Forms.Button btnFreeNotes;
        private System.Windows.Forms.RichTextBox txtHiddenBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTravelCost;
    }
}