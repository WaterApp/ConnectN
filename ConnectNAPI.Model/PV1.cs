using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNAPI.DataModel
{
    public class PV1
    {
        public string Patient_Class { get; set; }
        public string Patient_Ward { get; set; }
        public string Patient_Room { get; set; }
        public string Patient_Bed { get; set; }
        public string Admission_Type { get; set; }
        public string Attending_Doc { get; set; }
        public string Consulting_Doc { get; set; }
        public string Referring_Doc { get; set; }
        public string Hospital_Service { get; set; }
        public string Ambulatory_Status { get; set; }
        public string VIP_Indicator { get; set; }
        public string Financial_Class { get; set; }
        public string Admit_Date { get; set; }
        public string Discharge_Date { get; set; }

    }
}
