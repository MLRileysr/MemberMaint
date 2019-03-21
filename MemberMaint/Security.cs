using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MemberMaint
{
    [Table("SignIn")]
    class Security
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }                     //0
        [MaxLength(8)]
        public string UserName { get; set; }//00
        public string Password { get; set; }//01
        public string Role { get; set; }//02
        public string Authorised { get; set; }
    }
}