using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace owasp_topten_api.Controllers.BrokenFunctionLevelAuthorization
{
    [ApiController]
    [Route("bfl/[controller]")]
    [Authorize]
    public class SecAccount : ControllerBase
    {

        private IAppServices appServices;

        public SecAccount(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpDelete("{id}")]
       // [Authorize()] //API5
        //[Authorize(AuthenticationSchemes= JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(AuthenticationSchemes= JwtBearerDefaults.AuthenticationScheme, Roles="Admin")]
        public ActionResult Delete(int id)
        {
            var account = appServices.GetAccount(id);

            //401 - Equiv to Unauthenticate
            if (account != null && User.FindFirst(ClaimTypes.Name).Value != account.User.Id.ToString())
                return Ok("Account deleted");
          else
                return Forbid();
        }
    }
}