using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAppAdmin.DataModel
{
    public class OfflineSync
    {
       public dynamic insertReturnMedication { get; set; }
       public dynamic updateNotified { get; set; }
        public List<HandoverChecklist> insertHandOverMaster { get; set; }
        public List<InvasiveLines> insertInvasiveLines { get; set; }
        public List<Catheters> insertCatheters { get; set; }
        public List<VitalSigns> insertVitalSigns { get; set; }
        public List<Medication> insertMedication { get; set; }
        public List<Diet> insertDiet { get; set; }
        public List<Investigation> insertInvestigations { get; set; }
        public List<IOChart> insertIoChart { get; set; }
        public List<SurgeryProcedure> insertSurgeryProcedure { get; set; }
        public List<PharmacyConsumableAndReplacementFund> insertPharmacyConsumableAndReplacementFund { get; set; }
        public List<PatientNotes> addPatientNotes { get; set; }
        public List<PatientNotes> deletePatientNotes { get; set; }
        public List<PatientNotes> updatePatientNotes { get; set; }
        public List<EmailHistory> saveEmailHistory { get; set; }
        public List<Int32> updateReadEmail { get; set; }
        public List<BioMedicEquipReport> updateBioMedicEquipReport { get; set; }
        public List<DrugByRoute> addDrugByRoute { get; set; }
        public List<WardStockList> updateWardStockList { get; set; }
        public List<MethodDates> getMethodDates { get; set; }        
        public List<NurseProfileImg> saveProfileImg { get; set; }
        public int nurseId { get; set; }
        public dynamic addEquipment { get; set; }
    }
    
    public class HandoverChecklist
    {
        public int handoverCheckListId { get; set; }
        public int hocPharmacyConsumableReplacementId { get; set; }
        public int hocInvasiveLineId { get; set; }
        public int hocCathetersId { get; set; }
        public int hocVitalSignId { get; set; }
        public int hocMedicationId { get; set; }
        public int hocInvestigationId { get; set; }
        public int hocDietId { get; set; }
        public int hocIOChartId { get; set; }
        public int hocSurgeryProcedureId { get; set; }
        public int patientId { get; set; }
        public int shiftId { get; set; }
        public int nurseId { get; set; }
        public string diagnosis { get; set; }
        public string surgicalProcedure { get; set; }
        public int onMET_PETList { get; set; }
        public string vulnerable { get; set; }
        public string bloodGroup { get; set; }
        public string shiftDate { get; set; }
        public List<int> coMorbidityId { get; set; }
    }

    

    public class InvasiveLines
    {
        public int hocInvasiveLineId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public string peripheral { get; set; }
        public string central { get; set; }
        public string picc { get; set; }
        public string arterial { get; set; }
        public string chemoport { get; set; }
        public string epidural { get; set; }
        public string shiftDate { get; set; }
        public string drain { get; set; }
        public string catheters { get; set; }
    }

    public class Catheters
    {
        public int hocCathetersId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
       /* public string catheters { get; set; }
        public string drain { get; set; }*/
        public string surgicalWound { get; set; }
        public string VAC { get; set; }
        public string tracheostomy { get; set; }
        public string pressureUlcer { get; set; }
        public int grade { get; set; }
        public string pressureRelivingAids { get; set; }
        public string comment { get; set; }
        public string informedTo { get; set; }
        public string others { get; set; }
        public string specialProcedures { get; set; }
        public List<int> specialProceduresId { get; set; }
        public string dvtprophylaxis { get; set; }
        public string shiftDate { get; set; }
    }

    public class VitalSigns
    {
        public int hocVitalSignId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public int temperature { get; set; }
        public int pulse { get; set; }
        public int bpSystolic { get; set; }
        public int bpDiastolic { get; set; }
        public int resp { get; set; }
        public int painscore { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public float bmi { get; set; }
        public string restraints { get; set; }
        public string restraintsConsent { get; set; }
        public string o2Administration { get; set; }
        public int ltrpermin { get; set; }
        public int mode { get; set; }
        public int spo2 { get; set; }
        public string GRBS { get; set; }
        public int gcsScore { get; set; }
        public string metPet { get; set; }
        public int metScore { get; set; }
        public string anxietyInsomaniaDiscomfort { get; set; }
        public string incident { get; set; }
        public string nearMiss { get; set; }
    }

    public class Medication
    {
        public int hocMedicationId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public string ivAntibiotic { get; set; }
        public string antibioticDescription { get; set; }
        public int pca { get; set; }
        public string impStdOrdrDr { get; set; }
        public string medicineTranscribed { get; set; }
        public string highRiskMedication { get; set; }
        public string medicineName { get; set; }
        public string anticoagulants { get; set; }
        public string anticoagulantsDesc { get; set; }        
    }

    public class Diet
    {
        public int hocDietId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public string typeOfDiet { get; set; }
        public string dietSpecification { get; set; }
        public string shiftDate { get; set; }        
        
    }
    public class Investigation
    {
        public int hocInvestigationId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public string labInvestigationsToBeDone { get; set; }
        public string labInvestigationPending { get; set; }
        public string criticalValues { get; set; }
        public string radiologicalInvestigationsDone { get; set; }
        public string radiologicalInvestigationsPending { get; set; }
        //public string vaccinationPending { get; set; }
        public string shiftDate { get; set; }

    }

    public class IOChart
    {
        public int hocIOChartId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public string ioChart { get; set; }
        public string totalIntake { get; set; }
        public string oralIvParental { get; set; }
        public string ivFluid { get; set; }
        public string bloodProducts { get; set; }
        public string totalOutput { get; set; }
        public string bladderMovement { get; set; }
        public string bowelMovement { get; set; }
        public string vomittus { get; set; }
        public string drain1_2 { get; set; }
        public string shiftDate { get; set; }

    }

    public class SurgeryProcedure
    {
        public int hocSurgeryProcedureId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public int surgeryProcedure { get; set; }
        public string description { get; set; }
        public string npo { get; set; }
        public string timeSince { get; set; }
        public string consent { get; set; }
        public string preOpCheckListCompletion { get; set; }
        public string skinPreparation { get; set; }
        public string premedication { get; set; }
        public string medTime { get; set; }
        public string crossMatchReservBlood { get; set; }
        public int noofBloodUnitArranged { get; set; }
        public string surgicalSiteMarking { get; set; }
        public string doneOrNot { get; set; }

    }

    public class PharmacyConsumableAndReplacementFund
    {
        public int hocPharmacyConsumableReplacementId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int shiftId { get; set; }
        public string PACRR { get; set; }
        public string anyOtherNotes { get; set; }
        public string shiftDate { get; set; }        

    }

    public class PatientNotes
    {
        public int notesId { get; set; }
        public int patientId { get; set; }
        public int nurseId { get; set; }
        public int doctorId { get; set; }
        public string content { get; set; }        

    }

    public class EmailHistory
    {
        public string emailFrom { get; set; }
        public string emailTo { get; set; }
        public string emailSubject { get; set; }
        public string emailBody { get; set; }
        public int nurseId { get; set; }
        public string important { get; set; }
        public int loopmailId { get; set; }

    }

    public class BioMedicEquipReport
    {
        public int bioMedicEquipPlacedId { get; set; }
        public string status { get; set; }
        public int nurseId { get; set; }

    }

    public class DrugByRoute
    {
        public int medicineFollowingId { get; set; }
        public int nurseId { get; set; }
        public int patientId { get; set; }
        public int routeId { get; set; }
        public int administeredQty { get; set; }

    }
    public class WardStockList
    {
        public List<StockQuantity> pharmaWardstockList { get; set; }
        public List<StockQuantity> nonPharmaWardstockList { get; set; }
        public List<StockQuantity> patientConsumableWardstockList { get; set; }
        public List<StockQuantity> wardConsumableWardstockList { get; set; }
        public List<StockQuantity> nonConsumablewardstockList { get; set; }

    }   

    public class StockQuantity
    {
        public int wardStockId { get; set; }
        public int qry { get; set; }
    }

    public class MethodDates
    {
        public string method { get; set; }
        public string lastSyncDate { get; set; }        

    }

    public class NurseProfileImg
    {
        public int nurseId { get; set; }
        public string profileImage { get; set; }
        public string imageFormat { get; set; }

    }

    public class AddEquipment
    {
        public int bioMedicEquipId { get; set; }
        public string source { get; set; }        

    }
    public class orderEquipment
    {
        public List<AddEquipmentList> orderEquipList { get; set; }

    }

    public class AddEquipmentList
    {
        public List<AddEquipment> equipId { get; set; }
        public int nurseId { get; set; }
        public int patientId { get; set; }
    }

   

}
