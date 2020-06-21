using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Services;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Controllers.InsecureObjectMapping
{
    [ApiController]
    [Route("iom/[controller]")]
    [Authorize]
    public class SecAccount : ControllerBase
    {

        private IAppServices appServices;

        public SecAccount(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpPost]
        public ActionResult CreateAccount([FromBody]Account newAccount) {

            //TODO: COMPLETAR

            return Ok();
        }
    }
}