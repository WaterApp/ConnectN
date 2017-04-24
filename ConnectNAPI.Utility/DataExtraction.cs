using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectNAPI.DataModel;
using NHapi.Model.V251.Message;
namespace ConnectNAPI.Utility
{
   public static class DataExtraction
    {



       public static void GetPIDData(ADT_A01 parsedMessage,ref PID patientModel )
       {
           patientModel.External_ID = parsedMessage.PID.PatientID.IDNumber.Value;
           patientModel.Internal_ID = parsedMessage.PID.GetPatientIdentifierList(0).IDNumber.Value;
           patientModel.First_Name = parsedMessage.PID.GetPatientName(0).GivenName.Value;
           patientModel.Last_Name = parsedMessage.PID.GetPatientName(0).FamilyName.Surname.Value;
           patientModel.DOB = parsedMessage.PID.DateTimeOfBirth.Time.Value;
           patientModel.Patient_Account_Number = parsedMessage.PID.PatientAccountNumber.IDNumber.Value;
           patientModel.Sex = parsedMessage.PID.AdministrativeSex.Value;
           patientModel.Patient_Address = parsedMessage.PID.GetPatientAddress().FirstOrDefault().StreetAddress.StreetName.Value;
           patientModel.Marital_Status = parsedMessage.PID.MaritalStatus.Identifier.Value;
       }

       public static void GetPatientVisit1(ADT_A01 parsedMessage, ref PV1 patientVisit)
       {
           patientVisit.Patient_Ward = parsedMessage.PV1.AssignedPatientLocation.Floor.Value;
            patientVisit.Patient_Room = parsedMessage.PV1.AssignedPatientLocation.Room.Value;
            patientVisit.Patient_Bed = parsedMessage.PV1.AssignedPatientLocation.Bed.Value;
            patientVisit.Admission_Type = parsedMessage.PV1.AdmissionType.Value;
            patientVisit.Attending_Doc = parsedMessage.PV1.GetAttendingDoctor(0).IDNumber.Value;
            patientVisit.Referring_Doc = parsedMessage.PV1.GetReferringDoctor(0).IDNumber.Value;
            patientVisit.Consulting_Doc = parsedMessage.PV1.GetConsultingDoctor(0).IDNumber.Value;
            patientVisit.Admit_Date = parsedMessage.PV1.AdmitDateTime.Time.Value;
            patientVisit.Discharge_Date = parsedMessage.PV1.GetDischargeDateTime(0).Time.Value;
       }

       public static void GetPatientVisit2(ADT_A01 parsedMessage, ref PV2 patientVisit2)
       {
           patientVisit2.Accomodation_Code = parsedMessage.PV2.AccommodationCode.Text.Value;
           patientVisit2.Admit_Reason = parsedMessage.PV2.AdmitReason.Text.Value;
           patientVisit2.Transfer_Reason = parsedMessage.PV2.TransferReason.Text.Value;
           patientVisit2.Expected_Admit_Date = parsedMessage.PV2.ExpectedAdmitDateTime.Time.Value;
           patientVisit2.Expected_Discharge_Date = parsedMessage.PV2.ExpectedDischargeDateTime.Time.Value;
           patientVisit2.Visit_Desc = parsedMessage.PV2.VisitDescription.Value;
           patientVisit2.Visit_Prioirty_Code = parsedMessage.PV2.VisitPriorityCode.Value;
       }

       public static void GetObservationData(ADT_A01 parsedMessage, ref List<OBX> observationDataList)
       {
           foreach(NHapi.Model.V251.Segment.OBX item in parsedMessage.OBXs )
           {
               OBX observationData=new OBX();
               observationData.Set_ID = item.SetIDOBX.Value;
               observationData.Value_type = item.ValueType.Value;
               observationData.Observation_Identifier = item.ObservationIdentifier.Text.Value;
               observationData.Observation_Value = item.GetObservationValue(0).Data.ToString();
               observationData.Date_Time_Observation = item.DateTimeOfTheObservation.Time.Value;
               observationData.Units = item.Units.Text.Value;
               observationData.producer_Id = item.ProducerSReference.ToString();
               observationData.Observation_Result_Status = item.ObservationResultStatus.Value;
               observationData.Reference_Range = item.ReferencesRange.Value;
               observationData.Abnormal_Flags = item.GetAbnormalFlags(0).Value;
               observationData.User_Defined_Access_Checks = item.UserDefinedAccessChecks.Value;
               observationDataList.Add(observationData);
           }
           
       }

    }
}
