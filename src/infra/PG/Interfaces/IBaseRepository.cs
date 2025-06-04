using data.Infra.PG.Entities;

namespace infra.PG.Interfaces;

public interface IBaseRepository<TModel> where TModel : BaseEntity, new()
{
    Task Criar(TModel model);
    Task Alterar(TModel model);
    Task Deletar(TModel model);
    Task<TModel> BuscarPorSlug(string slug);
}