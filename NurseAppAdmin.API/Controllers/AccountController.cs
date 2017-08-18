<<<<<<< HEAD:NurseAppAdmin.API/Controllers/AccountController.cs
﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;



namespace ConnectN.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {       

        public AccountController()
        {

        }
        [HttpGet]
        public HttpResponseMessage Testmethod()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Test API");
        }

        
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;


namespace ConnectN.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        

        public AccountController()
        {
        }

        
    }
}
>>>>>>> origin/master:ConnectN.API/Controllers/AccountController.cs
