using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurseAppAdmin.DataModel;
using NurseAppAdmin.DataLayer;
using System.Data;
using System.IO;

namespace NurseAppAdmin.BusinessLayer
{
    public class OfflineSyncBusinessLayer
    {
        public OfflineSyncOut GetOfflineSyncData(int nurseID)
        {
            //try
            //{
                OfflineSyncDL OfflineSync = new OfflineSyncDL();
                OfflineSyncOut offlinesyncData = new OfflineSyncOut();
                DataSet offlineData = OfflineSync.GetOfflineSyncData(nurseID);

                if (offlineData != null && offlineData.Tables.Count > 0)
                {
                    ///Handler
                    DataTable DT = offlineData.Tables[0];
                    offlinesyncData.handler = DT.AsEnumerable()
                                   .Select(r => r.Field<Int32>("Handler Status"))
                                   .ToList();

                    //Ward Data
                    DT = offlineData.Tables[1];
                    offlinesyncData.getwardListdata = (from DataRow row in DT.Rows

                                                       select new WardListData
                                                       {
                                                           nurseId = Convert.ToInt32(row["NurseID"]),
                                                           WardId = Convert.ToInt32(row["WardId"]),
                                                           wardName = row["WardName"].ToString()
                                                       }).ToList();

                    //Get patient info by nurse
                    DT = offlineData.Tables[2];
                    string patientID = string.Empty;
                    List<DataRow> DR = null;
                    List<PatientData> patientList = new List<PatientData>();
                    PatientData PatientInfo = null;
                    labIndicator labindicator = null;
                    if (DT.Rows.Count > 0)
                    {
                        while (DT.Rows.Count > 0)
                        {
                            patientID = DT.Rows[0]["patientId"].ToString();
                            DR = DT.AsEnumerable().Where(r => r.Field<string>("patientId") == patientID).ToList();
                            //int index = 0;
                            DataRow row = DR.FirstOrDefault();
                            //foreach (DataRow row in DR.FirstOrDefault())
                            //{
                            //    if (index == 0)
                            //    {
                            //        index++;
                            PatientInfo = new PatientData();
                            PatientInfo.labIndicator = new List<labIndicator>();
                            PatientInfo.bioIndicator = new List<bioIndicator>();
                            PatientInfo.admittedDate = Convert.ToString(row["AdmittedDate"]);
                            //bioIndicator = Convert.ToInt32(row["NurseID"]),
                            PatientInfo.dob = Convert.ToString(row["DoB"]);
                            PatientInfo.doctorName = Convert.ToString(row["doctorName"]);
                            PatientInfo.gender = Convert.ToString(row["Gender"]);
                            // labIndicator
                            PatientInfo.mheplPatientId = Convert.ToString(row["HL7PatientID"]);
                            PatientInfo.patientAge = Convert.ToString(row["Age"]);
                            PatientInfo.patientId = Convert.ToString(row["patientId"]);
                            PatientInfo.patientName = Convert.ToString(row["patientName"]);
                            PatientInfo.profileUrl = Convert.ToString(row["profileUrl"]);
                            PatientInfo.nurseId = Convert.ToString(row["NurseID"]);
                            PatientInfo.roomNumber = Convert.ToString(row["RoomNo"]);
                            // }
                            PatientInfo.labIndicator.AddRange((from dr in DR
                                                               select new labIndicator()
                                                                   {

                                                                       //labindicator = new labIndicator();
                                                                       labProcedure = Convert.ToString(dr["LabProcedure"]),
                                                                       url = Convert.ToString(dr["LabURL"]),

                                                                   }).Where(c => c.labProcedure.Trim() != string.Empty).ToList());
                            PatientInfo.bioIndicator.AddRange((from dr in DR
                                                               select new bioIndicator()
                                                                   {

                                                                       //labindicator = new labIndicator();
                                                                       bioMedicEquipName = Convert.ToString(dr["BioMedicEquipName"]),
                                                                       url = Convert.ToString(dr["BioURL"]),
                                                                       deviceStartDate = Convert.ToString(dr["CheckInTime"]),

                                                                   }).Where(c => c.bioMedicEquipName.Trim() != string.Empty).ToList());
                            patientList.Add(PatientInfo);
                            foreach (DataRow dr in DR)
                            {
                                DT.Rows.Remove(dr);
                            }

                        }



                        // }
                    }
                    offlinesyncData.getPatientByNurse = patientList;

                    //Get Duty Nurse patient List
                    DT = offlineData.Tables[3];
                    //string patientID = string.Empty;
                    //List<DataRow> DR = null;
                    //List<PatientData> patientList = new List<PatientData>();
                    //PatientData PatientInfo = null;
                    //labIndicator labindicator = null;
                    if (DT.Rows.Count > 0)
                    {
                        while (DT.Rows.Count > 0)
                        {
                            patientID = DT.Rows[0]["patientId"].ToString();
                            DR = DT.AsEnumerable().Where(r => r.Field<string>("patientId") == patientID).ToList();
                            //int index = 0;
                            DataRow row = DR.FirstOrDefault();
                            //foreach (DataRow row in DR.FirstOrDefault())
                            //{
                            //    if (index == 0)
                            //    {
                            //        index++;
                            PatientInfo = new PatientData();
                            PatientInfo.labIndicator = new List<labIndicator>();
                            PatientInfo.bioIndicator = new List<bioIndicator>();
                            PatientInfo.admittedDate = Convert.ToString(row["AdmittedDate"]);
                            //bioIndicator = Convert.ToInt32(row["NurseID"]),
                            PatientInfo.dob = Convert.ToString(row["DoB"]);
                            PatientInfo.doctorName = Convert.ToString(row["doctorName"]);
                            PatientInfo.gender = Convert.ToString(row["Gender"]);
                            // labIndicator
                            PatientInfo.mheplPatientId = Convert.ToString(row["HL7PatientID"]);
                            PatientInfo.patientAge = Convert.ToString(row["Age"]);
                            PatientInfo.patientId = Convert.ToString(row["patientId"]);
                            PatientInfo.patientName = Convert.ToString(row["patientName"]);
                            PatientInfo.profileUrl = Convert.ToString(row["profileUrl"]);
                            PatientInfo.nurseId = Convert.ToString(row["NurseID"]);
                            PatientInfo.roomNumber = Convert.ToString(row["RoomNo"]);
                            // }
                            PatientInfo.labIndicator.AddRange((from dr in DR
                                                               select new labIndicator()
                                                               {

                                                                   //labindicator = new labIndicator();
                                                                   labProcedure = Convert.ToString(dr["LabProcedure"]),
                                                                   url = Convert.ToString(dr["LabURL"]),

                                                               }).Where(c => c.labProcedure.Trim() != string.Empty).ToList());
                            PatientInfo.bioIndicator.AddRange((from dr in DR
                                                               select new bioIndicator()
                                                               {

                                                                   //labindicator = new labIndicator();
                                                                   bioMedicEquipName = Convert.ToString(dr["BioMedicEquipName"]),
                                                                   url = Convert.ToString(dr["BioURL"]),
                                                                   deviceStartDate = Convert.ToString(dr["CheckInTime"]),

                                                               }).Where(c => c.bioMedicEquipName.Trim() != string.Empty).ToList());
                            patientList.Add(PatientInfo);
                            foreach (DataRow dr in DR)
                            {
                                DT.Rows.Remove(dr);
                            }

                        }



                        // }
                    }


                    offlinesyncData.DutyNursePatientList = patientList;

                    //Get Notification List
                    DT = offlineData.Tables[4];
                    offlinesyncData.getNotifyList = (from DataRow row in DT.Rows

                                                     select new NotifyData
                                                      {
                                                          PatientID = Convert.ToString(row["patientId"]),
                                                          patientName = Convert.ToString(row["patientName"]),
                                                          investigationNotification = (Convert.ToString(row["notifiedFor"]) == "Investigation") ? "True" : "False",
                                                          drugNotification = (Convert.ToString(row["notifiedFor"]) == "Drug Administration") ? "True" : "False",
                                                          bioMedicalNotification = (Convert.ToString(row["notifiedFor"]) == "Bio-Medical Equipment") ? "True" : "False",
                                                      }).Distinct().ToList();

                    //Get notify count
                    DT = offlineData.Tables[5];
                    offlinesyncData.getNotifyCount = (from DataRow row in DT.Rows

                                                      select new NotifyCount
                                                      {
                                                          countADT = Convert.ToInt32(row["countADT"]),
                                                      }).ToList();

                    //Get vital Reference
                    DT = offlineData.Tables[6];
                    List<VitalBPData> vitalBPList = (from DataRow row in DT.Rows

                                                     select new VitalBPData
                                                     {
                                                         vitalBPRateId = Convert.ToString(row["VitalbPRateId"]),
                                                         approximateAgeRange = Convert.ToString(row["ApproximateAgeRange"]),
                                                         maxBPDiastolicRate = Convert.ToString(row["maxBPDiastolicRate"]),
                                                         maxBPSystolicRate = Convert.ToString(row["maxBPSystolicRate"]),
                                                         minBPDiastolicRate = Convert.ToString(row["minBPSystolicRate"]),
                                                         minBPSystolicRate = Convert.ToString(row["minBPDiastolicRate"]),


                                                     }).ToList();
                    DT = offlineData.Tables[7];
                    List<vitalHeartData> vitalHeartList = (from DataRow row in DT.Rows

                                                           select new vitalHeartData
                                                        {
                                                            vitalHeartRateId = Convert.ToString(row["VitalHeartRateId"]),
                                                            approximateAgeRange = Convert.ToString(row["ApproximateAgeRange"]),
                                                            maxHeartRate = Convert.ToString(row["maxHeartRate"]),
                                                            minHeartRate = Convert.ToString(row["minHeartRate"])

                                                        }).ToList();

                    DT = offlineData.Tables[8];
                    List<vitalRespiratoryData> vitalRespList = (from DataRow row in DT.Rows

                                                                select new vitalRespiratoryData
                                                           {
                                                               vitalRespiratoryRateId = Convert.ToString(row["VitalRespiratoryRateId"]),
                                                               approximateAgeRange = Convert.ToString(row["ApproximateAgeRange"]),
                                                               minRespiratoryRate = Convert.ToString(row["minRespiratoryRate"]),
                                                               maxRespiratoryRate = Convert.ToString(row["maxRespiratoryRate"])

                                                           }).ToList();

                    DT = offlineData.Tables[32];
                    List<vitalTempData> vitalTempList = (from DataRow row in DT.Rows

                                                         select new vitalTempData
                                                         {
                                                             vitalTempId = Convert.ToString(row["VitalTempId"]),
                                                             score = Convert.ToString(row["Score"]),
                                                             maxVitalTempRate = Convert.ToString(row["maxVitalTempRate"]),
                                                             minVitalTempRate = Convert.ToString(row["minVitalTempRate"])

                                                         }).ToList();
                    DT = offlineData.Tables[33];
                    List<vitalUrineData> vitalurineList = (from DataRow row in DT.Rows

                                                           select new vitalUrineData
                                                           {
                                                               vitalUrineId = Convert.ToString(row["VitalUrineId"]),
                                                               score = Convert.ToString(row["Score"]),
                                                               maxVitalUrineRate = Convert.ToString(row["maxVitalUrineRate"]),
                                                               minVitalUrineRate = Convert.ToString(row["minVitalUrineRate"])

                                                           }).ToList();

                    GetVitalData vitalData = new GetVitalData();
                    vitalData.vitalBpRate = vitalBPList;
                    vitalData.vitalHeartRate = vitalHeartList;
                    vitalData.vitalRespiratoryRate = vitalRespList;
                    vitalData.vitalUrineRate = vitalurineList;
                    vitalData.vitalTempRate = vitalTempList;
                    offlinesyncData.getVitalReferences = vitalData;


                    //Special Procedures
                    DT = offlineData.Tables[9];
                    offlinesyncData.getSpecialProcedures = (from DataRow row in DT.Rows

                                                            select new SpecialProcedures
                                                            {

                                                                specialProcedureId = Convert.ToString(row["specialProcedureid"]),
                                                                specialProcedures = Convert.ToString(row["specialProcedures"]),

                                                            }).ToList();

                    //Co morbodoties
                    DT = offlineData.Tables[10];
                    offlinesyncData.getCoMorbidities = (from DataRow row in DT.Rows

                                                        select new Comorbodities
                                                        {

                                                            coMorbiditiesId = Convert.ToString(row["coMorbiditiesId"]),
                                                            coMorbidities = Convert.ToString(row["coMorbidities"]),

                                                        }).ToList();
                    //Hand over Check list
                    DT = offlineData.Tables[11];
                    offlinesyncData.getHandOverCheckListMaster = (from DataRow row in DT.Rows

                                                                  select new Handovercheclistdata
                                                                  {
                                                                      handOverCheckListId = Convert.ToString(row["HandOverCheckListId"]),
                                                                      bloodGroup = Convert.ToString(row["bloodGroup"]),
                                                                      patientId = Convert.ToString(row["patientId"]),
                                                                      diagnosis = Convert.ToString(row["Diagnosis"]),
                                                                      surgicalProcedure = Convert.ToString(row["SurgicalProcedure"]),
                                                                      onMET_PETList = Convert.ToString(row["OnMET_PETList"]),
                                                                      vulnerable = Convert.ToString(row["Vulnerable"]),
                                                                      coMorbidity = Convert.ToString(row["coMorbidities"]),
                                                                      postOperativeDays = Convert.ToString(row["postOperativeDays"]),
                                                                      submittedBy = Convert.ToString(row["CreatedBy"]),
                                                                      HOC_InvasiveLineId = Convert.ToString(row["HOC_InvasiveLineId"]),
                                                                      HOC_CathetersId = Convert.ToString(row["HOC_CathetersId"]),
                                                                      HOC_CategoryOfPatientId = Convert.ToString(row["HOC_CategoryOfPatientId"]),
                                                                      HOC_VitalSignId = Convert.ToString(row["HOC_VitalSignId"]),
                                                                      HOC_MedicationId = Convert.ToString(row["HOC_MedicationId"]),
                                                                      HOC_InvestigationsId = Convert.ToString(row["HOC_InvestigationsId"]),
                                                                      HOC_DietId = Convert.ToString(row["HOC_DietId"]),
                                                                      HOC_IOChartId = Convert.ToString(row["HOC_IOChartId"]),
                                                                      HOC_SurgeryProcedureId = Convert.ToString(row["HOC_SurgeryProcedureId"]),
                                                                      HOC_PharmacyConsumableReplacementId = Convert.ToString(row["HOC_PharmacyConsumableReplacementId"]),
                                                                      invasiveLines = new List<InvasiveLineData>(),
                                                                      categoryOfPatient = new List<PatientCategory>(),
                                                                      catheters = new List<CathetersData>(),
                                                                      vitalSigns = new List<vitalSignData>(),
                                                                      medication = new List<MedicationData>(),
                                                                      investigations = new List<InvestigationData>(),
                                                                      diet = new List<DietData>(),
                                                                      ioChart = new List<IOChartData>(),
                                                                      surgeryProcedure = new List<surgeryProcedureData>(),
                                                                      pharmacyConsumableReplacement = new List<PharmacyConsumableReplacementData>(),
                                                                      coMorbitdityList = new List<Comorbodities>(),
                                                                      specialProcedureList = new List<SpecialProcedures>(),
                                                                      chiefComplaint=new List<CheifComplaint>()
                                                                  }).ToList().GroupBy(i => i.handOverCheckListId).Select(i => i.First()).ToList();




                    foreach (Handovercheclistdata CLD in offlinesyncData.getHandOverCheckListMaster)
                    {
                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_InvasiveLineId")) == CLD.HOC_InvasiveLineId).Distinct().ToList();
                        CLD.invasiveLines.AddRange((from row in DR
                                                    select new InvasiveLineData()
                                                    {
                                                        hocInvasiveLineId = Convert.ToString(row["HOC_InvasiveLineId"]),
                                                        peripheral = Convert.ToString(row["Peripheral"]),
                                                        central = Convert.ToString(row["Central"]),
                                                        PICC = Convert.ToString(row["PICC"]),
                                                        arterial = Convert.ToString(row["Arterial"]),
                                                        chemoport = Convert.ToString(row["Chemoport"]),
                                                        epidural = Convert.ToString(row["Epidural"]),
                                                        urinaryCatheters = Convert.ToString(row["urinaryCatheters"]),
                                                        urinaryDrain = Convert.ToString(row["urinaryDrain"]),

                                                    }).ToList().GroupBy(i => i.hocInvasiveLineId).Select(i => i.First()).ToList());


                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_CathetersId")) == CLD.HOC_CathetersId).ToList();
                        CLD.catheters.AddRange((from row in DR
                                                    select new CathetersData ()
                                                    {
                                                        hocCathetersId = Convert.ToString(row["HOC_CathetersId"]),
                                                        surgicalWound = Convert.ToString(row["SurgicalWound"]),
                                                        VAC = Convert.ToString(row["VAC"]),
                                                        tracheostomy = Convert.ToString(row["Tracheostomy"]),
                                                        pressureUlcer = Convert.ToString(row["PressureUlcer"]),
                                                        grade = Convert.ToString(row["Grade"]),
                                                        pressureRelievingAids = Convert.ToString(row["PressureRelievingAids"]),
                                                        comment = Convert.ToString(row["Comment"]),
                                                        informedTo = Convert.ToString(row["InformedTo"]),
                                                        dvtprophylaxis = Convert.ToString(row["DVTProphylaxis"]),
                                                        otherSpecialProcedures = Convert.ToString(row["urinaryDrain"]),
                                                        others = Convert.ToString(row["others"]),
                                                        specialProcedures = Convert.ToString(row["SpecialProcedures"]),

                                                    }).ToList().GroupBy(i => i.hocCathetersId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_CategoryOfPatientId")) == CLD.HOC_CategoryOfPatientId).ToList();
                        CLD.categoryOfPatient.AddRange((from row in DR
                                                        select new PatientCategory()
                                                {
                                                    hocCategoryOfPatientId = Convert.ToString(row["HOC_CategoryOfPatientId"]),
                                                    patientCriticalityLevelId = Convert.ToString(row["criticalityLevelId"]),
                                                    patientCriticalityLevel = Convert.ToString(row["PatientCriticalityLevel"]),


                                                }).ToList().GroupBy(i => i.hocCategoryOfPatientId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_VitalSignId")) == CLD.HOC_VitalSignId).ToList();
                        CLD.vitalSigns.AddRange((from row in DR
                                                        select new vitalSignData()
                                                        {
                                                            hocVitalSignId = Convert.ToString(row["HOC_VitalSignId"]),
                                                            temperature = Convert.ToString(row["Temperature"]),
                                                            pulse = Convert.ToString(row["Pulse"]),
                                                            systolic = Convert.ToString(row["Bp_Systolic"]),
                                                            diastolic = Convert.ToString(row["Bp_Diastolic"]),
                                                            RESP = Convert.ToString(row["resp"]),
                                                            painScore = Convert.ToString(row["PainScore"]),
                                                            weight = Convert.ToString(row["Weight"]),
                                                            restraints = Convert.ToString(row["Restraints"]),
                                                            restraintsConsent = Convert.ToString(row["RestraintsConsent"]),
                                                            o2Administration = Convert.ToString(row["O2Administration"]),
                                                            ltrperMin = Convert.ToString(row["LtrperMin"]),
                                                            mode = Convert.ToString(row["Mode"]),
                                                            SPO2 = Convert.ToString(row["SpO2"]),
                                                            grbsIfApplicable = Convert.ToString(row["GRBS_if_applicable"]),
                                                            gcsScore = Convert.ToString(row["GCS_Score"]),
                                                            metScoreMETPET = Convert.ToString(row["MET_Score_METPET"]),
                                                            metScore = Convert.ToString(row["MET_Score"]),
                                                            anxietyInsomaniaDiscomfort = Convert.ToString(row["Anxiety_Insomania_Discomfort"]),
                                                            incident = Convert.ToString(row["Incident"]),
                                                            nearMiss = Convert.ToString(row["NearMiss"]),
                                                            vitalFrequency = Convert.ToString(row["vitalFrequency"]),
                                                            bmi = Convert.ToString(row["bmi"]),
                                                            height = Convert.ToString(row["height"]),
                                                        }).ToList().GroupBy(i => i.hocVitalSignId).Select(i => i.First()).ToList());



                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_MedicationId")) == CLD.HOC_MedicationId).ToList();
                        CLD.medication.AddRange((from row in DR
                                                 select new MedicationData()
                                                {
                                                    hocMedicationId = Convert.ToString(row["HOC_MedicationId"]),
                                                    antibioticDescription = Convert.ToString(row["AntibioticDescription"]),
                                                    PCA = Convert.ToString(row["PCA"]),
                                                    impStdOrdrDr = Convert.ToString(row["ImpStdOrdrDr"]),
                                                    anticoagulants = Convert.ToString(row["Anticoagulants"]),
                                                    anticoagulantsDescription = Convert.ToString(row["AnticoagulantsDesc"]),
                                                    homeMedication = Convert.ToString(row["MedicineTranscribed"]),
                                                    highRiskMedication = Convert.ToString(row["highRiskMedication"]),
                                                    vaccinationPending = Convert.ToString(row["vaccinationPending"]),
                                                    medicineName = Convert.ToString(row["MedicineName"]),


                                                }).ToList().GroupBy(i => i.hocMedicationId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_InvestigationsId")) == CLD.HOC_InvestigationsId).ToList();
                        CLD.investigations.AddRange((from row in DR
                                                     select new InvestigationData()
                                                 {
                                                     hocInvestigationId = Convert.ToString(row["HOC_InvestigationsId"]),
                                                     labInvestigationsToBeDone = Convert.ToString(row["LabInvestigationsToBeDone"]),
                                                     labInvestigationsPending = Convert.ToString(row["LabInvestigationsPending"]),
                                                     criticalValues = Convert.ToString(row["CriticalValues"]),
                                                     radiologicalInvestigationsDone = Convert.ToString(row["RadiologicalInvestigationsDone"]),
                                                     radiologicalInvestigationsPending = Convert.ToString(row["RadiologicalInvestigationsPending"]),
                                                     vaccinationPending = Convert.ToString(row["VaccinationPending"]),

                                                 }).ToList().GroupBy(i => i.hocInvestigationId).Select(i => i.First()).ToList());
                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_DietId")) == CLD.HOC_DietId).ToList();
                        CLD.diet.AddRange((from row in DR
                                         select new DietData()
                                                     {
                                                         hocDietId = Convert.ToString(row["HOC_DietId"]),
                                                         typeOfDiet = Convert.ToString(row["TypeOfDiet"]),
                                                         otherDiettypes = Convert.ToString(row["otherDiettypes"]),
                                                         dietSpecification = Convert.ToString(row["DietSpecification"]),

                                                     }).ToList().GroupBy(i => i.hocDietId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_IOChartId")) == CLD.HOC_IOChartId).ToList();
                        CLD.ioChart.AddRange((from row in DR
                                           select new IOChartData()
                                           {
                                               hocIOChartId = Convert.ToString(row["HOC_IOChartId"]),
                                               ioChart = Convert.ToString(row["IOChart"]),
                                               totalIntake = Convert.ToString(row["TotalIntake"]),
                                               oralIvParental = Convert.ToString(row["OralIvParental"]),
                                               ivFluid = Convert.ToString(row["IVFluid"]),
                                               bloodProducts = Convert.ToString(row["Blood_BloodProducts"]),
                                               totalOutput = Convert.ToString(row["TotalOutput"]),
                                               bladderMovement = Convert.ToString(row["BladderMovement"]),
                                               bowelMovement = Convert.ToString(row["BowelMovement"]),
                                               vomittus = Convert.ToString(row["Vomittus"]),
                                               drain = Convert.ToString(row["Drain1_2"]),


                                           }).ToList().GroupBy(i => i.hocIOChartId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_SurgeryProcedureId")) == CLD.HOC_SurgeryProcedureId).ToList();
                        CLD.surgeryProcedure.AddRange((from row in DR
                                              select new surgeryProcedureData()
                                              {
                                                  hocSurgeryProcedureId = Convert.ToString(row["HOC_SurgeryProcedureId"]),
                                                  surgeryProcedure = Convert.ToString(row["SurgeryProcedure"]),
                                                  description = Convert.ToString(row["Description"]),
                                                  NPO = Convert.ToString(row["NPO"]),
                                                  timeSince = Convert.ToString(row["TimeSince"]),
                                                  consent = Convert.ToString(row["Consent"]),
                                                  preOpCheckListCompletion = Convert.ToString(row["PreOpCheckListCompletion"]),
                                                  skinPreparation = Convert.ToString(row["SkinPreparation"]),
                                                  premedication = Convert.ToString(row["Premedication"]),
                                                  medTime = Convert.ToString(row["Med_Time"]),
                                                  crossMatchReservBlood = Convert.ToString(row["CrossMatchReservBlood"]),
                                                  noofBloodUnitArranged = Convert.ToString(row["NoofBloodUnitArrgd"]),
                                                  surgicalSiteMarking = Convert.ToString(row["SurgicalSiteMarking"]),
                                                  doneorNot = Convert.ToString(row["DoneorNot"]),


                                              }).ToList().GroupBy(i => i.hocSurgeryProcedureId).Select(i => i.First()).ToList());
                        DR = offlineData.Tables[11].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("HOC_PharmacyConsumableReplacementId")) == CLD.HOC_PharmacyConsumableReplacementId).ToList();
                        CLD.pharmacyConsumableReplacement.AddRange((from row in DR
                                                       select new PharmacyConsumableReplacementData()
                                                       {
                                                           hocPharmacyConsumableReplacementId = Convert.ToString(row["HOC_PharmacyConsumableReplacementId"]),
                                                           PACRR = Convert.ToString(row["PACRR"]),
                                                           comments = Convert.ToString(row["anyOtherNotes"]),

                                                       }).ToList().GroupBy(i => i.hocPharmacyConsumableReplacementId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[29].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("patientId")) == CLD.patientId).ToList();
                        CLD.coMorbitdityList.AddRange((from row in DR
                                                       select new Comorbodities()
                                                                    {

                                                                        coMorbiditiesId = Convert.ToString(row["coMorbiditiesId"]),
                                                                        coMorbidities = Convert.ToString(row["coMorbidities"])

                                                                    }).ToList().GroupBy(i => i.coMorbiditiesId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[31].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("patientId")) == CLD.patientId).ToList();
                        CLD.specialProcedureList.AddRange((from row in DR
                                                           select new SpecialProcedures()
                                                       {

                                                           specialProcedureId = Convert.ToString(row["specialProcedureId"]),
                                                           specialProcedures = Convert.ToString(row["specialProcedures"])

                                                       }).ToList().GroupBy(i => i.specialProcedureId).Select(i => i.First()).ToList());

                        DR = offlineData.Tables[30].AsEnumerable().Where(r => Convert.ToString(r.Field<Int32?>("patientId")) == CLD.patientId).ToList();
                        CLD.chiefComplaint.AddRange((from row in DR
                                                           select new CheifComplaint()
                                                           {

                                                               conditionId = Convert.ToString(row["conditionId"]),
                                                               condition = Convert.ToString(row["condition"])

                                                           }).ToList().GroupBy(i => i.conditionId).Select(i => i.First()).ToList());

                    }



                    // Lab report
                    DT = offlineData.Tables[12];
                     
                    offlinesyncData.getLabReport = (from DataRow row in DT.Rows

                                                    select new LabReportData
                                                    {

                                                        investigationsId = Convert.ToString(row["universalServiceId"]),
                                                        doctorStatus = Convert.ToString(row["doctorStatus"]),
                                                        investigationProcedure = Convert.ToString(row["universalServiceText"]),
                                                        LabReportStatus = Convert.ToString(row["resultStatus"]),
                                                        orderedDate = Convert.ToString(row["requestedDateTime"]),
                                                        reportGeneratedDate = Convert.ToString(row["resultRPTStatusChngDateTime"]),
                                                        placeOrderEntityIdentifier = Convert.ToString(row["placeOrderEntityIdentifier"]),  
                                                        fillerOrderEntityIdentifier = Convert.ToString(row["fillerOrderEntityIdentifier"]),  
                                                        investigationDetailedReport=new List<InvestigationDetailedData>()
                                                    }).ToList();

                    foreach (LabReportData LRD in offlinesyncData.getLabReport)
                    {
                        DR = offlineData.Tables[28].AsEnumerable().Where(r => (Convert.ToString(r.Field<string>("groupOrderId")) == LRD.fillerOrderEntityIdentifier ||
                            Convert.ToString(r.Field<string>("groupOrderId")) == LRD.placeOrderEntityIdentifier)).ToList();
                        LRD.investigationDetailedReport.AddRange((from row in DR
                                                           select new InvestigationDetailedData()
                                                           {
                                                               abnormalFlags = Convert.ToString(row["AbnormalFlags"]),
                                                               effectiveDate = Convert.ToString(row["EffectiveDateRefvalue"]),
                                                               investigationDetailedId = Convert.ToString(row["Lab_Detailed_ID"]),
                                                               observationDate = Convert.ToString(row["ObservationDate"]),
                                                               observationStatus = Convert.ToString(row["ObservationStatus"]),
                                                               observationValue = Convert.ToString(row["ObservationValue"]),
                                                               referenceRange = Convert.ToString(row["ReferenceRange"]),
                                                               reportItemId = Convert.ToString(row["ReportItemID"]),
                                                               reportItemText = Convert.ToString(row["ReportItemText"]),
                                                               units = Convert.ToString(row["Units"]),
                                                               valueType = Convert.ToString(row["ValueType"]),

                                                           }).ToList());

                    }
                    // Patient Notes
                    DT = offlineData.Tables[13];
                    offlinesyncData.getpatientNotes = (from DataRow row in DT.Rows

                                                       select new PatientNotesData
                                                       {

                                                           patientId = Convert.ToString(row["PatientId"]),
                                                           notesId = Convert.ToString(row["NotesId"]),
                                                           modifiedDate = Convert.ToString(row["modifiedDate"]),
                                                           //modifiedByProfile = Convert.ToString(row["coMorbidities"]),
                                                           //modifiedById = Convert.ToString(row["NurseId"]),
                                                           modifiedBy = Convert.ToString(row["modifiedBy"]),
                                                           doctorId = Convert.ToString(row["DoctorId"]),
                                                           createdDate = Convert.ToString(row["CreatedDate"]),
                                                           createdById = Convert.ToString(row["NurseId"]),
                                                           content = Convert.ToString(row["Content"]),
                                                       }).ToList();


                    // Bio medical Equipment Report
                    DT = offlineData.Tables[14];
                    offlinesyncData.getBioMedicEquipReport = (from DataRow row in DT.Rows

                                                              select new BioMedicalEquipData
                                                              {

                                                                  billingType = Convert.ToString(row["billingType"]),
                                                                  bioMedicalEquipmentCategory = Convert.ToString(row["BioMedicEquipCategory"]),
                                                                  bioMedicalEquipmentName = Convert.ToString(row["BioMedicEquipName"]),
                                                                  bioMedicalEquipPlacedId = Convert.ToString(row["BioMedicalEquipPlacedId"]),
                                                                  checkedInBy = Convert.ToString(row["NurseId"]),
                                                                  checkedInDate = Convert.ToString(row["CheckInTime"]),
                                                                  checkedOutDate = Convert.ToString(row["CheckOutTime"]),
                                                                  // consumedHours = Convert.ToString(row["CreatedDate"]),
                                                                  deviceEndtime = Convert.ToString(row["DeviceEndTime"]),
                                                                  deviceStartTime = Convert.ToString(row["DeviceStartTime"]),
                                                                  equipId = Convert.ToString(row["BioMedicEquipId"]),
                                                                  equipSource = Convert.ToString(row["equipSource"]),
                                                                  modifiedBy = Convert.ToString(row["ModifiedBy"]),
                                                                  orderedBy = Convert.ToString(row["RequestedBy"]),
                                                                  orderedDate = Convert.ToString(row["RequestedDate"]),
                                                                  status = Convert.ToString(row["BioMedicalEquipStatus"]),
                                                                  equipmentReturned = Convert.ToString(row["equipmentReturned"])
                                                              }).ToList();



                    // Bio medical List
                    DT = offlineData.Tables[15];
                    offlinesyncData.getBioMedicList = (from DataRow row in DT.Rows

                                                       select new BioMedicEquipInfo
                                                       {

                                                           billingType = Convert.ToString(row["billingType"]),
                                                           bioMedicEquipId = Convert.ToString(row["BioMedicEquipId"]),
                                                           bioMedicEquipName = Convert.ToString(row["BioMedicEquipName"]),
                                                           eqipmentCategory = Convert.ToString(row["BioMedicEquipCategory"]),

                                                       }).ToList();


                    // Get Medicine By patient
                    DT = offlineData.Tables[16];
                    offlinesyncData.getMedicineByPatient = (from DataRow row in DT.Rows

                                                            select new MedicineBypatientData
                                                            {

                                                                administeredQty = Convert.ToString(row["administeredQty"]),
                                                                dosage = Convert.ToString(row["dosage"]),
                                                                doseUnit = Convert.ToString(row["doseUnit"]),
                                                                drugId = Convert.ToString(row["drugId"]),
                                                                drugName = Convert.ToString(row["drugName"]),
                                                                frequency = Convert.ToString(row["frequency"]),
                                                                medicineFollowingPatientId = Convert.ToString(row["MedicineFollowingPatientId"]),
                                                                quantity = Convert.ToString(row["quantity"]),

                                                            }).ToList();


                    // Bio patient return medicine
                    DT = offlineData.Tables[17];
                    offlinesyncData.getReturnMedicineByPatient = (from DataRow row in DT.Rows

                                                                  select new MedicineReturnBypatientData
                                                                  {

                                                                      medicineName = Convert.ToString(row["medicineName"]),
                                                                      quantity = Convert.ToString(row["quantity"]),
                                                                      returnedBy = Convert.ToString(row["returnedBy"]),
                                                                      returnedDate = Convert.ToString(row["returnedDate"]),
                                                                      returnId = Convert.ToString(row["WardStockReturnId"]),
                                                                      returnTo = Convert.ToString(row["returnTo"]),


                                                                  }).ToList();

                    // Get Pharma Ward
                    DT = offlineData.Tables[18];
                    offlinesyncData.getPharmaByWard = (from DataRow row in DT.Rows

                                                       select new MedicineStockData
                                                       {

                                                           name = Convert.ToString(row["WardStockName"]),
                                                           quantity = Convert.ToString(row["Qty"]),
                                                           updatedDate = Convert.ToString(row["CreatedDate"]),

                                                       }).ToList();


                    // Get non Pharma Ward
                    DT = offlineData.Tables[19];
                    offlinesyncData.getNonPharmaByWard = (from DataRow row in DT.Rows

                                                          select new MedicineStockData
                                                          {

                                                              name = Convert.ToString(row["WardStockName"]),
                                                              quantity = Convert.ToString(row["Qty"]),
                                                              updatedDate = Convert.ToString(row["CreatedDate"]),

                                                          }).ToList();


                    // Get patient consumable
                    DT = offlineData.Tables[20];
                    offlinesyncData.getPatientConsumableByWard = (from DataRow row in DT.Rows

                                                                  select new MedicineStockData
                                                                  {

                                                                      name = Convert.ToString(row["WardStockName"]),
                                                                      quantity = Convert.ToString(row["Qty"]),
                                                                      updatedDate = Convert.ToString(row["CreatedDate"]),

                                                                  }).ToList();


                    // Get ward consumable
                    DT = offlineData.Tables[21];
                    offlinesyncData.getWardConsumableByWard = (from DataRow row in DT.Rows

                                                               select new MedicineStockData
                                                               {

                                                                   name = Convert.ToString(row["WardStockName"]),
                                                                   quantity = Convert.ToString(row["Qty"]),
                                                                   updatedDate = Convert.ToString(row["CreatedDate"]),

                                                               }).ToList();


                    // Get non consumable
                    DT = offlineData.Tables[22];
                    offlinesyncData.getNonConsumableByWard = (from DataRow row in DT.Rows

                                                              select new MedicineStockData
                                                              {

                                                                  name = Convert.ToString(row["WardStockName"]),
                                                                  quantity = Convert.ToString(row["Qty"]),
                                                                  updatedDate = Convert.ToString(row["CreatedDate"]),

                                                              }).ToList();


                    // Get Pharma Ward
                    DT = offlineData.Tables[23];

                    StockListByDate stockData = new StockListByDate();
                    List<MedicineStockbydate> data = (from DataRow row in DT.Rows

                                                      select new MedicineStockbydate
                                                         {

                                                             name = Convert.ToString(row["WardStockName"]),
                                                             quantity = Convert.ToString(row["Qty"]),
                                                             updatedDate = Convert.ToString(row["CreatedDate"]),
                                                             categoryId = Convert.ToString(row["WardStockCategoryId"]),
                                                             CategoryName = Convert.ToString(row["WardStockCategoryName"]),

                                                         }).Where(c => c.CategoryName == "Pharma").ToList();
                    stockData.pharma = data;

                    data = (from DataRow row in DT.Rows

                            select new MedicineStockbydate
                            {

                                name = Convert.ToString(row["WardStockName"]),
                                quantity = Convert.ToString(row["Qty"]),
                                updatedDate = Convert.ToString(row["CreatedDate"]),
                                categoryId = Convert.ToString(row["WardStockCategoryId"]),
                                CategoryName = Convert.ToString(row["WardStockCategoryName"]),

                            }).Where(c => c.CategoryName == "Non-Pharma").ToList();
                    stockData.nonPharma = data;

                    data = (from DataRow row in DT.Rows

                            select new MedicineStockbydate
                            {

                                name = Convert.ToString(row["WardStockName"]),
                                quantity = Convert.ToString(row["Qty"]),
                                updatedDate = Convert.ToString(row["CreatedDate"]),
                                categoryId = Convert.ToString(row["WardStockCategoryId"]),
                                CategoryName = Convert.ToString(row["WardStockCategoryName"]),

                            }).Where(c => c.CategoryName == "Patient-Consumable").ToList();
                    stockData.patientConsumable = data;

                    data = (from DataRow row in DT.Rows

                            select new MedicineStockbydate
                            {

                                name = Convert.ToString(row["WardStockName"]),
                                quantity = Convert.ToString(row["Qty"]),
                                updatedDate = Convert.ToString(row["CreatedDate"]),
                                categoryId = Convert.ToString(row["WardStockCategoryId"]),
                                CategoryName = Convert.ToString(row["WardStockCategoryName"]),

                            }).Where(c => c.CategoryName == "Ward-Consumable").ToList();
                    stockData.wardConsumable = data;
                    data = (from DataRow row in DT.Rows

                            select new MedicineStockbydate
                            {

                                name = Convert.ToString(row["WardStockName"]),
                                quantity = Convert.ToString(row["Qty"]),
                                updatedDate = Convert.ToString(row["CreatedDate"]),
                                categoryId = Convert.ToString(row["WardStockCategoryId"]),
                                CategoryName = Convert.ToString(row["WardStockCategoryName"]),

                            }).Where(c => c.CategoryName == "Non-Consumable").ToList();
                    stockData.nonConsumable = data;

                    offlinesyncData.getStockListByDate = new List<StockListByDate>() { stockData };

                    // Get Inbox
                    DT = offlineData.Tables[24];
                    offlinesyncData.GetInboxMail = (from DataRow row in DT.Rows

                                                    select new InboxData
                                                              {

                                                                  emailBody = Convert.ToString(row["EmailBody"]),
                                                                  emailFrom = Convert.ToString(row["EmailFrom"]),
                                                                  emailSubject = Convert.ToString(row["EmailSubject"]),
                                                                  emailTo = Convert.ToString(row["EmailTo"]),
                                                                  important = Convert.ToString(row["important"]),
                                                                  loopMailId = Convert.ToString(row["loopMailId"]),
                                                                  mailedDate = Convert.ToString(row["CreatedDate"]),
                                                                  //profileURL = Convert.ToString(row["CreatedDate"]),
                                                                  readMail = Convert.ToString(row["readMail"]),
                                                                  // repliedBy = Convert.ToString(row["CreatedDate"]),
                                                                  sendBy = Convert.ToString(row["CreatedBy"]),
                                                                  sendTo = Convert.ToString(row["EmailTo"]),
                                                                  sentEmailHistoryId = Convert.ToString(row["SentEmailHistoryID"]),

                                                              }).ToList().GroupBy(i => i.sentEmailHistoryId).Select(i => i.First()).ToList();

                    // Get reply mail
                    DT = offlineData.Tables[25];
                    offlinesyncData.getEmailHistoryForNurse = (from DataRow row in DT.Rows

                                                               select new InboxData
                                                               {

                                                                   emailBody = Convert.ToString(row["EmailBody"]),
                                                                   emailFrom = Convert.ToString(row["EmailFrom"]),
                                                                   emailSubject = Convert.ToString(row["EmailSubject"]),
                                                                   emailTo = Convert.ToString(row["EmailTo"]),
                                                                   important = Convert.ToString(row["important"]),
                                                                   loopMailId = Convert.ToString(row["loopMailId"]),
                                                                   mailedDate = Convert.ToString(row["CreatedDate"]),
                                                                   //profileURL = Convert.ToString(row["CreatedDate"]),
                                                                   readMail = Convert.ToString(row["readMail"]),
                                                                   // repliedBy = Convert.ToString(row["CreatedDate"]),
                                                                   sendBy = Convert.ToString(row["CreatedBy"]),
                                                                   sendTo = Convert.ToString(row["EmailTo"]),
                                                                   sentEmailHistoryId = Convert.ToString(row["SentEmailHistoryID"]),

                                                               }).ToList().GroupBy(i => i.sentEmailHistoryId).Select(i => i.First()).ToList();

                    // Get Inbox
                    DT = offlineData.Tables[26];
                    offlinesyncData.GetReplyMail = (from DataRow row in DT.Rows

                                                    select new InboxData
                                                    {

                                                        emailBody = Convert.ToString(row["EmailBody"]),
                                                        emailFrom = Convert.ToString(row["EmailFrom"]),
                                                        emailSubject = Convert.ToString(row["EmailSubject"]),
                                                        emailTo = Convert.ToString(row["EmailTo"]),
                                                        important = Convert.ToString(row["important"]),
                                                        loopMailId = Convert.ToString(row["loopMailId"]),
                                                        mailedDate = Convert.ToString(row["CreatedDate"]),
                                                        //profileURL = Convert.ToString(row["CreatedDate"]),
                                                        readMail = Convert.ToString(row["readMail"]),
                                                        // repliedBy = Convert.ToString(row["CreatedDate"]),
                                                        sendBy = Convert.ToString(row["CreatedBy"]),
                                                        sendTo = Convert.ToString(row["EmailTo"]),
                                                        sentEmailHistoryId = Convert.ToString(row["SentEmailHistoryID"]),

                                                    }).ToList().GroupBy(i => i.sentEmailHistoryId).Select(i => i.First()).ToList();
                    // Nursing manager Shift
                    DT = offlineData.Tables[27];
                    offlinesyncData.nursingmanagershift = (from DataRow row in DT.Rows

                                                           select new NursingManagerShiftData
                                                           {
                                                               shiftId = Convert.ToString(row["shiftId"])

                                                           }).ToList();



                }

                return offlinesyncData;
            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(@"C:\" + "log.txt", ex.InnerException.ToString());
            //    File.AppendAllText(@"C:\" + "log.txt", ex.StackTrace);
            //    throw ex;
            //}
        }
        
    }
}
