using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace playground_netcorejwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        // GET api/protected
        [HttpGet]
        [Authorize]
        public string Protected()
        {
            return "Only if you have a valid token!";
        }
    }
}
