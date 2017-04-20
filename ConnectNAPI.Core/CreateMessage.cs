using NHapi.Base.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHapi.Model.V251.Message;
using NHapi.Model.V251.Segment;
using NHapi.Base.Util;
using System.Data;
namespace ConnectNAPI.Core
{
    public class CreateMessage
    {
        public void CreateData(string Type)
        {
            if (Type == Utility.Constants.Patient_details_fileName)
            {
                DataAccess da = new DataAccess();
                PipeParser parser = new PipeParser();
                DataSet data = da.GetPatientData();
                string messagePath = Utility.Utility.GetAppConfigValues("GeneratePath") + Utility.Constants.Patient_details_fileName;
                ADT_A01 encodedMessage = new ADT_A01();
                encodedMessage.MSH.FieldSeparator.Value = "|";
                encodedMessage.MSH.EncodingCharacters.Value = @"^~\&";
                encodedMessage.MSH.VersionID.VersionID.Value = "2.5.1";
                encodedMessage.MSH.SendingApplication.NamespaceID.Value = "NurseApp";
                encodedMessage.MSH.ReceivingApplication.NamespaceID.Value = "HIS";
                encodedMessage.MSH.MessageType.MessageStructure.Value = "ADT_A01";
                encodedMessage.MSH.DateTimeOfMessage.Time.Value = System.DateTime.Now.ToFileTime().ToString();
                encodedMessage.MSH.PrincipalLanguageOfMessage.Text.Value = "EN";

                encodedMessage.PID.PatientID.IDNumber.Value = data.Tables[0].Rows[0]["PatientId"].ToString();
                encodedMessage.PID.AdministrativeSex.Value = data.Tables[0].Rows[0]["Gender"].ToString();
                encodedMessage.PID.DateTimeOfBirth.Time.Value = data.Tables[0].Rows[0]["DoB"].ToString();
                encodedMessage.PID.GetPatientName(0).FamilyName.Surname.Value = data.Tables[0].Rows[0]["Pateint_LastName"].ToString();
                encodedMessage.PID.GetPatientName(0).GivenName.Value = data.Tables[0].Rows[0]["Patient_FirstName"].ToString();
                //encodedMessage.PID..Time.Value = data.Tables[0].Rows[0]["AdmittedDate"].ToString();

               string msgContent= parser.Encode(encodedMessage);
               Utility.Utility.WriteFile(messagePath, msgContent);


            }
        }
    }
}
