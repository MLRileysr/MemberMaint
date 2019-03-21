using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using SQLite;
/*
 SQLmemberMaint - 03/13/2019 Michael Riley ---Windows Desktop (Windows Form App)(.Net Framework)
 Uses NuGet package sqlite-net-pcl by Frank A Fruger    
 provides ability to create read update & delete database Member records    
     
     
*/

namespace MemberMaint
{
    public partial class StartDispAll : Form
    {
        Constants var = new Constants();
        public string SQLstring { get; set; }  //used to passback a query string from SkillSearch.cs 
        SQLiteConnection getMemb;
        List<Member> select;        //Specify Generic list of Members as Member
        DateTimePicker dt = new DateTimePicker();
        DateTimePicker dt1 = new DateTimePicker();
        int lowsearchDay, lowsearchMonth, lowsearchYear;
        int hisearchDay, hisearchMonth, hisearchYear;
        int hiJulianYear, LowJulianYear, lowJulian, hiJulian;
        string srchtype = "";
        int Lastsearch = 0;
        int Nsearch = -1;
        int Psearch = 1;
        int Ssearch = 2;
        int Gsearch = 3;
        int bdatesrch = 4;
        int Annivsrch = 5;
        int MbrSearch = 6;
        int dispName = 7;
        int Militarysrch = 8;
        int picperRow, tab;
        int displaytab, displayverttab;
        int cellwidth = 130;
        string searchtxt = "";
        string query;
        string UserSignedOn;
        public StartDispAll()
        {
            LogIn frm = new LogIn();
            frm.ShowDialog();
            UserSignedOn = frm.CurrentUser;
            if (UserSignedOn == null) UserSignedOn = "";
            if (UserSignedOn.Trim() == "")
            {
                Application.Exit();//  Close();
                this.Close();
            }
            else
            {
                InitializeComponent();
            }
            Lastsearch = dispName;
            Mainloop();
        }
        private void Mainloop()
        {    // first create/open the database (name & location comes from dbPath in varibles)
            getMemb = new SQLiteConnection(var.dbPath());
            getMemb.CreateTable<Member>();
            this.Text = "  DisplayALL     ***Current user is " + UserSignedOn.Trim() + " * **";
            clearview();
            fillDrop();
            searchtxt = "";
            refreshDisp();
        }
        private void refreshDisp()
        {
            if (Lastsearch == dispName) DisplayNameSearch();
            filldataGrid();
        }
        private void fillDrop()
        {
            string Member1group = "SELECT DISTINCT firstGroup FROM Members ";
            string Member2group = "SELECT DISTINCT secondGroup FROM Members ";
            string Member3group = "SELECT DISTINCT thirdGroup FROM Members ";
            //getMemb = new SQLiteConnection(Variables.dbPath());
            select = getMemb.Query<Member>(Member1group);
            List<string> Groups = new List<string>();
            for (int g = 0; g < select.Count; g++)
            {
                Groups.Add(select[g].firstGroup);
            }
            select = getMemb.Query<Member>(Member2group);
            for (int g = 0; g < select.Count; g++)
            {
                Groups.Add(select[g].secondGroup);
            }
            select = getMemb.Query<Member>(Member3group);
            for (int g = 0; g < select.Count; g++)
            {
                Groups.Add(select[g].thirdGroup);
            }
            Groups.Sort();
            string savegroup = "";
            cmbGroup.Items.Clear();
            for (int g = 0; g < Groups.Count; g++)
            {
                if (savegroup != Groups[g])
                {
                    Groups[g].Trim();
                    if (Groups[g].Length != 0)
                    {
                        savegroup = Groups[g];
                        cmbGroup.Items.Add(Groups[g]);
                    }
                }
            }
            cmbGroup.Text = "";
            cmbStatus.Items.Clear();
            try
            {
                string statQuery = "SELECT DISTINCT Status FROM Members ORDER by Status";
                select = getMemb.Query<Member>(statQuery);
                for (int n = 0; n < select.Count; n++)
                {
                    string txt = select[n].Status.Trim();
                    if (txt.Length != 0)
                    {
                        cmbStatus.Items.Add(txt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "line 125 load status Message");
            }
            cmbStatus.Text = "";
            cmbMilitary.Items.Clear();
            try
            {
                string militaryQuery = "SELECT DISTINCT MilitaryGroup FROM Members ORDER by MilitaryGroup";
                select = getMemb.Query<Member>(militaryQuery);
                for (int n = 0; n < select.Count; n++)
                {
                    string txt = select[n].MilitaryGroup.Trim();
                    if (txt.Length != 0)
                    {
                        cmbMilitary.Items.Add(txt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "line 140 Military Group");
            }
            cmbMilitary.Text = "";
            cmbPstatus.Items.Clear();
            try
            {
                string PQuery = "SELECT DISTINCT  PersonalStatus FROM Members ORDER by PersonalStatus";
                select = getMemb.Query<Member>(PQuery);
                for (int n = 0; n < select.Count; n++)
                {
                    string txt = select[n].PersonalStatus.Trim();
                    if (txt.Length != 0)
                    {
                        cmbPstatus.Items.Add(txt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "line 157 Personal Status Group");
            }
            cmbPstatus.Text = "";
            searchtxt = "";
        }
        private void cmbPstatus_SelectedIndexChanged(object sender, EventArgs e)
        {   //Personal Status selected
            searchtxt = cmbPstatus.Text;
            txtTitle.Text = "Member Personal status: " + searchtxt;
            cmbPstatus.Text = "";
            clearview();
            query = "SELECT * FROM Members WHERE PersonalStatus = '" + searchtxt + "'";
            Lastsearch = Psearch;
            ShowSearch();
            filldataGrid();
        }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {  //Member status selected
            searchtxt = cmbStatus.Text;
            query = "SELECT * FROM Members WHERE Status = '" + searchtxt + "'";
            clearview();
            Lastsearch = Ssearch;
            txtTitle.Text = "Member Status: " + searchtxt;
            clearview();
            ShowSearch();
            filldataGrid();
        }
        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {  //Group status selected
            searchtxt = cmbGroup.Text;
            txtTitle.Text = "Member Group: " + searchtxt;
            clearview();
            DisplayGStatus();
            filldataGrid();
        }
        private void DisplayGStatus()
        {
            query = "SELECT * FROM Members WHERE ((firstGroup = '" +
                searchtxt + "') || (secondGroup = '" + searchtxt + "') || (thirdGroup = '" +
                searchtxt + "')) Order by FullName";
            Lastsearch = Gsearch;
            ShowSearch();
        }
        private void DisplayNameSearch()
        {
            searchtxt = txtSearch.Text.Trim();
            if (searchtxt.Length == 0)
            {
                query = "SELECT * FROM Members ORDER BY LastName , FullName ";
                txtTitle.Text = " Show all ";
            }
            else
            {
                query = "SELECT * FROM Members WHERE " + srchtype + " LIKE '" + searchtxt + "%' ORDER BY LastName, FullName ";
                txtTitle.Text = srchtype + " " + searchtxt.Trim().ToUpper() + " search ";
            }
            Lastsearch = dispName;
            clearview();
            try
            {
                select = getMemb.Query<Member>(query);
                if ((select.Count == 0) && (searchtxt.Length == 0))
                {
                    Lastsearch = dispName;
                    DialogResult MakeNew = MessageBox.Show("Enter New Members?", "Import From csv file?", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (MakeNew == DialogResult.Yes)
                    {
                        MessageBox.Show("Enter Members", "Member Maintence "); //make new User
                        loadaddMember(0, UserSignedOn);
                    }
                    if (MakeNew == DialogResult.No)
                    {
                        MessageBox.Show("Load from cvs file", "User Maintence "); //make new User
                        EventArgs e = new EventArgs();
                        btnInport_Click(this, e);
                    }
                    if (MakeNew == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ShowSearch()   // search based on lastname
        {
            Lastsearch = Nsearch;
            try
            {
                select = getMemb.Query<Member>(query);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void DisplayStatus()
        {
            clearview();
            Lastsearch = Ssearch;
            ShowSearch();
        }
        private void btnlastSearch_Click(object sender, EventArgs e)
        {  // last name search
            srchtype = "LastName";
            DisplayNameSearch();
            filldataGrid();
        }
        private void clearview()
        {
            cmbPstatus.Text = "";
            cmbStatus.Text = "";
            txtSearch.Text = "";
            cmbGroup.Text = "";
            cmbdate.Text = "";
            cmbMilitary.Text = "";
            cmbdate.Text = "";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {  //first name search
            srchtype = "FullName";
            DisplayNameSearch();
            filldataGrid();
        }
        private void btnSkill_Click(object sender, EventArgs e)
        {
            SkillSearch frm = new SkillSearch(UserSignedOn);
            frm.ShowDialog();
            query = frm.sQLstring;
            string volcheck = frm.vOLstr;
            txtTitle.Text = volcheck + " (skill volunteer search)";
            ShowSearch();
            filldataGrid();
        }
        private void button2_Export(object sender, EventArgs e)
        {
            Export frm = new Export();
            frm.ShowDialog();
        }
        private void btnInport_Click(object sender, EventArgs e)
        {
            Inport frm = new Inport();
            frm.ShowDialog();
            fillDrop();
        }
        private void cmbdate_SelectedIndexChanged(object sender, EventArgs e)
        {   //date selected
            if (cmbdate.Text == "Member Since")
            {
                memSinceSearch();
            }
            else
            {
                panelBday.Visible = true;
            }
        }
        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            anivSearch();
        }
        private void memSinceSearch()
        {
            txtTitle.Text = "Members from longest to most recent";
            Lastsearch = MbrSearch;
            txtTitle.Visible = true;
            query = "SELECT * FROM Members WHERE (ADmemberSince!= '') ORDER by ADmemberSince,ADmemberSinceDDD";
            ShowSearch();
            filldataGrid();
            clearview();
        }
        private void datesetup()
        {

            // DateTimePiker1.Value = new DateTime(2012, 05, 28);
            string[] lines = dateTimePicker1.Value.ToShortDateString().Split('/');
            lowsearchMonth = Convert.ToInt32(lines[0]); //.ToString());
            lowsearchDay = Convert.ToInt32(lines[1]);
            lowsearchYear = Convert.ToInt32(lines[2]);
            lines = dateTimePicker2.Value.ToShortDateString().Split('/');
            hisearchMonth = Convert.ToInt32(lines[0]);
            hisearchDay = Convert.ToInt32(lines[1]);
            hisearchYear = Convert.ToInt32(lines[2]);
            DateTime dt = new DateTime(lowsearchYear, lowsearchMonth, lowsearchDay);
            DateTime dt1 = new DateTime(hisearchYear, hisearchMonth, hisearchDay);
            lines = dt.ToString().Split(' ');
            string temp = lines[0];
            lines = temp.ToString().Split('/');
            temp = lines[0] + "/" + lines[1];
            lines = dt1.ToString().Split(' ');
            string temp1 = lines[0];
            lines = temp1.ToString().Split('/');
            temp1 = lines[0] + "/" + lines[1];
            if (searchtxt == "Birth Date")
            {
                txtTitle.Text = "Birth Days ";
            }
            else
            {
                txtTitle.Text = "Anniversarys ";
            }
            txtTitle.Text += "from " + temp + " to " + temp1;
            txtTitle.Visible = true;
            lowJulian = dt.DayOfYear;
            hiJulian = dt1.DayOfYear;
            if (hisearchYear != lowsearchYear)
            {
                hiJulianYear = hiJulian;
                LowJulianYear = 0;
                hiJulian = 365;
            }
            else
            {
                LowJulianYear = lowJulian;
                hiJulianYear = hiJulian;
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value;
        }
        private void anivSearch()
        {
            panelBday.Visible = false;
            searchtxt = cmbdate.Text;
            cmbdate.Text = "";
            datesetup();
            if (searchtxt == "Birth Date")
            {
                Lastsearch = bdatesrch;
                query = "SELECT * FROM Members WHERE " +
                     " (ADBdateDDD <= '" + hiJulian + "' AND ADBdateDDD >= '" + lowJulian +
                     "' )||(ADBdateDDD <= '" + hiJulianYear + "' AND ADBdateDDD >= '" + LowJulianYear +
                     "') ORDER by ADBdateDDD";
            }
            else
            {
                Lastsearch = Annivsrch;
                query = "SELECT * FROM Members WHERE " +
                     " (ADanniverDDD <= '" + hiJulian + "' AND ADanniverDDD >= '" + lowJulian +
                     "' )||(ADanniverDDD <= '" + hiJulianYear + "' AND ADanniverDDD >= '" + LowJulianYear +
                     "') ORDER by ADanniverDDD";
            }
            ShowSearch();
            filldataGrid();
            panDispClients.Visible = true;
        }
        private void bdaySearch()
        {
            anivSearch();
        }
        private void cmbMilitary_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lastsearch = Militarysrch;
            searchtxt = cmbMilitary.Text;
            txtTitle.Text = "Military Service: " + searchtxt;
            cmbMilitary.Text = "";
            query = "SELECT * FROM Members WHERE MilitaryGroup = '" + searchtxt + "' ORDER BY 'LastName'";
            try
            {
                select = getMemb.Query<Member>(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "796 search Military service Error");
            }
            clearview();
            ShowSearch();
            filldataGrid();
        }
        private void filldataGrid()
        {
            txtTitle.Visible = false;
            panDispClients.Controls.Clear();
            displaytab = 0;
            displayverttab = 15;
            int panwidth = panDispClients.Size.Width;   // get the total panel horizontal space available
                                                        //  panwidth = panwidth - 130;                  // adjust for scroll bar  
            picperRow = panwidth / cellwidth;           // get the count of columns per row
            tab = panwidth / picperRow;                 // get the space avai per col
            tab = tab * picperRow;                      // mult to get the remainder
            tab = panwidth - tab;                       // get remainder  
            tab = tab / (picperRow + 1);                // divide space to arrive at space per col
            if (tab == 0) tab = 13;
            int b = 0;
            txtRecrdCount.Text = select.Count.ToString();
            foreach (Member Record in select)               //fill rest of panel with order data
            {
                if (b < picperRow)                      // count columns to Max
                {
                    displaytab = (b * cellwidth) + tab;
                    //      if (b == 0) displaytab = cellwidth + tab;
                    b++;
                    setdisploc(Record);
                }
                else
                {
                    displaytab = tab;
                    b = 1;
                    displayverttab += 140;          //causes new row
                    setdisploc(Record);
                }
            }//end for each
            txtTitle.Visible = true;
        }
        private void setdisploc(Member rec)       // cell to display at current column & row
        {
            PictureBox dispic = new PictureBox();
            dispic.Location = new Point(displaytab, displayverttab);           //display members picture
            dispic.Size = new System.Drawing.Size(cellwidth - 10, 102);
            boxdisp(dispic, rec);
            dispic.SizeMode = PictureBoxSizeMode.StretchImage;
            panDispClients.Controls.Add(dispic);

            TextBox txtName = new TextBox();                                    //displayed member full name
            txtName.Location = new Point(displaytab, displayverttab + 105);
            txtName.Size = new System.Drawing.Size(cellwidth - 10, 20);
            txtName.BackColor = System.Drawing.Color.FromArgb((192), (255), (192));
            txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtName.Text = rec.FullName + "                             ~" + rec.Id.ToString();
            txtName.TextAlign = HorizontalAlignment.Right;
            txtName.TabStop = false;
            txtName.Click += new EventHandler(dispaddedt);
            panDispClients.Controls.Add(txtName);
        }
        private int boxdisp(PictureBox picbx, Member rrow)
        {
            //  string Sex = rrow.SexGender;
            //  string Sexper = rrow.PersonalStatus;
            string imageID = rrow.FullName.Trim();
            imageID = imageID.Replace(" ", "_") + ".jpg";
            imageID = var.imagetargetpath + imageID;
            loadPicbox(picbx, imageID, rrow);
            int ident = rrow.Id;
            return ident;
        }
        private void dispaddedt(object sender, EventArgs e)
        {
            string cusid = ((TextBox)sender).Text;
            string[] work = cusid.Split('~');
            loadaddMember(Convert.ToInt32(work[1].Trim()), UserSignedOn);
        }
        private void loadaddMember(int recId, string username)
        {
            int XX = panDispClients.VerticalScroll.Value;
            addMember frm1 = new addMember(recId, username);
            frm1.ShowDialog();
            ShowSearch();
            filldataGrid();
            panDispClients.VerticalScroll.Value = XX;
        }
        private void loadPicbox(PictureBox pxbx, string imgloc, Member row)
        {
            FileStream fs;
            StreamContent imageContent;
            string igenericID;
            try
            {
                fs = new FileStream(@imgloc, FileMode.Open, FileAccess.Read);  //if an image exists then use it
                imageContent = new StreamContent(fs);
            }
            catch (Exception)
            {
                if (row.SexGender.Contains("M"))                          //select the appropriate man/woman symbol
                {
                    igenericID = var.imagesource + "aaman.jpg";
                }
                else
                {
                    igenericID = var.imagesource + "aawomen.jpg";
                }
                fs = new FileStream(@igenericID, FileMode.Open, FileAccess.Read);
                imageContent = new StreamContent(fs);
                pxbx.Image = System.Drawing.Image.FromStream(fs);
            }
            pxbx.Image = System.Drawing.Image.FromStream(fs);
            fs.Close();
            imageContent.Dispose();
        }
    }//end of Main Form
}//end of namespace