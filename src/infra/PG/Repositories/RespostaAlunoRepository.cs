using data.Infra.PG.Context;
using data.Infra.PG.Entities;
using infra.PG.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infra.PG.Repositories;

public class RespostaAlunoRepository : BaseRepository<RespostaAlunoEntity>, IRespostaAlunoRepository
{
    public RespostaAlunoRepository(AppDbContext context) : base(context)
    {

    }

    public async Task AddRange(IEnumerable<RespostaAlunoEntity> respostas)
    {
        await DbSet.AddRangeAsync(respostas);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<RespostaAlunoEntity>> BuscarComQuestoesEAlternativas(Guid usuarioId)
    {
        return await DbSet
            .Include(r => r.Questao)
            .Where(r => r.UsuarioId == usuarioId)
            .OrderByDescending(r => r.RespondidoEm)
            .ToListAsync();
    }

    public async Task<IList<RespostaAlunoEntity>> BuscarComQuestoes(Guid usuarioId)
    {
        return await DbSet
            .Include(r => r.Questao)
            .Where(r => r.UsuarioId == usuarioId)
            .OrderByDescending(r => r.RespondidoEm)
            .ToListAsync();
    }
}
