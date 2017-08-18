using System.Net;
using System.Net.Http;
using System.Web.Http;
using NurseAppAdmin.BusinessLayer;
using NurseAppAdmin.DataModel;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NurseAppAdmin.API
{
    
    public class AdminController : ApiController
    {
        AdminBusinessLayer adminBL = null;
        public AdminController()
        {
            adminBL = new AdminBusinessLayer();
        }
        [HttpPost]
        public HttpResponseMessage GetChecklistData( string Type, string WardID,  string UserID,  string ShiftID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, adminBL.GetCheckListData(Type, WardID, UserID, ShiftID));
        }
        [HttpPost]
        public HttpResponseMessage InsertUpdateChecklistData([FromBody]  string  Data)
        {
            CheckListItemData checkListItem = JsonConvert.DeserializeObject<CheckListItemData>(Data);          
            return Request.CreateResponse(HttpStatusCode.OK, adminBL.InsertUpdateChecklistData(checkListItem.WardID, checkListItem.Date, checkListItem.UserID, checkListItem.ShiftID, checkListItem.CheckListDataList));
          
        }

        [HttpGet]
        public HttpResponseMessage GetCheckListType()
        {

            return Request.CreateResponse(HttpStatusCode.OK, adminBL.GetCheckListType());

        }

        [HttpPost]
        public HttpResponseMessage GetCheckListItems([FromBody] KeyValuePair Type)
        {
            return Request.CreateResponse(HttpStatusCode.OK, adminBL.GetCheckListItems(Type.Key));
        }

        [HttpPost]
        public HttpResponseMessage InsertUpdateCheckListItems([FromBody]CheckListItem Data)
        {

            List<CheckListOptions> checkListOption = JsonConvert.DeserializeObject<List<CheckListOptions>>(Data.OptionData);
            return Request.CreateResponse(HttpStatusCode.OK, adminBL.InsertUpdateCheckListItems(Data.ChecklistItemId, Data.CheckListItemName, Data.CheckListControlType, Data.ChecklistType, Data.UserID, Data.isActive, checkListOption));
        }

        //[HttpPost]
        //public HttpResponseMessage InsertUpdateOptions(CheckListOptions checkListOptions)
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, adminBL.InsertUpdateOptions(checkListOptions));
        //}

        [HttpPost]
        public HttpResponseMessage DeleteOptions(CheckListOptions checkListOptions)
        {
            return Request.CreateResponse(HttpStatusCode.OK, adminBL.DeleteOptions(checkListOptions));
        }

        [HttpPost]
        public HttpResponseMessage DeleteCheckListItem([FromBody] string CheckListItemID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, adminBL.DeleteCheckListItem(CheckListItemID));
        }

        [HttpPost]
        public HttpResponseMessage CreateUpdateConfigHeader([FromBody] ConfigHeaderContext ConfigHeader)
        {
            return Request.CreateResponse(HttpStatusCode.OK, adminBL.CreateUpdateConfigHeader(ConfigHeader.configID,ConfigHeader.configName,ConfigHeader.isActive,ConfigHeader.userID));
        }

        [HttpPost]
        public HttpResponseMessage DeleteConfigHeader([FromBody] string configID)
        {

            return Request.CreateResponse(HttpStatusCode.OK, adminBL.DeleteConfigHeader( configID));
        }

        [HttpGet]
        public HttpResponseMessage GetWarddetails([FromBody] string configID)
        {

            return Request.CreateResponse(HttpStatusCode.OK, adminBL.GetWarddetails());
        }

        [HttpPost]
        public HttpResponseMessage GetChecklistWardMappingMasterData([FromBody] WardMapping data)
        {

            return Request.CreateResponse(HttpStatusCode.OK, adminBL.GetChecklistWardMappingMasterData(data.Type,data.WardID));
        }
        [HttpPost]
        public HttpResponseMessage CreateUpdateCheckListDataMapping([FromBody] WardMappingData data)
        {

            return Request.CreateResponse(HttpStatusCode.OK, adminBL.CreateUpdateCheckListDataMapping(data.WardID, data.UserID,data.data));
        }

    }
}