using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberMaint
{
    class Constants
    {
        public static String id = "";
        public static int index = -1;
        public String database = "Members";
        public String adverts = "Advertisements";
        public String clients = "ClientID";
        public static String commaFile = "LoadMembfile.csv"; //"CLloadfile.csv";
        public string sqlstring = "";
        public int SecurityLevel = 0;
        public string imagesource = @"C:\pic10-27-17\Church\";
        public string imagetargetpath = @"C:\SQLiteProjects\Photos\";
        public string commafilePath = @"C:\SQLitePeojects\";
        public string dbPath()
        {
            return System.IO.Path.Combine(System.Environment.GetFolderPath
                 (System.Environment.SpecialFolder.Personal), database + ".db");
        }
        public string csvpath()
        {
            return System.IO.Path.Combine(System.Environment.GetFolderPath
                 (System.Environment.SpecialFolder.Personal), commaFile);
        }
    }
}