using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using NurseAppAdmin.DataModel;
using NurseAppAdmin.BusinessLayer;

namespace NurseAppAdmin.API.Controllers
{
    public class OfflineSyncController : ApiController
    {
        OfflineSyncBusinessLayer _offlineSyncBL;
        public OfflineSyncController()
        {
            _offlineSyncBL=new OfflineSyncBusinessLayer();
        }

        public void GetJsonData()
        {
            string jsonFile = System.IO.File.ReadAllText(@"C:\Users\HOME\Documents\GitHub\JsonData\JSON.txt");
            ExtractJsonData(jsonFile);
        }

        public void ExtractJsonData(string jsonData)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
                OfflineSync offlineData = serializer.Deserialize<OfflineSync>(jsonData);
        }
        

        [HttpPost]
        public HttpResponseMessage ExractJSOnData()
        {
            GetJsonData();
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        [HttpPost]
        public HttpResponseMessage GetNurseData([FromBody]string NurseID)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _offlineSyncBL.GetOfflineSyncData(Convert.ToInt32(NurseID)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.ToString());
            }
        }
    }
}
