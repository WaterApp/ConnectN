using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NurseAppAdmin.DataModel;
using System.Data;
using NurseAppAdmin.DataLayer;


namespace NurseAppAdmin.BusinessLayer
{
    public class AdminBusinessLayer
    {
        AdminDL adminDL = null;
        public AdminBusinessLayer()
        {
            adminDL = new AdminDL();
        }
        public List<CheckListItemAndData> GetCheckListData(string Type, string WardID, string UserID, string ShiftID)
        {
            DataSet objDS = new DataSet();

            objDS = adminDL.GetCheckListData(Type, WardID, UserID, ShiftID);
            List<CheckListItemAndData> chkItemDataList = new List<CheckListItemAndData>();
            CheckListItemAndData chkItemData = null;
            int prevItemId = 0;
            if(objDS.Tables.Count>0)
            {
                foreach( DataRow row in objDS.Tables[0].Rows )
                {


                    if (prevItemId != Convert.ToInt32(row[0]))
                    {

                        chkItemData = new CheckListItemAndData();
                        chkItemData.Options = new List<CheckListOptions>();
                        prevItemId = Convert.ToInt32(row[0]);
                        chkItemData.CheckListItemId = Convert.ToInt32(row[0]);
                        chkItemData.CheckListItemName = row[1].ToString();
                        chkItemData.ChecklistType = row[2].ToString();
                        chkItemData.ControlType = row[3].ToString();
                        if (objDS.Tables.Count > 1)
                        {
                            chkItemData.CheckListData = objDS.Tables[1].AsEnumerable().Where(f => f.Field<int>("CheckListItemId") == prevItemId).Select(m => new KeyValuePair()
    {
        Key = m.Field<string>("CheckListDataID"),
        Value = m.Field<string>("CheckListData")

    }).ToList();
                        }



                        if (Convert.ToString(row[4]) != string.Empty)
                        {
                            chkItemData.Options = objDS.Tables[0].AsEnumerable().Where(f => f.Field<int>("CheckListItemId") == prevItemId).Select(m => new CheckListOptions()
                            {
                                CheckListOptionsID = m.Field<int>("OptionsItemID").ToString(),
                                CheckListOptionsValue = m.Field<string>("OptionValue")

                            }).ToList();
                            // chkItemData.Options.Add(new KeyValuePair() { Key = Convert.ToString(row[4]), Value = Convert.ToString(row[5]) });
                        }

                        chkItemDataList.Add(chkItemData);
                    }
                }

            }
            return  chkItemDataList;
        }

        public string InsertUpdateChecklistData(string WardID, string Date, string UserID, string ShiftID, List<CheckListData> Data)
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("CheckListDataItemID", typeof(int));
            DT.Columns.Add("CheckListItemID", typeof(int));
            DT.Columns.Add("CheckListData", typeof(string));

            foreach (CheckListData dat in Data)
            {
                DT.Rows.Add(dat.CheckListDataID, dat.CheckListDataItemID, dat.CheckListDatavalue);
            }

            return adminDL.InsertUpdateChecklistData(WardID, Date, UserID, ShiftID, DT).ToString();
        }

        public List<CheckListTypeContent> GetCheckListType()
        {

            DataSet objDS = adminDL.GetCheckListType();
            List<CheckListTypeContent> CheckListPair = new List<CheckListTypeContent>();
            if (objDS.Tables.Count > 0)
            {
                CheckListPair = objDS.Tables[0].AsEnumerable().Select(m => new CheckListTypeContent()
                 {
                     Key = m.Field<int>("ConfigItemID").ToString(),
                     Value = m.Field<string>("ConfigItemName"),
                     IsActive = m.Field<int>("isActive")

                 }).ToList();
            }
            return CheckListPair;
        }

        public List<CheckListItemAndData> GetCheckListItems(string Type)
        {
            DataSet objDS = new DataSet();

            objDS = adminDL.GetCheckListItems(Type);
            List<CheckListItemAndData> chkItemDataList = new List<CheckListItemAndData>();
            CheckListItemAndData chkItemData = null;
            int prevItemId = 0;
            if (objDS.Tables.Count > 0)
            {
                foreach (DataRow row in objDS.Tables[0].Rows)
                {


                    if (prevItemId != Convert.ToInt32(row[0]))
                    {

                        chkItemData = new CheckListItemAndData();
                        chkItemData.Options = new List<CheckListOptions>();
                        prevItemId = Convert.ToInt32(row[0]);
                        chkItemData.CheckListItemId = Convert.ToInt32(row[0]);
                        chkItemData.CheckListItemName = row[1].ToString();
                        chkItemData.ChecklistType = row[2].ToString();
                        chkItemData.ControlType = row[3].ToString();
                        chkItemData.IsActive = row[6].ToString();
                        
                        if (Convert.ToString(row[4]) != string.Empty)
                        {
                            chkItemData.Options = objDS.Tables[0].AsEnumerable().Where(f => f.Field<int>("CheckListItemId") == prevItemId).Select(m => new CheckListOptions()
                            {
                                CheckListOptionsID = m.Field<int>("OptionsItemID").ToString(),
                                CheckListOptionsValue = m.Field<string>("OptionValue")

                            }).ToList();
                            // chkItemData.Options.Add(new KeyValuePair() { Key = Convert.ToString(row[4]), Value = Convert.ToString(row[5]) });
                        }

                        chkItemDataList.Add(chkItemData);
                    }
                }

            }
            return chkItemDataList;
        }


