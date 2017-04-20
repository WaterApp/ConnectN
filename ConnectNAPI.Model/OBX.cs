using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNAPI.DataModel
{
    public class OBX
    {
        public string Set_ID { get; set; }
        public string Value_type { get; set; }
        public string Observation_Identifier { get; set; }
        public string Observation_Sub_ID { get; set; }
        public string Observation_Value { get; set; }
        public string Units { get; set; }
        public string Reference_Range { get; set; }
        public string Abnormal_Flags { get; set; }
        public string Date_Time_Observation { get; set; }
        public string producer_Id { get; set; }
        public string Observation_Method { get; set; }
        public string Observation_Result_Status { get; set; }
        public string User_Defined_Access_Checks { get; set; }
        public string Value_Type { get; set; }
        

    }
}
