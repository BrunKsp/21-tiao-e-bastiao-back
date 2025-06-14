using data.Infra.PG.Context;
using data.Infra.PG.Entities;
using infra.PG.Interfaces;


namespace infra.PG.Repositories;

public class RespostaAlunoRepository : BaseRepository<RespostaAlunoEntity> , IRespostaAlunoRepository
{
    public RespostaAlunoRepository(AppDbContext context) : base(context)
    {

    }

    public async Task AddRange(IEnumerable<RespostaAlunoEntity> respostas)
    {
        await DbSet.AddRangeAsync(respostas);
        await _context.SaveChangesAsync();
    }
}
