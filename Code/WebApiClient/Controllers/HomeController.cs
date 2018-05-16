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
        public IHttpActionResult GetAuthorized()
        {
            var user = User.Identity.Name;
            var model = new List<object> {
                new {  id  = 1, value = "one" },
                new {  id  = 2, value = "two" },
                new {  id  = 3, value = "three" },
                new {  id  = 4, value = "four" },
                new {  id  = 5, value = "five" },
                new {  id  = 6, value = "six" }
            };
            return Ok(model);
        }

    }
}
