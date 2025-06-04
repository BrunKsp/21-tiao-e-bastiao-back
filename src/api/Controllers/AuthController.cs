using application.Dtos.Auth;
using application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("auth")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<UsuarioAutenticadoDto> Login(LoginDto dto)
        {
            return await _service.Login(dto);
        }
    }
}