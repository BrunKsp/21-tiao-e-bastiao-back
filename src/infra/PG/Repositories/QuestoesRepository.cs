using System.Collections;
using data.Infra.PG.Context;
using data.Infra.PG.Entities;
using infra.PG.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infra.PG.Repositories;

public class QuestoesRepository : BaseRepository<QuestoesEntity>, IQuestoesRepository
{
    public QuestoesRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IList<QuestoesEntity>> BuscarTodas()
    {
        return await DbSet.Include(a => a.Alternativas).ToListAsync();
    }
}