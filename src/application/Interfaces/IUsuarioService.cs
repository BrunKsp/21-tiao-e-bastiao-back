using application.Dtos.Auth;
using application.Dtos.Usuario;
using data.Migrations;

namespace application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioAutenticadoDto> CriarUsuario(CriarUsuarioDto dto);
    Task<UsuarioDto> AlterarUsuario(CriarUsuarioDto dto);
    Task<UsuarioDto> BuscarInfo();
}