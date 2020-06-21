using System;
using Microsoft.AspNetCore.Mvc;
using owasp_topten_api.Services;
using System.Diagnostics;
using System.IO;

namespace owasp_topten_api.Controllers.CodeInjection
{
    [ApiController]
    [Route("cij/[controller]")]
    public class SecAccount : ControllerBase
    {

        private IAppServices appServices;

        public SecAccount(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpPut("UpdateBalances")]
        public ActionResult Put([FromBody] FileParams files)
        {

            try
            {
                System.IO.File.Copy(files.originFile, files.destFile, true);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}