using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHapi.Model;
using NHapi.Base.Parser;
using ConnectNAPI.DataModel;
using ConnectNAPI.Utility;
using NHapi.Model.V251.Message;
namespace ConnectNAPI.Core
{
    public class ParseMessages
    {
        public void ParseData(string Type )
        {

            if (Type == Utility.Constants.Patient_details_fileName)
            {
                string messagePath = Utility.Utility.GetAppConfigValues("FilePath") + Utility.Constants.Patient_details_fileName;
                string MessageContent = Utility.Utility.GetFileContent(messagePath);

                var parser = new PipeParser();
                var decodedMessage = parser.Parse(MessageContent);
                ADT_A01 parsedMessage = decodedMessage as ADT_A01;

                PID patientModel = new PID();
                Utility.DataExtraction.GetPIDData(parsedMessage, ref patientModel);

                PV1 patientVisit = new PV1();
                Utility.DataExtraction.GetPatientVisit1(parsedMessage, ref patientVisit);

                PV2 patientVisit2 = new PV2();
                Utility.DataExtraction.GetPatientVisit2(parsedMessage, ref patientVisit2);
            }
            else if (Type == Utility.Constants.Vital_Update_fileName)
            {
                string messagePath = Utility.Utility.GetAppConfigValues("FilePath") + Utility.Constants.Vital_Update_fileName;
                string MessageContent = Utility.Utility.GetFileContent(messagePath);

                var parser = new PipeParser();
                var decodedMessage = parser.Parse(MessageContent);
                ADT_A01 parsedMessage = decodedMessage as ADT_A01;

                PID patientModel = new PID();
                Utility.DataExtraction.GetPIDData(parsedMessage, ref patientModel);

                PV1 patientVisit = new PV1();
                Utility.DataExtraction.GetPatientVisit1(parsedMessage, ref patientVisit);

                List<OBX> observationList = new List<OBX>();
                Utility.DataExtraction.GetObservationData(parsedMessage, ref observationList);
            }

        }
    }
}
