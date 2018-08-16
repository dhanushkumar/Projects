using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SessionToken.API.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        //// GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/values
        [HttpPost("{userName}")]
        public IActionResult Post(string userName)
        {
            return Ok("Sucess!");
        }

       
    }
}