        public string InsertUpdateCheckListItems(string ChecklistItemId, string CheckListItemName, string CHeckListControlType, 
            string checkListType, string UserID, string isActive, List<CheckListOptions> checklistItemOptions)
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("CheckListOptionsID", typeof(int));
            DT.Columns.Add("CheckListOptionsValue", typeof(string));

            foreach (CheckListOptions dat in checklistItemOptions)
            {
                DT.Rows.Add((dat.CheckListOptionsID == "") ? 0 : Convert.ToInt32(dat.CheckListOptionsID), dat.CheckListOptionsValue);
            }
            return adminDL.InsertUpdateCheckListItems(ChecklistItemId, CheckListItemName, checkListType, CHeckListControlType, UserID, isActive, DT).ToString();
        }
        //public int InsertUpdateOptions(CheckListOptions checkListOptions)
        //{
        //    return adminDL.InsertUpdateOptions(checkListOptions);
        //}

        public int DeleteOptions(CheckListOptions checkListOptions)
        {
            return adminDL.DeleteOptions(checkListOptions);
        }
        public int DeleteCheckListItem(string CheckListItemID)
        {
            return adminDL.DeleteCheckListItem(CheckListItemID);
        }
        public int CreateUpdateConfigHeader(int configID, string configName, int isActive, int userID)
        {
            return adminDL.CreateUpdateConfigHeader(configID,configName,isActive,userID);
        }
        public int DeleteConfigHeader(string configID)
        {
            return adminDL.DeleteConfigHeader(Convert.ToInt32( configID));
        }

        public List<KeyValuePair> GetWarddetails()
        {
            DataSet wardDS= adminDL.GetWarddetails();
            List<KeyValuePair> wardDetails = null;
            if (wardDS.Tables.Count > 0)
            {
                wardDetails = wardDS.Tables[0].AsEnumerable().Select(m => new KeyValuePair()
                {
                    Key = m.Field<int>("WardId").ToString(),
                    Value = m.Field<string>("WardName")

                }).ToList();
            }
            return wardDetails;
        }

        public List<CheckListItemAndData> GetChecklistWardMappingMasterData(string Type, string WardID)
        {
            DataSet wardMappingDataSet = adminDL.GetChecklistWardMappingMasterData(Type, WardID);
            List<CheckListItemAndData> chkItemDataList = new List<CheckListItemAndData>();
            CheckListItemAndData chkItemData = null;
            int prevItemId = 0;
            if (wardMappingDataSet.Tables.Count > 0)
            {
                foreach (DataRow row in wardMappingDataSet.Tables[0].Rows)
                {


                    if (prevItemId != Convert.ToInt32(row[0]))
                    {

                        chkItemData = new CheckListItemAndData();
                        chkItemData.Options = new List<CheckListOptions>();
                        prevItemId = Convert.ToInt32(row[0]);
                        chkItemData.CheckListItemId = Convert.ToInt32(row[0]);
                        chkItemData.CheckListItemName = row[1].ToString();
                        chkItemData.ChecklistType = row[2].ToString();
                        chkItemData.ControlType = row[3].ToString();
                        chkItemData.IsActive = row[6].ToString();

                        if (Convert.ToString(row[4]) != string.Empty)
                        {
                            chkItemData.Options = wardMappingDataSet.Tables[0].AsEnumerable().Where(f => f.Field<int>("CheckListItemId") == prevItemId).Select(m => new CheckListOptions()
                            {
                                CheckListOptionsID = m.Field<int>("OptionsItemID").ToString(),
                                CheckListOptionsValue = m.Field<string>("OptionValue")

                            }).ToList();
                            // chkItemData.Options.Add(new KeyValuePair() { Key = Convert.ToString(row[4]), Value = Convert.ToString(row[5]) });
                        }

                        chkItemDataList.Add(chkItemData);
                    }
                }

            }
            return chkItemDataList;
        }


        public int CreateUpdateCheckListDataMapping(string WardID, string UserID, List<CheckListWardMapping> data)
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("CheckListMapID", typeof(int));
            DT.Columns.Add("CheckListItemId", typeof(int));
            DT.Columns.Add("Isdeleted", typeof(int));
            DT.Columns.Add("orderNo", typeof(int));

            foreach (CheckListWardMapping dat in data)
            {
                DT.Rows.Add(dat.CheckListMapID, dat.CheckListItemID, dat.Isdeleted,dat.orderNo);
            }
            return adminDL.CreateUpdateCheckListDataMapping(WardID,UserID,DT);
        }
        
    }
    
}
