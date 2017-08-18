using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NurseAppAdmin.Utility;
namespace NurseAppAdmin.WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult ConfigureCheckListData()
        {
            TempData["webBaseURL"] = Utility.Utility.GetAppConfigValues("WebApiBaseURL");
            return View();
        }
        public ActionResult MapWardCheckListData()
        {
            TempData["webBaseURL"] = Utility.Utility.GetAppConfigValues("WebApiBaseURL");
            return View();
        }
        
    }
}