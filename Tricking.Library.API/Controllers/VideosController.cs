using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tricking.Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly ILogger<VideosController> _logger;

        public VideosController(ILogger<VideosController> logger)
        {
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            _logger.LogInformation("Inseide Upload Method");
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided.");
            }

            // Choose a directory to save the file. This can be anywhere on your server.
            var savePath = Path.Combine("UploadedFiles", file.FileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(new { Message = "File uploaded successfully.", FileName = file.FileName });
        }

    }
}
