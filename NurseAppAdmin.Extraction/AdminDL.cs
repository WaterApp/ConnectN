using NurseAppAdmin.DataModel;
using NurseAppAdmin.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NurseAppAdmin.DataLayer
{
    public class AdminDL
    {
        public DataSet GetCheckListData(string Type, string WardID, string UserID, string ShiftID)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {

                                 new SqlParameter("@Type",SqlDbType.Text){Value=Type},
                                 new SqlParameter("@WardID",SqlDbType.SmallInt){Value=WardID},
                                 new SqlParameter("@UserID",SqlDbType.SmallInt){Value=UserID},
                                 new SqlParameter("@ShiftId",SqlDbType.SmallInt){Value=ShiftID},
                                   
                                   };
            checkListData = Utility.SqlHelper.ExecuteDataset(Utility.Utility.GetDatabaseconnectionString(), System.Data.CommandType.StoredProcedure, Query.GetChecklistData, param);
            return checkListData;
        }

        public int InsertUpdateChecklistData(string WardID, string Date, string UserID, string ShiftID, DataTable Data)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       new SqlParameter("@WardID",SqlDbType.SmallInt){Value=WardID},
                                       new SqlParameter("@UserID",SqlDbType.SmallInt){Value=UserID},
                                       new SqlParameter("@ShiftId",SqlDbType.SmallInt){Value=ShiftID},
                                 new SqlParameter("@Data",SqlDbType.Structured){TypeName="[Dbo].[ChecklistDataModel]", Value=Data},
                                 new SqlParameter("@Date",SqlDbType.Text){Value=Date},
                                   
                                   };
            int result = Utility.SqlHelper.ExecuteNonQuery(Utility.Utility.GetDatabaseconnectionString(), Query.InsertUpdateCheckListData, param);
            return result;
        }


        public DataSet GetCheckListType()
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {                               
                                   
                                   };
            checkListData = Utility.SqlHelper.ExecuteDataset(Utility.Utility.GetDatabaseconnectionString(), System.Data.CommandType.StoredProcedure, Query.GetCheckListType, param);
            return checkListData;
        }

        public DataSet GetCheckListItems(string Type)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {

                                 new SqlParameter("@Type",SqlDbType.Text){Value=Type}
                                
                                   };
            checkListData = Utility.SqlHelper.ExecuteDataset(Utility.Utility.GetDatabaseconnectionString(), System.Data.CommandType.StoredProcedure, Query.GetCheckListItems, param);
            return checkListData;
        }

        public int InsertUpdateCheckListItems(string ChecklistItemId, string CheckListItemName, string checkListType, string CHeckListControlType,
            string UserID, string isActive, DataTable data)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       new SqlParameter("@ChecklistItemId",SqlDbType.Int){Value=(ChecklistItemId==string.Empty ||ChecklistItemId==null)?0:Convert.ToInt32(ChecklistItemId)},
                                       new SqlParameter("@ChecklistItem",SqlDbType.Text){Value=CheckListItemName},
                                       new SqlParameter("@CheckListType",SqlDbType.Text){Value=checkListType},
                                       new SqlParameter("@CHeckListControlType",SqlDbType.Text){Value=CHeckListControlType},                                       
                                       new SqlParameter("@Options",SqlDbType.Structured){TypeName="[Dbo].[ChecklistOptions]", Value=data},
                                       new SqlParameter("@isActive",SqlDbType.Int){Value=(isActive=="True")?1:0},
                                 new SqlParameter("@UserID",SqlDbType.Int){ Value= Convert.ToInt32(UserID)}
                                 
                                   
                                   };
            int result = Utility.SqlHelper.ExecuteNonQuery(Utility.Utility.GetDatabaseconnectionString(), Query.InsertUpdateCheckListItems, param);
            return result;
        }

        public int CreateUpdateCheckListDataMapping(string WardID,string UserID,   DataTable data)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       
                                       new SqlParameter("@WardID",SqlDbType.Int){Value=WardID},
                                       new SqlParameter("@UserID",SqlDbType.Int){ Value= Convert.ToInt32(UserID)},                                                                            
                                       new SqlParameter("@Data",SqlDbType.Structured){TypeName="[Dbo].[ChecklistWardDataModel]", Value=data}
                                                              
                                   };
            int result = Utility.SqlHelper.ExecuteNonQuery(Utility.Utility.GetDatabaseconnectionString(), Query.CreateUpdateCheckListDataMapping, param);
            return result;
        }

        public DataSet GetChecklistWardMappingMasterData(string Type, string WardID)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       
                                       new SqlParameter("@Type",SqlDbType.Text){Value=Type},
                                       new SqlParameter("@WardID",SqlDbType.Int){ Value= Convert.ToInt32(WardID)},                                                                            

                                                              
                                   };
            return Utility.SqlHelper.ExecuteDataset(Utility.Utility.GetDatabaseconnectionString(), Query.GetChecklistWardMappingMasterData, param);
            
        }

        public DataSet GetWarddetails()
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                   
                                   };
            return Utility.SqlHelper.ExecuteDataset(Utility.Utility.GetDatabaseconnectionString(), Query.GetWarddetails, param);
            
        }

        public int DeleteOptions(CheckListOptions checkListOptions)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       new SqlParameter("@OptionsItemId",SqlDbType.Int){Value=checkListOptions.CheckListOptionsID},
                                       new SqlParameter("@optionValue",SqlDbType.Text){Value=checkListOptions.CheckListOptionsValue},                                       
                                       new SqlParameter("@isDeleted",SqlDbType.Int){ Value=1},
                                  new SqlParameter("@userID",SqlDbType.Int){Value=1},

                                   };
            int result = Utility.SqlHelper.ExecuteNonQuery(Utility.Utility.GetDatabaseconnectionString(), Query.DeleteOptions, param);
            return result;

        }
        public int DeleteCheckListItem(string CheckListItemID)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       new SqlParameter("@CheckListItemID",SqlDbType.Int){Value= Convert.ToInt32(CheckListItemID)},
                                  new SqlParameter("@userID",SqlDbType.Int){Value=1},

                                   };
            int result = Utility.SqlHelper.ExecuteNonQuery(Utility.Utility.GetDatabaseconnectionString(), Query.DeleteCheckListItem, param);
            return result;

        }

        public int CreateUpdateConfigHeader(int configID, string configName, int isActive, int userID)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       new SqlParameter("@ConfigID",SqlDbType.SmallInt){Value=configID},
                                       new SqlParameter("@ConfigName",SqlDbType.Text){Value=configName},
                                       new SqlParameter("@IsActive",SqlDbType.SmallInt){Value=isActive},
                                       new SqlParameter("@userId",SqlDbType.SmallInt){Value=userID},
                                 
                                   
                                   };
            int result = Utility.SqlHelper.ExecuteNonQuery(Utility.Utility.GetDatabaseconnectionString(), Query.CreateUpdateConfigHeader, param);
            return result;
        }
        public int DeleteConfigHeader(int configID)
        {
            DataSet checkListData = new DataSet();
            SqlParameter[] param = {
                                       new SqlParameter("@ConfigID",SqlDbType.SmallInt){Value=configID},
                                       
                                 
                                   
                                   };
            int result = Utility.SqlHelper.ExecuteNonQuery(Utility.Utility.GetDatabaseconnectionString(), Query.DeleteConfigHeader, param);
            return result;
        }

    }
}
