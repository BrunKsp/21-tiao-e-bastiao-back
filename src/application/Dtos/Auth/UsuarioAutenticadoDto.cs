using data.Infra.PG.Enums;

namespace application.Dtos.Auth;

public class UsuarioAutenticadoDto
{
    public string Slug { get; set; }
    public string Nome { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public string Token { get; set; }
}