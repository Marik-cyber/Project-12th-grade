using Microsoft.AspNetCore.Mvc;
using PicturesUploader;

namespace ScreenshotController.Controllers
{
    public class PicturesController : Controller
    {
        private readonly PicturesService _screenshotService;

        public PicturesController(PicturesService screenshotService)
        {
            _screenshotService = screenshotService;
        }

        // Make sure the route is correctly mapped
        [HttpGet]
        [Route("Screenshot/AutoUpload")]
        public async Task<IActionResult> AutoUpload()
        {
            // Call your logic for automatic upload
            await _screenshotService.UploadPicturesAutomaticallyAsync();

            ViewBag.Message = "Screenshots uploaded successfully!";
            return View("Index");  // Assuming you want to return the Index view after upload
        }

        // If you have other methods, make sure they are also correctly mapped
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}