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
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Outlook;

namespace TraditionalInstallationCalculator
{
    public partial class frmManageQuote : Form
    {
        public int updateMiles { get; set; } //if this is triggered update mileage on close;

        public int quoteNumber { get; set; }
        public string _customer { get; set; }
        public int allowClose { get; set; }
        public string projectReference { get; set; }

        //mass update variables
        public int _HLGlass { get; set; }
        public int _shapedGlass { get; set; }
        public int _removal { get; set; }
        public int _disposal { get; set; }
        public int _mastic { get; set; }
        public int _HLGlassPressed { get; set; }
        public int _shapedGlassPressed { get; set; }
        public int _removalPressed { get; set; }
        public int _disposalPressed { get; set; }
        public int _masticPressed { get; set; }
        public int buttonPressed { get; set; }
        public string sqlButton { get; set; }


        public frmManageQuote(int qnum, int newQuote) // if new quote is -1 its a new quote -- if new quote is -2 its a new quote AND imported with csv
        {
            InitializeComponent();
            quoteNumber = qnum;
            if (newQuote == -1 || newQuote == -2)  //if it is a new quote then we need to prompt for the customer and reference to be linked
            {
                frmLinkCustomer frm = new frmLinkCustomer(qnum);
                frm.ShowDialog();
            }
            if (newQuote == -2)
            {
                //frmChkUpdate frm = new frmChkUpdate(qnum);   //commented this out 25/11/2020 - adding buttons in place of this force
                //frm.ShowDialog();
            }
            loaddgv();
        }


        private void loaddgv()
        {
            string sql = "SELECT [id],[door_reference], [structural_opening_width], [structural_opening_height], [mileage_one_way]" +
                ", CASE WHEN[london] = 1 then 'Yes' ELSE 'No' END as [london], [install_location], " +
                "CASE WHEN[heavy_large_glass] = 1 then 'Yes' ELSE 'No' END as [heavy_large_glass], " +
                "CASE WHEN[shaped_glass] = 1 then 'Yes' ELSE 'No' END as [shaped_glass], " +
                "CASE WHEN[removal_required] = 1  then 'Yes' ELSE 'No' END as [removal_required], " +
                "CASE WHEN[disposal_required] = 1  then 'Yes' ELSE 'No' END as [disposal_required], " +
                "CASE WHEN[mastic_required] = 1  then 'Yes' ELSE 'No' END as [mastic_required], " +
                "'£' + CAST(COALESCE([extra_cost],0) as nvarchar) as [Extra Cost], " +
                "COALESCE(quantity_same,1) as [Quantity],  " +
                "CAST([discount_percent] as nvarchar) +'%' as [discount_percent], " +
                "'£' + CAST([total_value] as nvarchar) as  [total_value], [quote_id] " +
                "FROM [order_database].[dbo].[slimline_install_door] WHERE quote_id = " + quoteNumber.ToString() + " ORDER BY id DESC";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    dgvItems.DataSource = dt;
                }
                //while we are here lets also load the customer link (if there is one)
                sql = "select [NAME] FROM dbo.slimline_install_quote a LEFT JOIN [dsl_fitting].[dbo].[SALES_LEDGER] b ON a.custAccRef = b.ACCOUNT_REF WHERE b.ACCOUNT_REF is not null AND a.id = " + quoteNumber.ToString() + "";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var getData = Convert.ToString(cmd.ExecuteScalar());
                    if (getData != "")
                    {
                        label1.Text = "Customer: " + getData;
                        _customer = getData;
                        btnLink.Text = "Change linked Customer";
                    }
                    else
                        _customer = "No Customer Linked";

                }
                //load data into the hidden dgv thats used for exporting only
                sql = "SELECT [door_reference] as [Reference], [structural_opening_width] as [Structural Opening Width], [structural_opening_height] as [Structural Opening Height]," +
                          "install_location as [Install Location], " +
                          "CASE WHEN[removal_required] = 1  then 'Yes' ELSE 'No' END as [Removal Required], " +
                          "CASE WHEN[disposal_required] = 1  then 'Yes' ELSE 'No' END as [Disposal Required], " +
                          "CASE WHEN[mastic_required] = 1  then 'Yes' ELSE 'No' END as [Mastic Required], " +
                          "quantity_same as  [Quantity]," +
                          "CAST([discount_percent] as nvarchar) +'%' as [Discount %], " +
                          "'£' + CAST([total_value] as nvarchar) as  [Sum Value] " +
                          "FROM [order_database].[dbo].[slimline_install_door] WHERE quote_id = " + quoteNumber.ToString() + " ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    DataRow mileageRow = dt.NewRow();
                    dt.Rows.Add(mileageRow);
                    DataRow row = dt.NewRow();
                    dt.Rows.Add(row);
                    //get the total 
                    double total = 0;
                    sql = "SELECT COALESCE(mileage_cost,0) FROM dbo.slimline_install_quote WHERE id = " + quoteNumber;
                    using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                        total = Convert.ToDouble(cmd2.ExecuteScalar());
                    dt.Rows[dt.Rows.Count - 2][dt.Columns.Count - 1] = "£" + total.ToString();
                    dt.Rows[dt.Rows.Count - 2][dt.Columns.Count - 2] = "Travel Cost:";

