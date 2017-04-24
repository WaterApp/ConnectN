using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNAPI.DataModel
{
    public class PID
    {
        public string Set_ID { get; set; }
        public string External_ID { get; set; }
        public string Internal_ID { get; set; }
        public string Alternate_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Mother_Name { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public string Patient_Address { get; set; }
        public string Country_Code { get; set; }
        public string Primary_Language { get; set; }
        public string Marital_Status { get; set; }
        public string Religion { get; set; }
        public string Patient_Account_Number { get; set; }
        public string SSNNumber { get; set; }
        public string Driving_Licence { get; set; }
        public string Citizenship { get; set; }
        public string Nationality { get; set; }
        public DateTime Patient_Death_Date { get; set; }
        public string Patient_Death_Indicator { get; set; }

    }
}
