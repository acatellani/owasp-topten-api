using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers.BrokenFunctionLevelAuthorization
{

    [ApiController]
    [Route("bfl/[controller]")]

    public class InsAccount : ControllerBase
    {

        private IAppServices appServices;
        private IWebHostEnvironment hostingEnvironment;

        public InsAccount(IAppServices appServ, IWebHostEnvironment environment)
        {
            appServices = appServ;
            hostingEnvironment = environment;
        }    

        [HttpDelete("{id}")]
        //[Authorize]
        public ActionResult Delete(int id)
        {
            var account = appServices.GetAccount(id);

            if (account != null)
                return Ok($"Account \"{ account.User.Username }\" deleted - Muy común ver en apis autogeneradas");
            else
                return BadRequest();
        }
    }
}