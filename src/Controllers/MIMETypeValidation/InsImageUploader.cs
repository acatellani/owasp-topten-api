using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using owasp_topten_api.Entities;
using owasp_topten_api.Services;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace owasp_topten_api.Controllers.MIMETypeValidation
{
    [ApiController]
    [Route("mime/[controller]")]
    public class InsImageUploader : ControllerBase
    {

        public InsImageUploader()
        {

        }

        [HttpPost()]
        public ActionResult Upload(IFormFile uploadedFile)
        {

            using (var stream = System.IO.File.Create(".\\GenFiles\\" + uploadedFile.FileName))
            {
                uploadedFile.CopyTo(stream);
            }
            return NoContent();
        }

        [HttpPost("CheckExtension")]
        public ActionResult UploadCheckExtension(IFormFile uploadedFile)
        {
            var provider = new FileExtensionContentTypeProvider();

            string mimeType;

            if (provider.TryGetContentType(uploadedFile.FileName, out mimeType)
            && mimeType.StartsWith("image/"))
            {
                using (var stream = System.IO.File.Create(".\\GenFiles\\" + uploadedFile.FileName))
                {
                    uploadedFile.CopyTo(stream);
                }
                return NoContent();
            }
            else
            {
                return BadRequest();
            }           
        }
    }
}