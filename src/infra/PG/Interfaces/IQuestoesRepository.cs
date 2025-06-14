using data.Infra.PG.Entities;

namespace infra.PG.Interfaces;

public interface IQuestoesRepository : IBaseRepository<QuestoesEntity>
{
    Task<IList<QuestoesEntity>> BuscarTodas();
}