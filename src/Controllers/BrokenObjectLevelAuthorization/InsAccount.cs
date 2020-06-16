using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class InsAccount: ControllerBase
    {
        
        private IAppService appServices;

        public InsAccount(IAppService appServ) {
            appServices = appServ;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get(int id) {

            return Ok(new Account());
        }

    }
}