using System.Data.Common;
using data.Infra.PG.Context;
using data.Infra.PG.Entities;
using infra.PG.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace infra.PG.Repositories;

public abstract class BaseRepository <TModel> : IBaseRepository<TModel> where TModel : BaseEntity, new()
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TModel> DbSet;

    protected DbConnection Connection
    {
        get
        {
            return _context.Database.GetDbConnection();
        }
    }

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        DbSet = context.Set<TModel>();
    }
    public async Task Criar(TModel model)
    {
        DbSet.Add(model);
        await _context.SaveChangesAsync();
    }

    public async Task Alterar(TModel model)
    {
        DbSet.Update(model);
        await _context.SaveChangesAsync();
    }

    public async Task Deletar(TModel model)
    {
        DbSet.Remove(model);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<TModel> BuscarPorSlug(string slug)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Slug == slug);
    }
}