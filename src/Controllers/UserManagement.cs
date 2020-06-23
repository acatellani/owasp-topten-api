using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using owasp_topten_api.Entities;
using owasp_topten_api.Model;
using owasp_topten_api.Services;

namespace src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserManagement : ControllerBase
    {

        private IUserServices userServices;

        public UserManagement(IUserServices uService)
        {
            userServices = uService;
        }

        [AllowAnonymous]
        [HttpPost("authenticateBasic")]
        public IActionResult Authenticate([FromBody]AuthenticateRequest model)
        {
            var response = userServices.Authenticate(model.Username, model.Password);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);

 
        }

        [AllowAnonymous]
        [HttpPost("authenticateJwt")]
        public IActionResult AuthenticateJwt([FromBody]AuthenticateRequest model)
        {
            var response = userServices.AuthenticateJwt(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);

 
        }

        [HttpGet("getBasic")]
        [Authorize(AuthenticationSchemes= "BasicAuthentication")]
        public IActionResult Get()
        {
           return Ok("User authenticated using Basic Authentication");
        }     

        [HttpGet("getBearer")]
        [Authorize(AuthenticationSchemes= JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetJwt()
        {

            return Ok("User authenticated using JSON Web Token (Bearer) Authentication");

        }     
    }
}