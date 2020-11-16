using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers.InsecureObjectMapping
{
    [ApiController]
    [Route("logs/[controller]")]
    public class LogController : ControllerBase
    {

        private ILogger logger;
        private IAppServices appServices;

        public LogController(ILogger<LogController> logEngine, IAppServices appSrv)
        {
            logger = logEngine;
            appServices = appSrv;
        }

        [HttpGet]
        public ActionResult Get(string value) {

            var message = $"Llamada a GET action /logs con el valor { value} ";
            logger.LogInformation(message);

            var account = appServices.GetAccount(1);
            
            throw new Exception("Excepción no controlada");

            return Ok();
        }
    }
}