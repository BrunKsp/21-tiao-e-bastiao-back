using application.Dtos.Auth;
using application.Dtos.Usuario;
using application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[Route("usuario")]
public class UserController : BaseController
{
    private readonly IUsuarioService _service;
    public UserController(IUsuarioService userService)
    {
        _service = userService;
    }

    [HttpPost]
    public async Task<UsuarioAutenticadoDto> CriarUsuario(CriarUsuarioDto dto)
    {
        return await _service.CriarUsuario(dto);
    }

    [HttpPut]
    [Authorize]
    public async Task<UsuarioDto> AlterarUsuario(CriarUsuarioDto dto)
    {
        return await _service.AlterarUsuario(dto);
    }
}