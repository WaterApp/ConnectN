using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAppAdmin.DataModel
{
    public class OfflineSyncOut
    {
        public List<Int32> handler { get; set; }
        public List<WardListData> getwardListdata { get; set; }
        public List<NursingManagerShiftData> nursingmanagershift { get; set; }
        public List<PatientData> getPatientByNurse { get; set; }
        public List<PatientData> DutyNursePatientList { get; set; }
        public List<NotifyData> getNotifyList { get; set; }
        public List<NotifyCount> getNotifyCount { get; set; }
        public GetVitalData getVitalReferences { get; set; }
        public List<SpecialProcedures> getSpecialProcedures { get; set; }
        public List<Comorbodities> getCoMorbidities { get; set; }
                
        public List<Handovercheclistdata> getHandOverCheckListMaster { get; set; }
        public List<Handovercheclistdata> getPastHandOverCheckListMaster { get; set; }
        public List<LabReportData> getLabReport { get; set; }
        public List<PatientNotesData> getpatientNotes { get; set; }
        public List<BioMedicalEquipData> getBioMedicEquipReport { get; set; }
        public List<BioMedicEquipInfo> getBioMedicList { get; set; }
        public List<MedicineBypatientData> getMedicineByPatient { get; set; }
        public List<MedicineReturnBypatientData> getReturnMedicineByPatient { get; set; }
        public List<MedicineStockData> getPharmaByWard { get; set; }
        public List<MedicineStockData> getNonPharmaByWard { get; set; }
        public List<MedicineStockData> getPatientConsumableByWard { get; set; }
        public List<MedicineStockData> getWardConsumableByWard { get; set; }
        public List<MedicineStockData> getNonConsumableByWard { get; set; }
        public List<StockListByDate> getStockListByDate { get; set; }
        public List<InboxData> GetInboxMail { get; set; }
        public List<InboxData> getEmailHistoryForNurse { get; set; }
        public List<InboxData> GetReplyMail { get; set; }


        
    }

    public class WardListData
    {
        public int WardId { get; set; }
        public string wardName { get; set; }
        public int nurseId { get; set; }
    }

    public class bioIndicator
    {
        public string bioMedicEquipName { get; set; }
        public string deviceStartDate { get; set; }
        public string url { get; set; }
    }

    public class labIndicator
    {
        public string labProcedure { get; set; }        
        public string url { get; set; }
        public string bioMedicEquipName { get; set; }
    }
    public class PatientData
    {
        public string patientId { get; set; }
        public string profileUrl { get; set; }
        public string patientName { get; set; }
        public string doctorName { get; set; }
        public string mheplPatientId { get; set; }
        public string admittedDate { get; set; }
        public string nurseId { get; set; }
        public string patientAge { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string roomNumber { get; set; }
        public List<labIndicator> labIndicator { get; set; }
        public List<bioIndicator> bioIndicator { get; set; }
    }
    public class NotifyData
    {
        public string PatientID { get; set; }
        public string bioMedicalNotification { get; set; }
        public string drugNotification { get; set; }
        public string investigationNotification { get; set; }
        public string patientName { get; set; }
    }
    public class NotifyCount
    {
        public int countADT { get; set; }
    }
    public class VitalBPData {
        public string vitalBPRateId { get; set; }
        public string approximateAgeRange { get; set; }
        public string minBPSystolicRate { get; set; }
        public string maxBPSystolicRate { get; set; }
        public string minBPDiastolicRate { get; set; }
        public string maxBPDiastolicRate { get; set; } 

    
    }
    public class vitalHeartData
    {
        public string vitalHeartRateId { get; set; }
        public string approximateAgeRange { get; set; }
        public string minHeartRate { get; set; }
        public string maxHeartRate { get; set; }        
        
    }
    public class vitalRespiratoryData
    {
        public string vitalRespiratoryRateId { get; set; }
        public string approximateAgeRange { get; set; }
        public string minRespiratoryRate { get; set; }
        public string maxRespiratoryRate { get; set; }

    }
    public class vitalUrineData
    {
        public string vitalUrineId { get; set; }
        public string minVitalUrineRate { get; set; }
        public string maxVitalUrineRate { get; set; }
        public string score { get; set; }

    }
    public class vitalTempData
    {
        public string vitalTempId { get; set; }
        public string minVitalTempRate { get; set; }
        public string maxVitalTempRate { get; set; }
        public string score { get; set; }

    }
    public class GetVitalData {
        public List<VitalBPData> vitalBpRate { get; set; }
        public List<vitalHeartData> vitalHeartRate { get; set; }
        public List<vitalRespiratoryData> vitalRespiratoryRate { get; set; }
        public List<vitalTempData> vitalTempRate { get; set; }
        public List<vitalUrineData> vitalUrineRate { get; set; }
    }

    public class SpecialProcedures
    {
        public string specialProcedureId { get; set; }
        public string specialProcedures { get; set; }
    }
    public class Comorbodities
    {
        public string coMorbiditiesId { get; set; }
        public string coMorbidities { get; set; }
    }

    public class CheifComplaint
    {
        public string conditionId { get; set; }
        public string condition { get; set; }
    }

    public class InvasiveLineData
    {
        public string hocInvasiveLineId { get; set; }
        public string peripheral { get; set; }
        public string central { get; set; }
        public string PICC { get; set; }
        public string arterial { get; set; }
        public string chemoport { get; set; }
        public string epidural { get; set; }
        public string urinaryCatheters { get; set; }
        public string urinaryDrain { get; set; }
    }

    public class CathetersData {
        public string hocCathetersId { get; set; }
        public string surgicalWound { get; set; }
        public string VAC { get; set; }
        public string tracheostomy { get; set; }
        public string pressureUlcer { get; set; }
        public string grade { get; set; }
        public string pressureRelievingAids { get; set; }
        public string comment { get; set; }
        public string informedTo { get; set; }
        public string dvtprophylaxis { get; set; }
        public string specialProcedures { get; set; }
        public string otherSpecialProcedures { get; set; }
        public string others { get; set; }
    }

    public class PatientCategory
    {
        public string hocCategoryOfPatientId { get; set; }
        public string patientCriticalityLevelId { get; set; }
        public string patientCriticalityLevel { get; set; }
    }


    public class vitalSignData
    {
        public string hocVitalSignId { get; set; }
        public string temperature { get; set; }
        public string pulse { get; set; }
        public string systolic { get; set; }
        public string diastolic { get; set; }
        public string RESP { get; set; }
        public string painScore { get; set; }
        public string weight { get; set; }
        public string restraints { get; set; }
        public string restraintsConsent { get; set; }
        public string o2Administration { get; set; }
        public string ltrperMin { get; set; }
        public string mode { get; set; }
        public string SPO2 { get; set; }
        public string grbsIfApplicable { get; set; }
        public string gcsScore { get; set; }
        public string metScoreMETPET { get; set; }
        public string metScore { get; set; }
        public string anxietyInsomaniaDiscomfort { get; set; }
        public string incident { get; set; }
        public string nearMiss { get; set; }
        public string vitalFrequency { get; set; }
        public string bmi { get; set; }
        public string height { get; set; }

    }
    public class InvestigationData
    {
        public string hocInvestigationId { get; set; }
        public string labInvestigationsToBeDone { get; set; }
        public string labInvestigationsPending { get; set; }
        public string criticalValues { get; set; }
        public string radiologicalInvestigationsDone { get; set; }
        public string radiologicalInvestigationsPending { get; set; }
        public string vaccinationPending { get; set; }
        
        
    }
    public class MedicationData
    {
        public string hocMedicationId { get; set; }
        public string ivAntibiotic { get; set; }
        public string antibioticDescription { get; set; }
        public string PCA { get; set; }
        public string impStdOrdrDr { get; set; }
        public string anticoagulants { get; set; }
        public string anticoagulantsDescription { get; set; }
        public string homeMedication { get; set; }
        public string highRiskMedication { get; set; }
        public string vaccinationPending { get; set; }
        public string medicineName { get; set; }

    }

    public class DietData
    {
        public string hocDietId { get; set; }
        public string typeOfDiet { get; set; }
        public string otherDiettypes { get; set; }
        public string dietSpecification { get; set; }        

    }
    public class IOChartData
    {
        public string hocIOChartId { get; set; }
        public string ioChart { get; set; }
        public string totalIntake { get; set; }
        public string oralIvParental { get; set; }
        public string ivFluid { get; set; }
        public string bloodProducts { get; set; }
        public string totalOutput { get; set; }
        public string bladderMovement { get; set; }
        public string bowelMovement { get; set; }
        public string vomittus { get; set; }
        public string drain { get; set; }

    }

    public class surgeryProcedureData
    {
        public string hocSurgeryProcedureId { get; set; }
        public string surgeryProcedure { get; set; }
        public string description { get; set; }
        public string NPO { get; set; }
        public string timeSince { get; set; }
        public string consent { get; set; }
        public string preOpCheckListCompletion { get; set; }
        public string skinPreparation { get; set; }
        public string premedication { get; set; }
        public string medTime { get; set; }
        public string crossMatchReservBlood { get; set; }
        public string noofBloodUnitArranged { get; set; }
        public string surgicalSiteMarking { get; set; }
        public string doneorNot { get; set; }
    }
    public class PharmacyConsumableReplacementData
    {
        public string hocPharmacyConsumableReplacementId { get; set; }
        public string PACRR { get; set; }
        public string comments { get; set; }
    }
    public class Handovercheclistdata
    {
        public string handOverCheckListId { get; set; }
        public string patientId { get; set; }
        public string diagnosis { get; set; }
        public string surgicalProcedure { get; set; }
        public string onMET_PETList { get; set; }
        public string vulnerable { get; set; }
        public string bloodGroup { get; set; }
        public string coMorbidity { get; set; }
        public string postOperativeDays { get; set; }
        public string submittedBy { get; set; }
        public string HOC_InvasiveLineId { get; set; }
        public string HOC_CathetersId { get; set; }
        public string HOC_CategoryOfPatientId { get; set; }
        public string HOC_VitalSignId { get; set; }
        public string HOC_MedicationId { get; set; }
        public string HOC_InvestigationsId { get; set; }
        public string HOC_DietId { get; set; }
        public string HOC_IOChartId { get; set; }
        public string HOC_SurgeryProcedureId { get; set; }        
        public string HOC_PharmacyConsumableReplacementId { get; set; }               
        public List<InvasiveLineData> invasiveLines { get; set; }
        public List<PatientCategory> categoryOfPatient { get; set; }
        public List<CathetersData> catheters { get; set; }
        public List<vitalSignData> vitalSigns { get; set; }
        public List<MedicationData> medication { get; set; }
        public List<InvestigationData> investigations { get; set; }
        public List<DietData> diet { get; set; }
        public List<IOChartData> ioChart { get; set; }
        public List<surgeryProcedureData> surgeryProcedure { get; set; }
        public List<PharmacyConsumableReplacementData> pharmacyConsumableReplacement { get; set; }
        public List<Comorbodities> coMorbitdityList { get; set; }
        public List<SpecialProcedures> specialProcedureList { get; set; }
        public List<CheifComplaint> chiefComplaint { get; set; }

    }
    public class LabReportData
    {
        public string investigationsId { get; set; }
        public string investigationProcedure { get; set; }
        public string orderedDate { get; set; }
        public string reportGeneratedDate { get; set; }
        public string LabReportStatus { get; set; }
        public string doctorStatus { get; set; }
        public string fillerOrderEntityIdentifier { get; set; }
        public string placeOrderEntityIdentifier { get; set; }
        public List<InvestigationDetailedData> investigationDetailedReport { get; set; }


    }

     public class PatientNotesData {
         public string notesId { get; set; }
         public string patientId { get; set; }
         public string doctorId { get; set; }
        public string content { get; set; }
        public string createdDate { get; set; }
        public string createdById { get; set; }
        public string createdBy { get; set; }
        public string modifiedDate { get; set; }
        public string modifiedById { get; set; }
        public string modifiedBy { get; set; }
        public string createdByProfile { get; set; }
        public string modifiedByProfile { get; set; } 
    
    }

     public class BioMedicalEquipData {
         public string equipId { get; set; }
         public string bioMedicalEquipPlacedId { get; set; }
        public string bioMedicalEquipmentName { get; set; }
        public string bioMedicalEquipmentCategory { get; set; }
        public string orderedDate { get; set; }
        public string orderedBy { get; set; } 
         public string checkedInDate { get; set; }
        public string status { get; set; }
        public string checkedInBy { get; set; }
        public string modifiedBy { get; set; }
        public string checkedOutDate { get; set; }
        public string deviceStartTime { get; set; } 
         public string deviceEndtime { get; set; } 
         public string consumedHours { get; set; } 
         public string equipmentReturned { get; set; } 
         public string billingType { get; set; } 
         public string equipSource { get; set; } 
             
    }

     public class BioMedicEquipInfo {
         public string bioMedicEquipId { get; set; }
        public string bioMedicEquipName { get; set; }
        public string eqipmentCategory { get; set; }
        public string billingType { get; set; }
        
    
    }

     public class MedicineBypatientData {
         public string medicineFollowingPatientId { get; set; }
         public string drugId { get; set; }
        public string drugName { get; set; }
        public string dosage { get; set; }
        public string quantity { get; set; }
        public string frequency { get; set; } 
         public string doseUnit { get; set; }
        public string administeredQty { get; set; }
        
    
    }
     public class MedicineReturnBypatientData {
         public string returnId { get; set; }
        public string medicineName { get; set; }
        public string returnTo { get; set; }
        public string quantity { get; set; }
        public string returnedBy { get; set; }
        public string returnedDate { get; set; } 
                
    
    }
    public class MedicineStockData {
        public string name { get; set; }
        public string quantity { get; set; }
        public string updatedDate { get; set; }                       
    
    }
    public class MedicineStockbydate {
        public string categoryId { get; set; }
        public string name { get; set; }
        public string quantity { get; set; }
        public string updatedDate { get; set; }                   
        public string CategoryName { get; set; }  
        
    
    }

    

    public class StockListByDate
    {
        public List<MedicineStockbydate> pharma { get; set; }
        public List<MedicineStockbydate> nonPharma { get; set; }
        public List<MedicineStockbydate> patientConsumable { get; set; }
        public List<MedicineStockbydate> wardConsumable { get; set; }
        public List<MedicineStockbydate> nonConsumable { get; set; }
    }


    public class InboxData {
        public string sentEmailHistoryId { get; set; }
        public string emailFrom { get; set; }
        public string emailTo { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public string mailedDate { get; set; }
        public string important { get; set; }
        public string readMail { get; set; }
        public string sendBy { get; set; }
        public string sendTo { get; set; }
        public string loopMailId { get; set; }      
         
        public string profileURL { get; set; }  
        public string repliedBy { get; set; }  
    }
    public class NursingManagerShiftData
    {
        public string shiftId { get; set; }
        
    }

    public class InvestigationDetailedData
    {
        public string investigationDetailedId { get; set; }
        public string reportItemId { get; set; }
        public string reportItemText { get; set; }
        public string observationValue { get; set; }
        public string referenceRange { get; set; }
        public string abnormalFlags { get; set; }
        public string observationStatus { get; set; }
        public string effectiveDate { get; set; }
        public string observationDate { get; set; }
        public string units { get; set; }
        public string valueType { get; set; }
    }

}
