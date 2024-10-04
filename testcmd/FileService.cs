using Microsoft.AspNetCore.Mvc;

namespace testcmd;

public class FileService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public FileService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task ReturnFileToClient(FileContentResult fileResult)
    {
        try
        {
            var context = _httpContextAccessor.HttpContext;
            if (context != null)
            {
                context.Response.ContentType = fileResult.ContentType;
                context.Response.Headers.Add("Content-Disposition", $"attachment; filename={fileResult.FileDownloadName}");
                await context.Response.Body.WriteAsync(fileResult.FileContents, 0, fileResult.FileContents.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
      
    }
}
