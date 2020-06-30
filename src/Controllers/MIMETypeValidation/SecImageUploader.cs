using System.IO;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Services;
using owasp_topten_api.Entities;
using Microsoft.AspNetCore.Http;
using HeyRed.Mime;

namespace owasp_topten_api.Controllers.MIMETypeValidation
{
    [ApiController]
    [Route("mime/[controller]")]
    public class SecImageUploader : ControllerBase
    {

        public SecImageUploader(IAppServices appServ)
        {
        }

        [HttpPost()]
        public ActionResult Upload(IFormFile uploadedFile)
        {

            var fileName = ".\\GenFiles\\" + uploadedFile.FileName;
            using (var stream = System.IO.File.Create(fileName))
            {
                uploadedFile.CopyTo(stream);
            }

            var type = HeyRed.Mime.MimeGuesser.GuessFileType(fileName);

            if (!type.MimeType.StartsWith("image"))
                System.IO.File.Delete(fileName);

            return NoContent();
        }
    }
}