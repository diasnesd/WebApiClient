using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiClient.Controllers
{
    public class HomeController : ApiController
    {
        public HomeController() { }

        [Route("~/api/items")]
        [HttpGet]
        public IHttpActionResult Get()
        { 
            return Ok();
        }

        [Authorize]
        [Route("~/api/items-authorized")]
        [HttpGet]
        public IHttpActionResult Get1()
        {
            var user = User.Identity.Name;
            return Ok();
        }

    }
}
