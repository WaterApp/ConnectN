using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ConnectNAPI.Utility;
using System.Data.SqlClient;

namespace ConnectNAPI.Core
{
    public class DataAccess
    {
        public DataSet GetPatientData()
        {
            DataSet patientData = new DataSet();
             SqlParameter[] param = {
                                 
                                    
                                   };
             patientData = Utility.SqlHelper.ExecuteDataset(Utility.Utility.GetDatabaseconnectionString(),System.Data.CommandType.StoredProcedure, Query.GetPatientdata);
             return patientData;
        }
    }
}
