using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MemberMaint
{
    [Table("Members")]
    class Member
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }                     //0
        [MaxLength(8)]
        public string LastName { get; set; }//00
        public string FullName { get; set; }//01
        public string Phone { get; set; }//02
        public string Address { get; set; }//03
        public string Email { get; set; }//04
        public string HousePhone { get; set; }//05
        public string Status { get; set; }//06
        public string PersonalStatus { get; set; }//07
        public string firstGroup { get; set; }//08
        public string secondGroup { get; set; }//09
        public string thirdGroup { get; set; }//10
        public string ADanniverDDD { get; set; }//11
        public string ADanniver { get; set; }//15
        public string ADmemberSinceDDD { get; set; } //
        public string ADmemberSince { get; set; }//18
        public string ADBdateDDD { get; set; }
        public string ADBdate { get; set; }//19
        public string MilitaryGroup { get; set; }//28
        public string Occupation { get; set; }//29      //6   
        public string Cooking { get; set; }//30
        public string TreeCutting { get; set; }//31
        public string AutoMechanic { get; set; }//32
        public string PublicSpeaking { get; set; }//33
        public string ChildAdultCare { get; set; }//34
        public string Nursing { get; set; }//35
        public string Driver { get; set; }//36
        public string FoodService { get; set; }//37
        public string LawnCare { get; set; }//38
        public string ElectricalWiring { get; set; }//39
        public string MathTutoring { get; set; }//40
        public string SpanishTranslation { get; set; }//41
        public string GermanTranslation { get; set; }//42
        public string EnglishTutoring { get; set; }//43
        public string Pianoist { get; set; }//44
        public string Soloist { get; set; }//45
        public string Carpenter { get; set; }//46
        public string Plumbing { get; set; }//47
        public string HeatAir { get; set; }//48
        public string Locksmith { get; set; }//49
        public string HouseCleaning { get; set; }//50
        public string AircraftPilot { get; set; }//51
        public string AircraftOwner { get; set; }//52
        public string Organist { get; set; }//53
        public string TeenMinistries { get; set; }//54
        public string YouthMinistries { get; set; }//55
        public string AudioVideo { get; set; }//56    
        public string ComputerGeek { get; set; }//57
        public string SexGender { get; set; }//58
        public string LastUserChange { get; set; } //59
        public string dateLastChange { get; set; } //60
    }
}