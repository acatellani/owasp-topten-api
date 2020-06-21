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

namespace owasp_topten_api.Controllers.MIMETypeValidation
{
    [ApiController]
    [Route("img/[controller]")]
    [Authorize]
    public class SecImageUploader : ControllerBase
    {

        private IAppServices appServices;

        public SecImageUploader(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpPost]
        public ActionResult CreateAccount([FromBody]Account newAccount) {

            //TODO: COMPLETAR con FileExtensionContentTypeProvider

            return Ok();
        }
    }
}