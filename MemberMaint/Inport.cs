using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using SQLite;
/*
 INPORT - visual studio windows form progam to load from a csv (delimited text file) into 
          an SQLite database.
        (NuGet package VS 1.6.258-beta by Frank A. Krueger)
        07 07 2017 by Michael Riley
        uses a csv file created by EXPORT in the same system delimit character '~' rather than ','
     */
namespace MemberMaint
{
    public partial class Inport : Form
    {
        Constants var = new Constants(); 
        public int ALREADYRUN = 0;
        SQLiteConnection putMemb;
        List<Member> selectall;
        public Inport()
        {
            InitializeComponent();
            putMemb = new SQLiteConnection(var.dbPath());
        }
        private void btnStartInp_Click(object sender, EventArgs e)
        {
            string sqldeleteMemberTable = "DROP TABLE Members ";
            try
            {
                selectall = putMemb.Query<Member>(sqldeleteMemberTable);  //scratch table named Members
                putMemb.CreateTable<Member>();                            //create table named Member
            }
            catch (Exception)
            {
                //ignor exception
            }
            lablCount.Text = getComma().ToString();
            lablCount.Visible = true;
        }
        private int getComma()
        {
            int counter = 0;
            string line;
            try
            {
                string insertQuery = "INSERT INTO Members (LastName,FullName,Phone,Address,Email,HousePhone," +
                    "Status,PersonalStatus,firstGroup,secondGroup,thirdGroup," +
                    "ADanniverDDD," +
                    "ADanniver," +
                    "ADmemberSinceDDD," +
                    "ADmemberSince," +
                    "ADBdateDDD," +
                    "ADBdate," +
                    "MilitaryGroup,Occupation," +
                    "Cooking,TreeCutting,AutoMechanic,PublicSpeaking,ChildAdultCare,Nursing,Driver,FoodService,LawnCare," +
                    "ElectricalWiring,MathTutoring,SpanishTranslation,GermanTranslation,EnglishTutoring,Pianoist,Soloist," +
                    "Carpenter,Plumbing,HeatAir,Locksmith,HouseCleaning,AirCraftPilot,AircraftOwner,Organist,TeenMinistries," +
                    "YouthMinistries,AudioVideo,ComputerGeek,SexGender,LastUserChange,dateLastChange)";
                string testpath = var.csvpath();
                System.IO.StreamReader file = new System.IO.StreamReader(var.csvpath());
                string writrec = "";
                //  System.IO.StreamReader file = new System.IO.StreamReader(@"C:\\SQLiteProjects\\WalkingFingersSQLite\\WalkingFingersSQLite\\commaLoad.csv");
                while ((line = file.ReadLine()) != null)
                {
                    writrec = " VALUES (";
                    string[] temp = line.Split('~');
                    int y = temp.Count();
                    for (int x = 0; x < (y - 1); x++)
                    {
                        if (x != 0)
                        {
                            writrec += " ,'" + temp[x] + "'";
                        }
                        else
                        {
                            writrec += "'" + temp[x] + "'";
                        }
                        string test = temp[x];
                    }
                    writrec += ")";
                    writrec = insertQuery + writrec;
                    putMemb.Query<Member>(writrec);
                    counter++;
                }
                file.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return counter;
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
