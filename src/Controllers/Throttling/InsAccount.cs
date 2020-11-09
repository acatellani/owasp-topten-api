using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Model;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers.Throttling
{
    [ApiController]
    [Route("thr/[controller]")]
    public class InsAccount : ControllerBase
    {

            private IAppServices appServices;
            private IMapper automapper;

        public InsAccount(IAppServices appServ, IMapper mapper)
        {
            appServices = appServ;
            automapper= mapper;
        }

        [HttpGet("GetBalance/{id}")]
        public ActionResult Get(int id)
        {
            var account = appServices.GetAccount(id);

            var accountData = automapper.Map<Account, AccountInfo>(account);

            if (account != null)
                return Ok(accountData);
            else
                return BadRequest();
        }

      
    }
}