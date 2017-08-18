using NurseAppAdmin.DataModel;
using NurseAppAdmin.Utility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NurseAppAdmin.DataLayer
{
   public class OfflineSyncDL
    {
       public DataSet GetOfflineSyncData(int nurseID)
       {
           DataSet checkListData = new DataSet();
           SqlParameter[] param = {
                                       new SqlParameter("@NurseId",SqlDbType.SmallInt){Value=nurseID},
                                       
                                 
                                   
                                   };
           DataSet result = Utility.SqlHelper.ExecuteDataset(Utility.Utility.GetDatabaseconnectionString(), Query.GetOfflineSync, param);
           return result;
       }

    }
}
