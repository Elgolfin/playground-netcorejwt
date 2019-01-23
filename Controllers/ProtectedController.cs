using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme + "," + JwtBearerDefaults.AuthenticationScheme)]
        public string Protected()
        {
            return "Only if you have a valid token or a valid cookie!";
        }

        // GET api/protected
        [HttpGet("cookie-only/")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public string CookieOnlyProtected()
        {
            return "Only if you have a valid cookie!";
        }
        
        // GET api/protected
        [HttpGet("bearer-only/")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public string BearerOnlyProtected()
        {
            return "Only if you have a valid token!";
        }
    }
}
