using System;
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
