using data.Infra.PG.Enums;

namespace application.Dtos.Usuario;

public class CriarUsuarioDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
}