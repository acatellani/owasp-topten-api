using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;

namespace owasp_topten_api.Controllers.CORS
{
    /*
    - CORS viene activa X DEFECTO en .NET Core. La política de "allow same origin" viene activa por defecto.
    - Desactivarla es bastante dificil. Lo que se va haciendo es "relajar" la política.
    - Se configura a través del startup mediante políticas nombradas. Las mismas se pueden activar para toda la aplicación
    vía middleware (app.UseCors) o granularmente, a través del atributo EnableCors(<nombre de la política>)
    - Desde owasp.curso.com:54200 : habilitado
    - Desde cors.curso.com:54200: no habilitado
    - Para probar, copiar el archivo index.html en la carpeta GenFiles
    */

    [ApiController]
    [Route("cors/[controller]")]
    public class Test : ControllerBase
    {

        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok("HttpCode 200 OK");
        }

    }
}