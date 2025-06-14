using data.Infra.PG.Enums;

namespace application.Dtos.Usuario;

public class UsuarioDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
}