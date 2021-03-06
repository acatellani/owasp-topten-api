using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers.MassAssignment
{
    [ApiController]
    [Route("massAssignment/[controller]")]
    public class InsUser : ControllerBase
    {

        IAppServices appServices;

        public InsUser(IAppServices appServ, IMapper mpper)
        {
            appServices = appServ;
        }

        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post(User newUser)
        {
            appServices.CreateUser(newUser);
            return Ok("HttpCode 200 OK");
        }

    }
}