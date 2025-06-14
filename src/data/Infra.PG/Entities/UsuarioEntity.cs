using data.Infra.PG.Enums;

namespace data.Infra.PG.Entities;

public class UsuarioEntity : BaseEntity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public TipoUsuario TipoUsuario {get;set;}
}