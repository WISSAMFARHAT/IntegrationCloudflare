using Microsoft.AspNetCore.Mvc;

namespace testcmd.Controller;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    [HttpGet("download")]
    public IActionResult DownloadFile(string filePath)
    {
        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var fileName = Path.GetFileName(filePath);
        return File(fileBytes, "application/zip", fileName);
    }
}
