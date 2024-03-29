using Viriplaca.HR.App.Images.UploadImage;

namespace Viriplaca.HR.Api.Controllers;

public class ImagesController : ApiController<ImagesController>
{
    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var command = new UploadImageCommand(file.FileName, memoryStream.ToArray());
        var result = await Sender.Send(command);

        return Ok(result);
    }
}
