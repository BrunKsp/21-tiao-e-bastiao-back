using data.Infra.PG.Entities;

namespace infra.PG.Interfaces;

public interface IUsuarioRepository : IBaseRepository<UsuarioEntity>
{
    Task<UsuarioEntity> BuscarPorEmail(string email);
}