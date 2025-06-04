using data.Infra.PG.Context;
using data.Infra.Documents.Context;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class BaseController() : ControllerBase
{
    // [HttpGet("/")]
    // public ContentResult Index() => new()
    // {
    //     ContentType = "text/html",
    //     Content = "<div>Ola, Como voce esta?</div><br/>"
    // };
}
