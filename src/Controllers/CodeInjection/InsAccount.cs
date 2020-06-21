using Microsoft.AspNetCore.Mvc;
using owasp_topten_api.Services;
using System.Diagnostics;

namespace owasp_topten_api.Controllers.CodeInjection
{
    public class FileParams
    {
        public string originFile { get; set; }

        public string destFile { get; set; }
    }

    [ApiController]
    [Route("cij/[controller]")]
    public class InsAccount : ControllerBase
    {

        private IAppServices appServices;

        public InsAccount(IAppServices appServ)
        {
            appServices = appServ;
        }

        [HttpPut("UpdateBalances")]
        public ActionResult Put([FromBody] FileParams files)
        {

            var strCmdText = $"/C copy {files.originFile} {files.destFile}";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            return Ok();

        }


    }
}