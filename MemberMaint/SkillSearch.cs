using System;
using System.Windows.Forms;
using System.IO;
using SQLite;

namespace MemberMaint
{
    public partial class SkillSearch : Form
    {
        private string VOLstr;
        public string vOLstr
        {
            get { return VOLstr; }
            set { VOLstr = value; }
        }
        private string SQLstring;                   //
        public string sQLstring                     //
        {                                           // used to pass Sqlstring to DisplayAll.cs
            get { return SQLstring; }               //
            set { SQLstring = value; }              //
        }                                           //
        string UserSignedOn;
        string buildsql;
        string volstr;
        int chkcount = 0;
        public SkillSearch(string userid)
        {
            UserSignedOn = userid;
            InitializeComponent();
            this.Text += "  --- Current logged in user = " + UserSignedOn;
            pnlSkills.Visible = true;
            rbtnOR.Checked = true;
        }
        private void btnStartSkill_Click(object sender, EventArgs e)
        {  //SELECT * FROM   Members WHERE  Cooking == True or TreeCutting = True          
            buildsql = "SELECT * FROM Members WHERE ";
            StartSkill(chkCooking, "Cooking");
            StartSkill(chkTreeCutting, "TreeCutting");
            StartSkill(checkBox3AutoMech, "AutoMechanic");
            StartSkill(checkBox4PublSpeak, "PublicSpeaking");
            StartSkill(checkBox5care, "ChildAdultCare");
            StartSkill(checkBox6nurse, "Nursing");
            StartSkill(checkBox7driver, "Driver");
            StartSkill(checkBox8foodsvc, "FoodService");
            StartSkill(checkBox9lawn, "LawnCare");
            StartSkill(checkBox10Elect, "ElectricalWiring");
            StartSkill(checkBox11Math, "MathTutoring");
            StartSkill(checkBox13Spanish, "SpanishTranslation");
            StartSkill(checkBox14German, "GermanTranslation");
            StartSkill(checkBox15English, "EnglishTutoring");
            StartSkill(checkBox16Pianio, "Pianoist");
            StartSkill(checkBox17Solo, "Soloist");
            StartSkill(checkBox18Carpenter, "Carpenter");
            StartSkill(checkBox19Plum, "Plumbing");
            StartSkill(checkBox20HeatAir, "HeatAir");
            StartSkill(checkBox21Lock, "Locksmith");
            StartSkill(checkBox22House, "HouseCleaning");
            StartSkill(checkBox23Airpilot, "AircraftPilot");
            StartSkill(checkBox24airOwner, "AircraftOwner");
            StartSkill(checkBox25Organ, "Organist");
            StartSkill(checkBox26TeenMin, "TeenMinistries");
            StartSkill(checkBox27Youth, "YouthMinistries");
            StartSkill(checkBox28AudioVideo, "AudioVideo");
            StartSkill(checkBox29Geek, "ComputerGeek");
            if (chkcount == 0)
            {
                MessageBox.Show("You Must check at least one box");
                return;
            }
            vOLstr = volstr;
            sQLstring = buildsql;
            this.Close();
        }
        private void StartSkill(CheckBox Ckbx, string Id)
        {
            if (Ckbx.Checked == true)
            {
                if (chkcount >= 1)
                {
                    if (rbtnOR.Checked)
                    {
                        buildsql += " OR ";
                    }
                    else
                    {
                        buildsql += " AND ";
                    }
                }
                volstr += Id + " ";
                chkcount++;
                buildsql += Id;
                buildsql += " = 'True' ";
            }
        }
    }
}