                    sql = "SELECT SUM(COALESCE(sumtotal ,0)+ COALESCE(mileage_cost,0)) FROM dbo.slimline_install_quote WHERE id = " + quoteNumber;
                    using (SqlCommand cmd2 = new SqlCommand(sql, conn))
                        total = Convert.ToDouble(cmd2.ExecuteScalar());
                    dt.Rows[dt.Rows.Count - 1][dt.Columns.Count - 1] = "£" + total.ToString();
                    dt.Rows[dt.Rows.Count - 1][dt.Columns.Count - 2] = "Total Value:";
                    dgvExport.DataSource = dt;

                }


                //load the reference,miles and london - and now extras - ok and now we are also adding free hand note
                sql = "SELECT projectReference,mileage_one_way,site_visits,total_mileage,london,site_address_1,site_address_2,site_address_3,post_code,county," +
                    "heavy_large_glass,shaped_glass,removal_required,disposal_required,mastic_required,COALESCE(free_hand_note,''), COALESCE(mileage_cost,0)FROM dbo.slimline_install_quote WHERE id = " + quoteNumber;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);
                    projectReference = dt.Rows[0][0].ToString();
                    txtMiles.Text = dt.Rows[0][1].ToString();
                    txtVisits.Text = dt.Rows[0][2].ToString();
                    txtTotalMiles.Text = dt.Rows[0][3].ToString();
                    txtSiteAddress1.Text = dt.Rows[0][5].ToString();
                    txtSiteAddress2.Text = dt.Rows[0][6].ToString();
                    txtSiteAddress3.Text = dt.Rows[0][7].ToString();
                    txtPostCode.Text = dt.Rows[0][8].ToString();
                    txtCounty.Text = dt.Rows[0][9].ToString();
                    //gonna stitch this in here
                    _HLGlass = Convert.ToInt32(dt.Rows[0][10].ToString());
                    _shapedGlass = Convert.ToInt32(dt.Rows[0][11].ToString());
                    _removal = Convert.ToInt32(dt.Rows[0][12].ToString());
                    _disposal = Convert.ToInt32(dt.Rows[0][13].ToString());
                    _mastic = Convert.ToInt32(dt.Rows[0][14].ToString());
                    txtHiddenBox.Text = Convert.ToString(dt.Rows[0][15].ToString());
                    txtTravelCost.Text = Convert.ToString(dt.Rows[0][16].ToString());
                    string temp = Convert.ToString(dt.Rows[0][4].ToString());
                    if (temp == "1")
                        chkLondon.Checked = true;
                    else
                        chkLondon.Checked = false;

                }


                conn.Close();
            }
            format();
        }


        private void format()
        {
            dgvItems.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // dgvItems.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //cant find a good balance for these
            dgvItems.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //Fill looks good ONLY when its full screen
            dgvItems.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //12 is now extra cost
            dgvItems.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //13 is now quantity
            dgvItems.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItems.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvItems.Columns[0].HeaderText = "ID";
            dgvItems.Columns[1].HeaderText = "Door Reference";
            dgvItems.Columns[2].HeaderText = "Structural Opening Width";
            dgvItems.Columns[3].HeaderText = "Structural Opening Height";
            //dgvItems.Columns[4].HeaderText = "Mileage One Way";
            dgvItems.Columns[4].Visible = false; //removing mileage
            //   dgvItems.Columns[5].HeaderText = "London";
            dgvItems.Columns[5].Visible = false; //removing london
            dgvItems.Columns[6].HeaderText = "Install Location";
            dgvItems.Columns[7].HeaderText = "Heavy/Large Glass";
            dgvItems.Columns[8].HeaderText = "Shaped Glass";
            dgvItems.Columns[9].HeaderText = "Removal Required";
            dgvItems.Columns[10].HeaderText = "Disposal Required";
            dgvItems.Columns[11].HeaderText = "Mastic Required";
            dgvItems.Columns[12].HeaderText = "Extra Cost";
            dgvItems.Columns[13].HeaderText = "Quantity";
            dgvItems.Columns[14].HeaderText = "Discount Percentage";
            dgvItems.Columns[15].HeaderText = "Total Value";
            dgvItems.Columns[16].Visible = false;

            //set the dgv to fit the content thats in it 
            //dgvItems.Width = dgvItems.Columns.Cast<DataGridViewColumn>().Where(x => x.Visible).Sum(x => x.Width) + (dgvItems.RowHeadersVisible ? dgvItems.RowHeadersWidth : 0) + 5;
            //dgvItems.Width = 1405;
            //we also set the form to this size  so it is always perfectly at the largest it needs to be to display the data 
            //this.Width = dgvItems.Columns.Cast<DataGridViewColumn>().Where(x => x.Visible).Sum(x => x.Width) + (dgvItems.RowHeadersVisible ? dgvItems.RowHeadersWidth : 0) + 5;
            this.Width = 1505;
            colourDGV();
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO dbo.[slimline_install_door] (quote_id) VALUES(" + quoteNumber + ")";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmdID = new SqlCommand("SELECT MAX(id) FROM dbo.[slimline_install_door] ", conn))
                {
                    Form1 frm = new Form1(Convert.ToInt32(cmdID.ExecuteScalar()), quoteNumber, 0);
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                    loaddgv();
                }
                conn.Close();
                updateLineItems();
            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 frm = new Form1(Convert.ToInt32(dgvItems.Rows[e.RowIndex].Cells[0].Value), quoteNumber, -1);
            frm.ShowDialog();
            updateLineItems();
            loaddgv();
        }

        private void frmManageQuote_Shown(object sender, EventArgs e)
        {
            colourDGV();
            label1.TextAlign = ContentAlignment.BottomLeft;
        }
        private void colourDGV()
        {
            for (int i = 0; i < dgvItems.Rows.Count; i++)
            {
                for (int z = 0; z < dgvItems.Columns.Count; z++)
                {
                    if (dgvItems.Rows[i].Cells[z].Value.ToString() == "Yes")
                        dgvItems.Rows[i].Cells[z].Style.BackColor = Color.DarkSeaGreen;
                    if (dgvItems.Rows[i].Cells[z].Value.ToString() == "No")
                        dgvItems.Rows[i].Cells[z].Style.BackColor = Color.PaleVioletRed;
                }
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            frmLinkCustomer frm = new frmLinkCustomer(quoteNumber);
            frm.ShowDialog();
            loaddgv();
        }

        private void frmManageQuote_FormClosing(object sender, FormClosingEventArgs e)
        {
            string sql = "";
            if (allowClose != 99)
            {
                double sumTotal = 0;
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    if (Convert.ToString(dgvItems.Rows[i].Cells[15].Value) != "")
                    {
                        string temp = Convert.ToString(dgvItems.Rows[i].Cells[15].Value);
                        temp = temp.Substring(1, temp.Length - 1);
                        sumTotal = sumTotal + Convert.ToDouble(temp);
                    }
                }
                if (sumTotal > 0)
                {
                    sql = "UPDATE dbo.slimline_install_quote SET sumTotal = " + sumTotal + "WHERE id = " + quoteNumber;
                    using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                allowClose = 99;
            }

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                updateLineItems();

                // update miles and the below code have been added to the  above function
                //sql = "UPDATE dbo.slimline_install_quote SET london = " + Convert.ToInt32(chkLondon.Checked).ToString() + ",site_address_1 = '" + txtSiteAddress1.Text + "', site_address_2 = '" + txtSiteAddress2.Text + "'," +
                //          "site_address_3 = '" + txtSiteAddress3.Text + "',post_code = '" + txtPostCode.Text + "',county = '" + txtCounty.Text + "' WHERE id = " + quoteNumber.ToString();
                //using (SqlCommand cmd = new SqlCommand(sql, conn))
                //    cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //ok we are starting FRESH 
            //OBJECT OF MISSING "NULL VALUE"  
            Object oMissing = System.Reflection.Missing.Value;
            //OBJECTS OF FALSE AND TRUE  
            Object oTrue = true;
            Object oFalse = false;
            //CREATING OBJECTS OF WORD AND DOCUMENT  
            Word.Application oWord = new Word.Application();
            Word.Document oDoc = new Word.Document();
            //SETTING THE VISIBILITY TO TRUE  
            oWord.Visible = true;
            //THE LOCATION OF THE TEMPLATE FILE ON THE MACHINE  
            Object oTemplatePath = @"\\DESIGNSVR1\apps\Design and Supply CSharp\temp.docx";
            //ADDING A NEW DOCUMENT FROM A TEMPLATE  
            oDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

            ;

            if (dgvExport.Rows.Count != 0)
            {
                int RowCount = dgvExport.Rows.Count;
                int ColumnCount = dgvExport.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = dgvExport.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop



                //page orintation
                // oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                //the below code is the most important part, this is used to select which location text gets entered.
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string bookmark = "bookmark_table";
                Bookmark bm = oDoc.Bookmarks[bookmark];
                Range range = bm.Range;
                //range.Text = "THIS SHOULD BE ADDED AT THE BOOKMARK END BUT IM NOT SURE HOW THIS WILL OUTPUT OR HOW IT WILL LOOK ETC :)";
                oDoc.Bookmarks.Add(bookmark, range);
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dynamic oRange = range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;  //need to break point here and go through each line till i find which is adding the very first line 
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();
                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma"; // need the change the font size both here AND below a few lines
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 8; //tahoma?????

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dgvExport.Columns[c].HeaderText;
                }

                //table style 
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 2 - Accent 5"); //probably the nicest theme tbh
                oDoc.Application.Selection.Tables[1].Range.Font.Size = 8;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;


                bookmark = "Customer"; //could theoretically pop these anywhere
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = _customer.TrimEnd();
                oDoc.Bookmarks.Add(bookmark, range);

                bookmark = "quoteNumber";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = quoteNumber.ToString();
                oDoc.Bookmarks.Add(bookmark, range);

                bookmark = "quotationRef";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = projectReference;
                oDoc.Bookmarks.Add(bookmark, range);

                bookmark = "quoted_by";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = Login._fullName;
                oDoc.Bookmarks.Add(bookmark, range);

                bookmark = "date";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = DateTime.Today.ToShortDateString();
                oDoc.Bookmarks.Add(bookmark, range);

                bookmark = "free_hand_note";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = "**Note**" + Environment.NewLine + txtHiddenBox.Text;
                oDoc.Bookmarks.Add(bookmark, range);

                //customer site details    
                bookmark = "CustomerAddress1";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = txtSiteAddress1.Text;
                oDoc.Bookmarks.Add(bookmark, range);

                bookmark = "CustomerAddress2";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = txtSiteAddress2.Text;
                oDoc.Bookmarks.Add(bookmark, range);

                bookmark = "CustomerAddress3";
                bm = oDoc.Bookmarks[bookmark];
                range = bm.Range;
                range.Text = txtSiteAddress3.Text;
                oDoc.Bookmarks.Add(bookmark, range);


                //save it on server 
                string path = @"\\DESIGNSVR1\public\slimline_installation_quote\" + quoteNumber.ToString();
                System.IO.Directory.CreateDirectory(path); //unique folder

                //count the items in the target folder
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
                int revNumber = dir.GetFiles().Length;
                revNumber = (revNumber / 2) + 1; //because it outputs 2 files per quote

                path = @"\\DESIGNSVR1\public\slimline_installation_quote\" + quoteNumber.ToString() + @"\Slimline_installation_quote_" + quoteNumber.ToString() + "_revision-" + revNumber;
                oDoc.SaveAs2(path, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault); //save it as docx or w/e
                oDoc.SaveAs2(path, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF); //save as pdf


                //close doc here???


                //add to email
                DialogResult result = MessageBox.Show("Would you like to attach this document to an email?", "Attach to email", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                    Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                    oMsg.Subject = "Slimline Installation Quote";
                    oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                    oMsg.HTMLBody = " ";
                    oMsg.Attachments.Add(path + ".docx", Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                    oMsg.Display(false);
                }
            }
        }

        private void txtMiles_TextChanged(object sender, EventArgs e)
        {
            mileage();
        }

        private void txtVisits_TextChanged(object sender, EventArgs e)
        {
            mileage();
        }

        private void mileage()
        {
            if (String.IsNullOrWhiteSpace(txtMiles.Text) || string.IsNullOrWhiteSpace(txtVisits.Text))
                return;
            double totalMiles = Convert.ToDouble(txtMiles.Text) * 2;
            totalMiles = totalMiles * Convert.ToDouble(txtVisits.Text);
            txtTotalMiles.Text = totalMiles.ToString();
            updateMiles = -1;
            calculate_mileage();
            updateLineItems();
        }

        private void chkLondon_CheckedChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMiles.Text) || string.IsNullOrWhiteSpace(txtVisits.Text))
                return;
            calculate_mileage();
            updateLineItems();
        }

        private void btnHLglass_Click(object sender, EventArgs e)
        {
            if (_HLGlass == 0)
                _HLGlass = 1;
            else
                _HLGlass = 0;
            _HLGlassPressed = -1;
            buttonPressed = -1;
            updateLineItems();
        }
        private void btnShapedGlass_Click(object sender, EventArgs e)
        {
            if (_shapedGlass == 0)
                _shapedGlass = 1;
            else
                _shapedGlass = 0;
            _shapedGlassPressed = -1;
            buttonPressed = -1;
            updateLineItems();
        }

        private void btnRemoval_Click(object sender, EventArgs e)
        {
            if (_removal == 0)
                _removal = 1;
            else
                _removal = 0;
            _removalPressed = -1;
            buttonPressed = -1;
            updateLineItems();
        }

        private void btnDisposal_Click(object sender, EventArgs e)
        {
            if (_disposal == 0)
                _disposal = 1;
            else
                _disposal = 0;
            buttonPressed = -1;
            _disposalPressed = -1;
            updateLineItems();
        }

        private void btnMastic_Click(object sender, EventArgs e)
        {
            if (_mastic == 0)
                _mastic = 1;
            else
                _mastic = 0;
            _masticPressed = -1;
            buttonPressed = -1;
            updateLineItems();
        }

        private void buttonString()
        {
            //the point of this is to build a string that only updates the part that has been pressed 
            string sql = "";

            if (_HLGlassPressed == -1)
                sql =  "heavy_large_glass = " + _HLGlass.ToString() + " ";
            if (_shapedGlassPressed == -1)
                sql =  "shaped_glass = " + _shapedGlass.ToString() + " ";
            if (_removalPressed == -1)
                sql =  "removal_required = " + _removal.ToString() + " ";
            if (_disposalPressed == -1)
                sql =  "disposal_required = " + _disposal.ToString() + " ";
            if (_masticPressed == -1)
                sql =  "mastic_required = " + _mastic.ToString() + " ";  //because this triggers each time  SINGLE BUTTON is pressed we dont need to worry about updating them all

            _HLGlassPressed = 0;
            _shapedGlassPressed = 0;
            _removalPressed = 0;
            _disposalPressed = 0;
            _masticPressed = 0;


            
            sqlButton = sql;
        }


        private void updateLineItems()  //look at all of the variables and update based on this
        {
            string sql = "UPDATE dbo.slimline_install_quote SET site_address_1 = '" + txtSiteAddress1.Text + "', site_address_2 = '" + txtSiteAddress2.Text + "'," +
                          "site_address_3 = '" + txtSiteAddress3.Text + "',post_code = '" + txtPostCode.Text + "',county = '" + txtCounty.Text + "' WHERE id = " + quoteNumber;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                // ^^^^^^^^^^ updates the site address
                if (buttonPressed == -1)
                {
                    
                    buttonString();  //generate the string
                    sql = "Update dbo.slimline_install_quote SET " + sqlButton +" WHERE id = " + quoteNumber;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                   // MessageBox.Show(sqlButton);
                }
                if (updateMiles == -1)
                {
                    sql = "UPDATE dbo.slimline_install_quote SET mileage_one_way = '" + txtMiles.Text + "', site_visits = '" + txtVisits.Text + "',total_mileage = '" + txtTotalMiles.Text + "', london = " + Convert.ToInt32(chkLondon.Checked).ToString() + " WHERE id = " + quoteNumber.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                    updateMiles = -1;
                }
                ////now update every line item
                if (buttonPressed == -1)
                {
                    sql = "UPDATE dbo.slimline_install_door SET " + sqlButton + " WHERE quote_id = " + quoteNumber;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                    //MessageBox.Show(sqlButton);
                    buttonPressed = 0;
                }
                loaddgv(); //also need to recalculate the maths on this..

                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    calculations calculations = new calculations();
                    calculations.getValue(Convert.ToInt32(dgvItems.Rows[i].Cells[0].Value));
                    double temp = Convert.ToDouble(calculations._totalValue.ToString());
                    // * this by the qty
                    temp = temp * Convert.ToDouble(dgvItems.Rows[i].Cells[13].Value.ToString());
                    sql = "UPDATE dbo.slimline_install_door SET total_value = " + temp + " WHERE id = " + dgvItems.Rows[i].Cells[0].Value.ToString();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }

                // i think a loaddgv here will stop it from not adding correct value
                loaddgv();


                //i think we also need to update the sumTotal of quote while we are here...
                double sumTotal = 0;
                for (int i = 0; i < dgvItems.Rows.Count; i++)
                {
                    if (Convert.ToString(dgvItems.Rows[i].Cells[15].Value) != "")
                    {
                        string temp = Convert.ToString(dgvItems.Rows[i].Cells[15].Value);
                        temp = temp.Substring(1, temp.Length - 1);
                        sumTotal = sumTotal + Convert.ToDouble(temp);
                    }
                }
                if (sumTotal > 0)
                {
                    sql = "UPDATE dbo.slimline_install_quote SET sumTotal = " + sumTotal + "WHERE id = " + quoteNumber;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
                loaddgv();
            }
        }

        private void btnFreeNotes_Click(object sender, EventArgs e)
        {
            frmFreeHandNote frm = new frmFreeHandNote(quoteNumber);
            frm.ShowDialog();

            string sql = "SELECT free_hand_note FROM dbo.slimline_install_quote WHERE id = " + quoteNumber.ToString(); //this updates it realquick
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    string text = "";
                    var getData = Convert.ToString(cmd.ExecuteScalar());
                    if (getData != null)
                        text = getData;
                    txtHiddenBox.Text = text;
                }
                conn.Close();
            }
        }

        private void calculate_mileage()
        {
            //make sure data is commited 
            updateLineItems();
            //loop through each 
            double mileageValue = 0;
            //foreach (DataGridViewRow row in dgvItems.Rows)
            //{

            calculations calculations = new calculations();
            calculations.mileage(/*Convert.ToInt32(rowdgvItems.Rows[0].Cells[0].Value),*/quoteNumber); //i dont need to loop through this i think...
            mileageValue = mileageValue + calculations._mileageTotal;

            //}


            //use this figure to update total
            string sql = "UPDATE dbo.slimline_install_quote SET mileage_cost = " + mileageValue.ToString() + "WHERE id = " + quoteNumber.ToString();
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

