using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace owasp_topten_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SecAccount : ControllerBase
    {
        public SecAccount()
        {
        }
    }
}