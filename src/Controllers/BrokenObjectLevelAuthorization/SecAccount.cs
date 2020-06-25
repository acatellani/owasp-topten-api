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

namespace owasp_topten_api.Controllers.BrokenObjectLevelAuthorization
{
    [ApiController]
    [Route("bol/[controller]")]
    [Authorize]
    public class SecAccount : ControllerBase
    {

        private IAppServices appServices;

        public SecAccount(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpGet("GetBalance/{id}")]
        public ActionResult Get(int id)
        {
            var account = appServices.GetAccount(id);

            if (account == null)
                return BadRequest();
            else
            {
                if (account.User.Username != User.FindFirst(ClaimTypes.Name).Value 
                && User.FindFirst(ClaimTypes.Role).Value != "Admin")
                    return Unauthorized();
                else
                    return Ok(account);
            }
        }

        [HttpGet("GetBalanceFileBlob/{id}")]
        public ActionResult GetFileScrambledName(int id)
        {

            var account = appServices.GetAccount(id);

            if (account != null)
            {
                var text = $"Account balance from user { account.User.FirstName} {account.User.LastName } is {account.Balance.ToString("C") } ";
               
                return File(Encoding.UTF8.GetBytes(text), "text/plain", $"AccountFromBlob{id}.txt");
            }
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")] //API5
        public ActionResult Delete(int id)
        {
            var account = appServices.GetAccount(id);

            //401 - Equiv to Unauthenticate
            if (account != null && User.FindFirst(ClaimTypes.Name).Value != account.User.Username)
                return Ok("Account deleted");
            else
                return Forbid();
        }
    }
}