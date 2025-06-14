using application.Dtos.Questionario;
using application.Dtos.Questoes;
using application.Dtos.Questoes.Resposta;
using application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("questionario")]
public class QuestionarioController : BaseController
{
    private readonly IQuestoesServices _service;
    public QuestionarioController(IQuestoesServices service)
    {
        _service = service;
    }
    [Authorize]
    [HttpGet]
    public async Task<IList<QuestoesDto>> BuscarQuestoes()
    {
        return await _service.BuscarTodas();
    }

    [Authorize]
    [HttpPost("responder")]
    public async Task<IActionResult> ResponderQuestionario([FromBody] RespostasQuestionarioDto dto)
    {
        await _service.RegistrarRespostas(dto);
        return Ok(new
        {
            sucesso = true,
            mensagem = "Respostas registradas com sucesso."
        });
    }

    [Authorize]
    [HttpGet("respostas/{slug}")]
    public async Task<IList<QuestionarioRespondidoDto>> BuscarRespostasUsuario(string slug)
    {
        return await _service.BuscarRespostasAgrupadasPorTema(slug);
    }
}