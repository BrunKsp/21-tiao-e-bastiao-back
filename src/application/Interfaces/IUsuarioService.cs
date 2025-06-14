using application.Dtos.Auth;
using application.Dtos.Usuario;
using data.Infra.PG.Entities;
using data.Migrations;

namespace application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioAutenticadoDto> CriarUsuario(CriarUsuarioDto dto);
    Task<UsuarioDto> AlterarUsuario(CriarUsuarioDto dto);
    Task<UsuarioDto> BuscarInfo();
    Task<UsuarioEntity> BuscarPorSlug(string slug);
}