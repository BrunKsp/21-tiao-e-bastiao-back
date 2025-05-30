using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    [HttpGet("/")]
    public ContentResult Index()
    {
        return new ContentResult
        {
            ContentType = "text/html",
            Content = "<div>Ola, Como voce esta?</div></br><div>"
        };
    }

}