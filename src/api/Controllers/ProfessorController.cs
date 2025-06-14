using application.Dtos.Alunos;
using application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("professor")]
public class ProfessorController : BaseController
{
    private readonly IProfessorService _service;
    public ProfessorController(IProfessorService service)
    {
        _service = service;
    }
    [Authorize]
    [HttpGet]
    public async Task<TodosAlunosDto> BuscarTodos()
    {
        return await _service.BuscarTodosAlunos();
    }
}