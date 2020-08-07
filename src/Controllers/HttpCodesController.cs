using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase?view=aspnetcore-3.1
//https://restfulapi.net/http-status-codes/
namespace src.Controllers
{

    /// <summary>
    /// Contiene métodos GET que muestran diferentes HTTP Codes.
    /// </summary>
    [Route("[controller]")]
    public class HttpCodesController : ControllerBase
    {



        /// <summary>
        /// Obtener un código 200
        /// </summary>
        /// <returns>Un mensaje en texto con un HTTPCode 200</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /get200ok
        ///
        /// </remarks>
        /// <response code="200">Returns operation ended OK</response>
        /// <response code="404">Not found</response>   
        [HttpGet("get200ok")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get200OK()
        {
            return Ok("HttpCode 200 OK");
        }

        [HttpGet("get204NoContent")]
        public IActionResult Get204NoContent()
        {
            return NoContent(); //To use with PUT, POST or DELETE
        }

        [HttpGet("get201Created")]
        public IActionResult Get301Created()
        {
            return Created("", "Created: for use in objects creation as result");
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