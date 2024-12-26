using CookiesUploading;
using Microsoft.AspNetCore.Mvc;

[Route("Cookies")]
public class CookiesController : Controller
{
    private readonly UploadingService _uploadingService;

    public CookiesController(UploadingService uploadingService)
    {
        _uploadingService = uploadingService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(); // החזרת עמוד Index.cshtml
    }

    [HttpGet("collect")]
    public async Task<IActionResult> CollectCookies()
    {
        // אוסף את ה-Cookies מהבקשה
        var cookies = Request.Cookies;

        if (cookies == null || cookies.Count == 0)
        {
            return BadRequest("No cookies received.");
        }

        // מכין את תוכן הקובץ
        var content = string.Join("\n", cookies.Select(c => $"{c.Key}: {c.Value}"));

        // יצירת שם ייחודי לקובץ
        var fileName = $"cookies_{DateTime.UtcNow:yyyyMMdd_HHmmss}.txt";

        // שמירת הקובץ באמצעות UploadingService
        var result = await _uploadingService.SaveFileAsync(fileName, content);

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(new { message = "Cookies collected and saved successfully", fileName = result.FileName });
    }
}
