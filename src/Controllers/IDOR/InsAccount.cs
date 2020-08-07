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

namespace owasp_topten_api.Controllers.IDOR
{

    [ApiController]
    [Route("idor/[controller]")]

    public class InsAccount : ControllerBase
    {

        private IAppServices appServices;
        private IWebHostEnvironment hostingEnvironment;

        public InsAccount(IAppServices appServ, IWebHostEnvironment environment)
        {
            appServices = appServ;
            hostingEnvironment = environment;
        }

        [HttpGet("GetBalance/{id}")]
        public ActionResult Get(int id)
        {

            var account = appServices.GetAccount(id);

            if (account != null)
                return Ok(account);
            else
                return BadRequest();
        }

        [HttpGet("GetBalanceFile/{id}")]
        public ActionResult GetFile(int id)
        {

            var account = appServices.GetAccount(id);

            if (account != null)
            {
                var text = $"Account balance from user { account.User.FirstName} {account.User.LastName } is {account.Balance.ToString("C") } ";
                var fileName = $"Account{id}.txt";
                using (var stWriter = new StreamWriter(Path.Combine(hostingEnvironment.ContentRootPath, "GenFiles", fileName)))
                {
                    stWriter.Write(text);
                }

                return Ok(new { fileUrl = $"/Genfiles/{fileName}"});
            }
            else
                return BadRequest();
        }

        [HttpGet("GetBalanceFileAuth/{id}")]
        [Authorize]
        public ActionResult GetFileAuth(int id)
        {

            var account = appServices.GetAccount(id);

            if (account != null)
            {
                var text = $"Account balance from user { account.User.FirstName} {account.User.LastName } is {account.Balance.ToString("C") } ";
                var fileName = $"Account{id}.txt";
                using (var stWriter = new StreamWriter(Path.Combine(hostingEnvironment.ContentRootPath, "GenFiles", fileName)))
                {
                    stWriter.Write(text);
                }

                return Ok(new { fileUrl = $"/Genfiles/{fileName}"});
            }
            else
                return BadRequest();
        }

        [HttpGet("GetBalanceFileScrambledName/{id}")]
        public ActionResult GetFileScrambledName(int id)
        {

            var account = appServices.GetAccount(id);

            if (account != null)
            {
                var text = $"Account balance from user { account.User.FirstName} {account.User.LastName } is {account.Balance.ToString("C") } ";
                //var fileName = Path.ChangeExtension(Path.GetRandomFileName(), "txt");
                var fileName = Guid.NewGuid().ToString() +  ".txt";
                
                using (var stWriter = new StreamWriter(Path.Combine(hostingEnvironment.ContentRootPath, "GenFiles", fileName)))
                {
                    stWriter.Write(text);
                }

                return Ok(new { fileUrl = $"/Genfiles/{fileName}"});
            }
            else
                return BadRequest();
        }

    }
}