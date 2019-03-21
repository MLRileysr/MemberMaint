using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using SQLite;

namespace MemberMaint
{
    public partial class LogIn : Form
    {
        public string cccc { get; set; }
        public string CurrentUser                     //
        {                                           // used to pass UserID to currUsid in Variables.cs
            get { return cccc; }               //
            set { cccc = value; }              //
        }                                           ////
        Constants var = new Constants();
        IPHostEntry host;
        string localIp = "";
        SQLiteConnection getUser;
        List<Security> select;
        public LogIn()
        {
            getUser = new SQLiteConnection(var.dbPath());
            getUser.CreateTable<Security>();
            select = getUser.Query<Security>("SELECT * FROM SignIn");
            InitializeComponent();
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress iP in host.AddressList)
            {
                if (iP.AddressFamily.ToString() == "InterNetwork")
                {
                    localIp = iP.ToString();
                }
            }
            if (select.Count == 0)
            { // initial startup
                panStartUp.Visible = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (panStartUp.Visible == true)
            {
                insertnew("Admin", "true"); //make new Administration
                panStartUp.Visible = false;
                CurrentUser = txtUser.Text;        // pass the UserId to application
                this.Close();
            }
            select = getUser.Query<Security>("SELECT * FROM SignIn WHERE UserName = '" + txtUser.Text.Trim() + "'");
            if (select.Count != 0)
            {
                if (txtPass.Text.Trim() == select[0].Password)  //UserId was found if password match 
                {
                    string text = select[0].Authorised;
                    if (select[0].Authorised == "true")     //test authorized
                    {
                        if (select[0].Role == "Admin") checkusers();  //see if any users are needing authorized
                        CurrentUser = txtUser.Text;        // pass the UserId to application
                        this.Close();
                        return;
                    }
                    CurrentUser = "";
                    MessageBox.Show("User found but not Yet Authorized see Administrator", " sign on problem");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("User found but entered password was not.\n Try again", " sign on problem");
                    return;
                }
            }
            else
            {
                DialogResult MakeNew = MessageBox.Show("Would you like to create a new User?", "Log In", MessageBoxButtons.YesNoCancel,
                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (MakeNew == DialogResult.Yes)
                {
                    insertnew("user", "false"); //make new User
                }
                if (MakeNew == DialogResult.No)
                {
                    return;
                }
                if (MakeNew == DialogResult.Cancel)
                {
                    string badboy = "un authorise attempt to hack our system\n - The NSA FBI And CIA have been Notifid \n " +
                " Your name and IP Address have been noted " + localIp + "  " + Environment.UserName;
                    MessageBox.Show(badboy, "Hacker alert");
                    CurrentUser = "";
                    Application.Exit();
                }
                Application.Exit();
            }
            this.Close();
        }
        private void insertnew(string role, string authorised)
        {
            string temp = "INSERT INTO SignIn  (UserName,Password,Role,Authorised) VALUES ('" + txtUser.Text.Trim() +
                  "','" + txtPass.Text.Trim() + "','" + role + "' ,'" + authorised + "')";
            getUser.Query<Security>(temp);
        }
        private void checkusers()//see if any users are needing authorized
        {
            string getauth = "Select * from SignIn where Authorised != 'true'";
            select = getUser.Query<Security>(getauth);
            for (int x = 0; x < select.Count(); x++)
            {
                DialogResult MakeNew = MessageBox.Show("Authorize this User", select[x].UserName, MessageBoxButtons.YesNoCancel,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (MakeNew == DialogResult.Yes)
                {
                    string authUser = "UPDATE SignIn SET Authorised = 'true' WHERE Id = '" + select[x].Id + "'";    //id appended";
                    MessageBox.Show("Authorize" + select[x].UserName, "User Maintence "); //make new User
                    getUser.Query<Security>(authUser);
                }
                if (MakeNew == DialogResult.No)
                {
                    MessageBox.Show("Don't " + select[x].UserName + " authorize yet", "User Maintence "); //make new User
                }
                if (MakeNew == DialogResult.Cancel)
                {
                    MessageBox.Show("Delete this User" + select[x].UserName, "User Maintence "); //make new User
                    string deleteUser = "DELETE FROM SignIn WHERE Id = '" + select[x].Id + "'";    //id appended";
                    getUser.Query<Security>(deleteUser);
                }
            }
            return;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            panStartUp.Visible = false;
            this.Close();
        }
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                //   btnLogin_Click(sender, e);
                btnLogin.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
