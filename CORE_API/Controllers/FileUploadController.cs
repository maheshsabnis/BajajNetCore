using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CORE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        /// <summary>
        /// The File WIll be REceived from Http request posted in form object
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("file/upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            try
            {

                if (!CheckFileExtension(file))
                {
                    return BadRequest($"The File does not have an extension or it is not image. " +
                        $"The Expected extension is .jpg/.png/.bmp");
                }

                if (!CheckFileSize(file))
                {
                    return BadRequest($"The size of file is more than 10 mb, " +
                        $"please make sure that the file size must be less than 10 mb");
                }
                // Read the folder where the file is to be saved
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "Files");

                if (file.Length > 0)
                {
                    // REad the Uploaded File Name
                    var postedFileName = ContentDispositionHeaderValue
                      .Parse(file.ContentDisposition)
                        .FileName.Trim('"');

                    // set the file path as FolderName/FileName
                    var finalPath = Path.Combine(folder, postedFileName);
                    using (var fs = new FileStream(finalPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                    return Ok($"File is uploaded Successfully");
                }
                else
                {
                    return BadRequest("The File is not received.");
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500,
                  $"Some Error Occcured while uploading File {ex.Message}");
            }
        }

        /// The file extension must be jpg/bmp/png

        private bool CheckFileExtension(IFormFile file)
        {
            string[] extensions = new string[] { "jpg", "bmp", "png" };

            var fileNameExtension = file.FileName.Split(".")[1];
            if (string.IsNullOrEmpty(fileNameExtension) ||
                !extensions.Contains(fileNameExtension))
            {
                return false;
            }

            return true;
        }

        /// Check the file size, it must be less than 10 mb

        private bool CheckFileSize(IFormFile file)
        {
            if (file.Length > 1e+7)
            {
                return false;
            }
            return true;
        }
    }
}
