using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OfficeFileUploader.Controllers
{
    public class FileController : Controller
    {
        private readonly FileService _FileService;

        public FileController(FileService officeFileService)
        {
            _FileService = officeFileService; // שימוש ב-DI
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AutoUpload()
        {
            await _FileService.CollectAndUploadFilesAsync();
            return Content("files uploaded successfully!");
        }
    }
}
