//namespace SQLmemberMaint
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using SQLite;
using System.Net.Http;
/*
 addMember.cs - visual studio windows form progam Create Read Update and Delete individual Members from Member database
        SQLite database.
        (NuGet package VS 1.6.258-beta by Frank A. Krueger)
        07 07 2017 by Michael Riley
        uses a csv file created by EXPORT in the same system delimit character '~' rather than ','
     */

namespace MemberMaint
{
    public partial class addMember : Form
    {
        Constants var = new Constants();
        string user;////
        SQLiteConnection getMemb;
        List<Member> select;        //Specify Generic list as Member
        String Passedparm = "0";
        string SavedFullName = "";
        string SavedLastName = "";
        string bdateDOY, adateDOY, mdateDOY, bdateYear, adateYear, mdateYear;
        int searchMonth, searchDay, searchYear;
        bool change = false;
        public addMember(int idvalue, string usid)
        {
            InitializeComponent();
            Passedparm = idvalue.ToString();
            user = usid;
            this.Text = "AddMember  *** Current user is " + usid.Trim() + " ***";
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            getMemb = new SQLiteConnection(var.dbPath());
            getEditTime();
            FillDropDown();
            Retrievedata();
        }
        private void Retrievedata()
        {
            if (Passedparm == "0")  //1st time use
            {
                btnSaveChanges.Visible = false;
                btnDeleteMember.Visible = false;
                SavedFullName = "xxxx";
                return;
            }
            else
            {
                btnDeleteMember.Visible = true;
                btnSaveChanges.Visible = true;
            }
            string MemberSelect = "SELECT * FROM Members WHERE Id = '" + Passedparm + "'";
            select = getMemb.Query<Member>(MemberSelect);
            txtLastName.Text = select[0].LastName;
            SavedLastName = txtLastName.Text;
            txtAddress.Text = select[0].Address;
            txtEmail.Text = select[0].Email;
            txtFullName.Text = select[0].FullName;
            string imageID = "";
            string imagetext = select[0].FullName;
            imagetext.Trim();
            imageID = imagetext.Replace(" ", "_") + ".jpg";
            imageID = imageID.ToLower();
            imageID = var.imagetargetpath + imageID;
            string Sex = select[0].SexGender;
            string Sexper = select[0].PersonalStatus;
            try
            {
                loadPicbox(pictureBox1, imageID, 0);
            }
            catch (Exception ex)
            {
                imageID = "";
                if (Sex.Contains("M") || Sexper.Contains("M"))
                {
                    imageID = var.imagesource + "aaman.jpg";
                }
                else
                {
                    imageID = var.imagesource + "aawomen.jpg";
                }

                pictureBox1.Image = Image.FromFile(@imageID);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();

            SavedFullName = txtFullName.Text;
            cbxPstatus.Text = select[0].PersonalStatus;
            txtPhone.Text = select[0].Phone;
            txtHousePhone.Text = select[0].HousePhone;
            cbxMStatus.Text = select[0].Status;
            cmbGroup1.Text = select[0].firstGroup;
            cmbGroup2.Text = select[0].secondGroup;
            cmbGroup3.Text = select[0].thirdGroup;

            bdateDOY = select[0].ADBdateDDD;
            setdates(txtBdateMM, txtBdateDD, bdateDOY);
            bdateYear = select[0].ADBdate;

            adateDOY = select[0].ADanniverDDD;
            setdates(txtAnniversaryMM, txtAnniversaryDD, adateDOY);
            adateYear = select[0].ADanniver;

            mdateDOY = select[0].ADmemberSinceDDD;
            setdates(txtMemberSinceMM, txtMemberSinceDD, mdateDOY);
            mdateYear = select[0].ADmemberSince;
            txtFirstName.Text = setfirstName(select[0].FullName);
            txtBdateYYYY.Text = bdateYear;
            txtAnniversaryYYYY.Text = adateYear;
            txtMemberSinceYYYY.Text = mdateYear;
            txtSEX.Text = select[0].SexGender.ToUpper();
            cmbMilitary.Text = select[0].MilitaryGroup;
            txtOccuoation.Text = select[0].Occupation;
            checkBox1.Checked = check(select[0].Cooking);
            checkBox2.Checked = check(select[0].TreeCutting);
            checkBox3.Checked = check(select[0].AutoMechanic);
            checkBox4.Checked = check(select[0].PublicSpeaking);
            checkBox5.Checked = check(select[0].ChildAdultCare);
            checkBox6.Checked = check(select[0].Nursing);
            checkBox7.Checked = check(select[0].Driver);
            checkBox8.Checked = check(select[0].FoodService);
            checkBox9.Checked = check(select[0].LawnCare);
            checkBox10.Checked = check(select[0].ElectricalWiring);
            checkBox11.Checked = check(select[0].MathTutoring);
            checkBox13.Checked = check(select[0].SpanishTranslation);
            checkBox14.Checked = check(select[0].GermanTranslation);
            checkBox15.Checked = check(select[0].EnglishTutoring);
            checkBox16.Checked = check(select[0].Pianoist);
            checkBox17.Checked = check(select[0].Soloist);
            checkBox18.Checked = check(select[0].Carpenter);
            checkBox19.Checked = check(select[0].Plumbing);
            checkBox20.Checked = check(select[0].HeatAir);
            checkBox21.Checked = check(select[0].Locksmith);
            checkBox22.Checked = check(select[0].HouseCleaning);
            checkBox23.Checked = check(select[0].AircraftPilot);
            checkBox24.Checked = check(select[0].AircraftOwner);
            checkBox25.Checked = check(select[0].Organist);
            checkBox26.Checked = check(select[0].TeenMinistries);
            checkBox27.Checked = check(select[0].YouthMinistries);
            checkBox28.Checked = check(select[0].AudioVideo);
            checkBox29.Checked = check(select[0].ComputerGeek);
            labUser.Text = select[0].LastUserChange;
            labTime.Text = select[0].dateLastChange;
            change = false;
        }
        private string setfirstName(string longName)
        {
            string wrkstr = "";
            string[] lines = longName.Split(' ');
            int count = longName.Split(' ').Length;
            for (int n = 0; n < count - 1; n++)
            {
                wrkstr += lines[n] + " ";
            }
            return wrkstr;
        }

        private void setdates(TextBox mth, TextBox DD, string doy)            //given the Day of Year return txtbox mont and day
        {
            if (doy.Length != 0)                                              //if string value is available
            {
                int serDOY = Convert.ToInt32(doy);
                DateTime current = new DateTime();
                int serYear = current.Year;
                DateTime theDate = new DateTime(serYear, 1, 1).AddDays(serDOY - 1);
                mth.Text = theDate.Month.ToString();
                DD.Text = theDate.Day.ToString();
            }
        }
        private string setDDD(TextBox dateMM, TextBox dateDD, TextBox dateYYYY)   // date routine to use textboxes with mm dd yy
        {                                                                       // and return text day of year
            string DDD = "";
            string MM = dateMM.Text.Trim();
            string DD = dateDD.Text.Trim();
            string YYYY = dateYYYY.Text.Trim();
            if ((MM.Length != 0) && (dateDD.Text.Length != 0))
            {
                int serYear, serMM, serDD;
                if (YYYY.Length == 0)
                {
                    serYear = 1999;      //any non leap year will work
                }
                else
                {
                    serYear = Convert.ToInt32(dateYYYY.Text);
                }
                serMM = Convert.ToInt32(dateMM.Text);
                serDD = Convert.ToInt32(dateDD.Text);
                DateTime theDate = new DateTime(serYear, serMM, serDD);  //process for day of year
                DDD = theDate.DayOfYear.ToString();                      //return day of Year as text 
            }
            return DDD;
        }
        private bool check(string type)
        {
            if ((type == "") || (type == "False"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void loadPicbox(PictureBox pxbx, string imgloc, int row)
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
                if (select[row].SexGender.Contains("M"))                          //select the appropriate man/woman symbol
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
            pxbx.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {//btnsaveChanges click
            if (SavedLastName.Trim() == txtLastName.Text.Trim())
            {
                editadd("Edit");
                this.Close();
            }
            else
            {
                MessageBox.Show("You Must Edit Full Name for a New Member");//btnSaveChanges
            }
        }
        private void btnAddChangeImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fop = new OpenFileDialog();
                fop.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files(*.*)|*.*";
                //   fop.FileName = "";
                fop.Title = "Select Member Photo";
                fop.InitialDirectory = var.imagesource;
                // fop.RestoreDirectory = true;
                if (fop.ShowDialog() == DialogResult.OK)
                {

                    string oldName = fop.FileName;
                    string newName = select[0].FullName.Trim();
                    newName = select[0].FullName.Replace(" ", "_") + ".jpg";
                    newName = var.imagetargetpath + newName;
                    try
                    {
                        File.Copy(oldName, newName, true);
                    }
                    catch (Exception)
                    {
                        File.Delete(newName);
                        File.Copy(oldName, newName, true);
                    }
                    loadPicbox(pictureBox1, newName, 0);
                    MessageBox.Show("Sucessfully updated  Member record image", "save image");
                }
                else
                {
                    MessageBox.Show("Please Select a Image to save!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
        void FillDropDown()
        {
            cmbGroup1.Items.Clear();
            cmbGroup2.Items.Clear();
            cmbGroup3.Items.Clear();
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
            for (int g = 0; g < Groups.Count; g++)
            {
                if (savegroup != Groups[g])
                {
                    if (Groups[g] != "")
                    {
                        savegroup = Groups[g];
                        cmbGroup1.Items.Add(Groups[g]);
                        cmbGroup2.Items.Add(Groups[g]);
                        cmbGroup3.Items.Add(Groups[g]);
                    }
                }
            }
            cbxMStatus.Items.Clear();
            try
            {
                string statQuery = "SELECT DISTINCT Status FROM Members ORDER by Status";
                select = getMemb.Query<Member>(statQuery);
                for (int n = 0; n < select.Count; n++)
                {
                    string txt = select[n].Status.Trim();
                    if (txt.Length != 0)
                    {
                        cbxMStatus.Items.Add(txt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "line 283 load status Message");
            }
            cbxMStatus.Text = "";
            cbxPstatus.Items.Clear();
            try
            {
                string statQuery = "SELECT DISTINCT PersonalStatus FROM Members ORDER by PersonalStatus";
                select = getMemb.Query<Member>(statQuery);
                for (int n = 0; n < select.Count; n++)
                {
                    string txt = select[n].PersonalStatus.Trim();
                    if (txt.Length != 0)
                    {
                        cbxPstatus.Items.Add(txt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "line 283 load status Message");
            }
            cbxPstatus.Text = "";
        }
        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            string deleteMember = "DELETE FROM Members WHERE Id = '" + Passedparm + "'";//id appended";
            if (Passedparm != "0")
            {
                try
                {
                    select = getMemb.Query<Member>(deleteMember);
                    MessageBox.Show("Deleted sucessfully");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message");
                }//'or'x'='x
            }
            else
            {
                MessageBox.Show("No Member selected to Delete !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnNewMember_Click(object sender, EventArgs e)
        {
            change = false;
            select = getMemb.Query<Member>("Select * Members WHERE FullName = '" + txtFullName.Text + "'");  //must be unique full name
            if (select.Count >= 1)
            {
                MessageBox.Show("Found a member with the same full name");
            }
            else
            {
                editadd("Add");
                MessageBox.Show("New Member " + txtFullName.Text + " added, ", "add a new member");
                btnNewMember.Visible = false;
                btnDeleteMember.Visible = true;
                btnSaveChanges.Visible = true;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (change == true)
            {
                DialogResult result = MessageBox.Show(this, "UN-SAVED changes present ", "Abandon CHANGES and Exit ?",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }
            this.Close();
        }
        private void txtBdateYYYY_TextChanged(object sender, EventArgs e)
        {
            txtAge.Text = setAges(txtBdateMM.Text, txtBdateDD.Text, txtBdateYYYY.Text);
            txtMarriedFor.Text = setAges(txtAnniversaryMM.Text, txtAnniversaryDD.Text, txtAnniversaryYYYY.Text);
            txtMembFor.Text = setAges(txtMemberSinceMM.Text, txtMemberSinceDD.Text, txtMemberSinceYYYY.Text);
            change = true;
        }
        private string setAges(string boxMM, string boxDD, string boxYYYY)
        {
            int age = 0;
            string tstYear = boxYYYY.Trim();
            string tstMM = boxMM.Trim();
            string tstdd = boxDD.Trim();
            if (tstYear.Length == 0) return "";
            try
            {
                searchMonth = searchDay = searchYear = 0;
                if (tstMM.Length != 0) searchMonth = Convert.ToInt32(tstMM);
                if (tstdd.Length != 0) searchDay = Convert.ToInt32(tstdd);
                if (tstYear.Length != 0) searchYear = Convert.ToInt32(tstYear);
                if ((searchYear != 0) && (searchDay != 0) && (searchMonth != 0))
                {
                    DateTime dob = new DateTime(searchYear, searchMonth, searchDay);
                    age = DateTime.Now.Year - dob.Year;
                    if (DateTime.Now.DayOfYear < dob.DayOfYear)
                        age = age - 1;
                    panAgeStat.Visible = true;
                }
                if (age == 0) return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error calculating age");
            }
            return age.ToString();
        }
        private Tuple<int, int> setJoulDay(string boxMM, string boxDD, string boxYYYY)
        {
            int Julian = 0;
            int JulianDay = 0;
            searchMonth = searchDay = searchYear = 0;
            if (boxMM.Trim() != "") searchMonth = Convert.ToInt32(boxMM.Trim());
            if (boxDD.Trim() != "") searchDay = Convert.ToInt32(boxDD.Trim());
            if (boxYYYY.Trim() != "")
            {
                searchYear = Convert.ToInt32(boxYYYY.Trim());
            }
            else
            {
                searchYear = 1;
            }
            if (searchMonth != 0 && searchDay != 0)
            {
                DateTime dt = new DateTime(searchYear, searchMonth, searchDay);
                JulianDay = dt.DayOfYear;        //use fake Julian for sql compai  
                Julian = dt.Year * 1000 + dt.DayOfYear;
            }
            return new Tuple<int, int>(Julian, JulianDay);
        }
        void editadd(string Mode)  //valid Modes are Edit or Add
        {
            if (Mode == "Add")  // if not just assume Edit
            {// this is complicated.. insert with full name = #### then get it back and get the id then treat like an EDIT
                string query = "INSERT INTO Members " +
                        "(FullName,LastName) VALUES ('" + txtFullName.Text + "', '####')";
                string query1 = "SELECT * FROM Members WHERE ((LastName == '####') and (FullName == '" + txtFullName.Text + "'))";
                getMemb.Query<Member>(query);         //Insert the new record
                select = getMemb.Query<Member>(query1);       //get it back to get Id     
                Passedparm = select[0].Id.ToString();
            }
            try
            {
                string updateQ = getupdateQuery();
                getMemb.Query<Member>(updateQ);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Line 469 ERROR Updateing record");
            }
        }
        private string getupdateQuery()
        {
            string upd = "UPDATE Members SET LastName = '" + txtLastName.Text + "', "
                                  + "  FullName = '" + txtFullName.Text + "', "//01
                                  + "  Phone = '" + txtPhone.Text + "', " //02
                                  + "  Address = '" + txtAddress.Text + "', "//03
                                  + "  Email = '" + txtEmail.Text + "', "//04
                                  + "  HousePhone = '" + txtHousePhone.Text + "', "  //05
                                  + "  Status = '" + cbxMStatus.Text + "', "//06
                                  + "  PersonalStatus = '" + cbxPstatus.Text + "', "//07
                                  + "  firstGroup = '" + cmbGroup1.Text + "', "//08
                                  + "  secondGroup = '" + cmbGroup2.Text + "', "//09
                                  + "  thirdGroup = '" + cmbGroup3.Text + "', "//10
                                  + "  ADBdate = '" + txtBdateYYYY.Text + "', "
                                  + "  ADBdateDDD = '" + setDDD(txtBdateMM, txtBdateDD, txtBdateYYYY) + "', "
                                  + "  ADanniver = '" + txtAnniversaryYYYY.Text + "', "
                                  + "  ADanniverDDD = '" + setDDD(txtAnniversaryMM, txtAnniversaryDD, txtAnniversaryYYYY) + "', "
                                  + "  ADmemberSince = '" + txtMemberSinceYYYY.Text + "', "
                                  + "  ADmemberSinceDDD = '" + setDDD(txtMemberSinceMM, txtMemberSinceDD, txtMemberSinceYYYY) + "', "
                                  + "  Cooking = '" + ckbxval(checkBox1) + "', " //30
                                  + "  TreeCutting = '" + ckbxval(checkBox2) + "', " //31
                                  + "  AutoMechanic = '" + ckbxval(checkBox3) + "', " //32
                                  + "  PublicSpeaking = '" + ckbxval(checkBox4) + "', " //33
                                  + "  ChildAdultCare = '" + ckbxval(checkBox5) + "', "//34
                                  + "  Nursing = '" + ckbxval(checkBox6) + "', "//35
                                  + "  Driver = '" + ckbxval(checkBox7) + "', "//36
                                  + "  FoodService = '" + ckbxval(checkBox8) + "', "//37
                                  + "  LawnCare = '" + ckbxval(checkBox9) + "', "//38
                                  + "  ElectricalWiring = '" + ckbxval(checkBox10) + "', "//39
                                  + "  MathTutoring = '" + ckbxval(checkBox11) + "', "//40 no checkbox 12
                                  + "  SpanishTranslation = '" + ckbxval(checkBox13) + "', "//41
                                  + "  GermanTranslation = '" + ckbxval(checkBox14) + "', "//42
                                  + "  EnglishTutoring = '" + ckbxval(checkBox15) + "', "//43
                                  + "  Pianoist = '" + ckbxval(checkBox16) + "', "//44
                                  + "  Soloist = '" + ckbxval(checkBox17) + "', "//45
                                  + "  Carpenter = '" + ckbxval(checkBox18) + "', "//46
                                  + "  Plumbing = '" + ckbxval(checkBox19) + "', "//47
                                  + "  HeatAir = '" + ckbxval(checkBox20) + "', "//48
                                  + "  Locksmith = '" + ckbxval(checkBox21) + "', "//49
                                  + "  HouseCleaning = '" + ckbxval(checkBox22) + "', "//50
                                  + "  AircraftPilot = '" + ckbxval(checkBox23) + "', "//51
                                  + "  AircraftOwner = '" + ckbxval(checkBox24) + "', "//52
                                  + "  Organist = '" + ckbxval(checkBox25) + "', "//53
                                  + "  TeenMinistries = '" + ckbxval(checkBox26) + "', "//54
                                  + "  YouthMinistries = '" + ckbxval(checkBox27) + "', "//55
                                  + "  AudioVideo = '" + ckbxval(checkBox28) + "', "//56
                                  + "  ComputerGeek = '" + ckbxval(checkBox29) + "', "//57 sb 29
                                  + "  SexGender = '" + txtSEX.Text.ToUpper() + "', " //58
                                  + "  MilitaryGroup = '" + cmbMilitary.Text + "', "  //28
                                  + "  Occupation = '" + txtOccuoation.Text + "',"//29  
                                  + "  LastUserChange = '" + user + "', "//29  
                                  + "  dateLastChange = '" + getEditTime() + "'"//29  
                                  + " WHERE Id = '" + Passedparm.ToString() + "'";
            return upd;
        }
        private string getEditTime()
        {
            string currentTIME = "";
            currentTIME = DateTime.Now.ToLocalTime().ToString();
            return currentTIME;
        }
        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            txtFullName.Text = UppercaseWords(txtFirstName.Text) + " " + UppercaseWords(txtLastName.Text); ;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFirstName_MouseLeave(object sender, EventArgs e)
        {
            txtFirstName.Text = UppercaseWords(txtFirstName.Text);
        }

        private string ckbxval(CheckBox ckbx)
        {
            string rtnval;
            if (ckbx.Checked)
            {
                rtnval = "True";
            }
            else
            {
                rtnval = "False";
            }
            return rtnval;
        }
        private void txtLastName_MouseClick(object sender, MouseEventArgs e)
        {
            txtLastName.Text = UppercaseWords(txtLastName.Text);
            txtFirstName.Text = UppercaseWords(txtFirstName.Text);
            txtFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
            clearchkboxes();
            // txtFullName.Focus();
            btnSaveChanges.Visible = false;
            btnDeleteMember.Visible = false;
            btnNewMember.Visible = true;
        }
        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] <= ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            txtFullName.Text = UppercaseWords(txtFullName.Text);
        }

        private void btnDeltPict_Click(object sender, EventArgs e)
        {
            string newName = select[0].FullName.Trim();
            newName = select[0].FullName.Replace(" ", "_") + ".jpg";
            newName = var.imagetargetpath + newName;
            File.Delete(newName);
            loadPicbox(pictureBox1, newName, 0);                //won't find it and will show generic man woman
        }
        private void button3_Click(object sender, EventArgs e)
        {//   clear data fields click
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtHousePhone.Text = "";
            clearchkboxes();
        }
        private void clearchkboxes()        //on a new member clear fields that may not be correct for new menmber
        {
            txtEmail.Text = "";
            txtOccuoation.Text = "";
            txtMemberSinceDD.Text = "";
            txtMemberSinceMM.Text = "";
            txtMemberSinceYYYY.Text = "";
            cbxPstatus.Text = "";
            cbxMStatus.Text = "";
            cmbGroup1.Text = "";
            cmbGroup2.Text = "";
            cmbGroup3.Text = "";
            txtAnniversaryDD.Text = "";
            txtAnniversaryMM.Text = "";
            txtAnniversaryYYYY.Text = "";
            txtBdateDD.Text = "";
            txtBdateMM.Text = "";
            txtBdateYYYY.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox13.Checked = false;   //no 12
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox23.Checked = false;
            checkBox24.Checked = false;
            checkBox25.Checked = false;
            checkBox26.Checked = false;
            checkBox27.Checked = false;
            checkBox28.Checked = false;
            checkBox29.Checked = false;
        }
    }
}
