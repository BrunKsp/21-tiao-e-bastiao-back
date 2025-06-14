using application.Dtos.IA;
using application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers;

[Route("IA")]
public class IAController : BaseController
{
    private readonly IIAService _service;
    public IAController(IIAService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpPost]
    public async Task SalvarDadosIA(RespostaIADto dto)
    {
        await _service.SalvarRespostaIa(dto);
    }
}