using Microsoft.AspNetCore.Mvc;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class FeedsController : ControllerBase
{
    [HttpGet("refresh")]
    public IActionResult Refresh()
    {
        return Ok(new { message = "Feed refresh placeholder" });
    }
}
