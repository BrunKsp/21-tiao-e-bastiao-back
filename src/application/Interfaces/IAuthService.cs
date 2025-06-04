using application.Dtos.Auth;
using data.Infra.PG.Entities;

namespace application.Interfaces;

public interface IAuthService
{
    UsuarioAutenticadoDto GenerateJWT(UsuarioEntity user);
    Task<UsuarioAutenticadoDto> Login(LoginDto dto);
}