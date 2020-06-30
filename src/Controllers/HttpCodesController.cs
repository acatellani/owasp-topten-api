using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase?view=aspnetcore-3.1
//https://restfulapi.net/http-status-codes/
namespace src.Controllers
{
    [Route("[controller]")]
    public class HttpCodesController : ControllerBase
    {

        [HttpGet("get200ok")]
        
        public IActionResult Get200OK()
        {
            return Ok("HttpCode 200 OK");
        }

         [HttpGet("get204NoContent")]
        public IActionResult Get204NoContent()
        {
            return NoContent(); //To use with PUT, POST or DELETE
        }

        [HttpGet("get301Created")]
        public IActionResult Get301Created()
        {
            return Ok("Created: for use in objects creation as result");
        }

        [HttpGet("get302redirect")]
        public IActionResult Get302Redirect()
        {
            return Redirect("https://www.segu-info.com.ar/");
        }

        [HttpGet("get401Unauthorized")]
        [Authorize]
        public IActionResult GetUnauthorized()
        {
            return Ok("HttpCode 200 OK");
        }

        [HttpGet("get403Forbidden")]
        public IActionResult GetForbidden()
        {
            return Forbid();
        }

        [HttpGet("get500ServerError")]
        public IActionResult GetServerError()
        {
           throw new System.Exception("UGLY SERVER ERROR");
        }
    }
}