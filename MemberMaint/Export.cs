using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using SQLite;
/*
 Export.cs - visual studio windows form progam to load a csv (delimited text file) From Members 
          an SQLite database datatable.
        (NuGet package VS 1.6.258-beta by Frank A. Krueger)
        07 07 2017 by Michael Riley
        creates a csv file used by Inport.cs in the same system (delimit character '~' rather than ',')
*/
namespace MemberMaint
{
    public partial class Export : Form
    {
        Constants var = new Constants();
        SQLiteConnection getMemb;
        List<Member> select;        //Specify Generic list as Member
        private StreamWriter sw;
        public Export()
        {
            InitializeComponent();
            try
            {
                string checkuser = "SELECT * FROM Members ORDER BY 'LastName'";
                getMemb = new SQLiteConnection(var.dbPath());
                select = getMemb.Query<Member>(checkuser);
                sw = new StreamWriter(var.csvpath());
                txtDbcount.Text = select.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "77 Error Message");
            }
        }
        string Savedata(string fldtxt)          //format insert delimiters and edit data characters that would cause trouble
        {
            string fldwork = "";
            fldwork += fldtxt + "~";//0
            fldwork.Replace("\n", "");
            fldwork.Replace("\r", " ");
            fldwork.Replace("'", "`");
            return fldwork;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            string writedata = "";
            int counter = 0;
            for (int x = 0; x < select.Count; x++)
            {
                writedata = Savedata(select[x].LastName);//00
                writedata += Savedata(select[x].FullName);//01
                writedata += Savedata(select[x].Phone);//02
                writedata += Savedata(select[x].Address);//03
                writedata += Savedata(select[x].Email);//04
                writedata += Savedata(select[x].HousePhone);//05
                writedata += Savedata(select[x].Status);//06
                writedata += Savedata(select[x].PersonalStatus);//07
                writedata += Savedata(select[x].firstGroup);//08
                writedata += Savedata(select[x].secondGroup);//09
                writedata += Savedata(select[x].thirdGroup);//10
                writedata += Savedata(select[x].ADanniverDDD);//11
                writedata += Savedata(select[x].ADanniver);//12
                writedata += Savedata(select[x].ADmemberSinceDDD);//13
                writedata += Savedata(select[x].ADmemberSince);//14
                writedata += Savedata(select[x].ADBdateDDD);// 15
                writedata += Savedata(select[x].ADBdate);// 16
                writedata += Savedata(select[x].MilitaryGroup);//17
                writedata += Savedata(select[x].Occupation);//18
                writedata += Savedata(select[x].Cooking);//19
                writedata += Savedata(select[x].TreeCutting);//20
                writedata += Savedata(select[x].AutoMechanic);//21
                writedata += Savedata(select[x].PublicSpeaking);//22
                writedata += Savedata(select[x].ChildAdultCare);//23
                writedata += Savedata(select[x].Nursing);//24
                writedata += Savedata(select[x].Driver);//25
                writedata += Savedata(select[x].FoodService);//26
                writedata += Savedata(select[x].LawnCare);//27
                writedata += Savedata(select[x].ElectricalWiring);//28
                writedata += Savedata(select[x].MathTutoring);//30
                writedata += Savedata(select[x].SpanishTranslation);//31
                writedata += Savedata(select[x].GermanTranslation);//32
                writedata += Savedata(select[x].EnglishTutoring);//33
                writedata += Savedata(select[x].Pianoist);//34
                writedata += Savedata(select[x].Soloist);//35
                writedata += Savedata(select[x].Carpenter);//36
                writedata += Savedata(select[x].Plumbing);//37
                writedata += Savedata(select[x].HeatAir);//38
                writedata += Savedata(select[x].Locksmith);//39
                writedata += Savedata(select[x].HouseCleaning);//40
                writedata += Savedata(select[x].AircraftPilot);//41
                writedata += Savedata(select[x].AircraftOwner);//24
                writedata += Savedata(select[x].Organist);//43
                writedata += Savedata(select[x].TeenMinistries);//44
                writedata += Savedata(select[x].YouthMinistries);//45
                writedata += Savedata(select[x].AudioVideo);//46
                writedata += Savedata(select[x].ComputerGeek);//48
                writedata += Savedata(select[x].SexGender);//49
                writedata += Savedata(select[x].LastUserChange);//49
                writedata += Savedata(select[x].dateLastChange);//49
                sw.WriteLine(writedata);
                counter++;
            }
            sw.Close();
            txtExpcount.Text = counter.ToString();
        }
    }
}

