using data.Infra.PG.Context;
using data.Infra.PG.Entities;
using infra.PG.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infra.PG.Repositories;

public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<UsuarioEntity> BuscarPorEmail(string email)
    {
        return await DbSet.FirstOrDefaultAsync(p => p.Email == email);
    }
}