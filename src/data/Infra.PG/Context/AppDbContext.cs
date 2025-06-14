using data.Infra.PG.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace data.Infra.PG.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<QuestoesEntity> Questoes { get; set; }
    public DbSet<AlternativasEntity> Alternativas { get; set; }
    public DbSet<RespostaAlunoEntity> RespostasAluno { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("code_race");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string) &&
                                    p.GetMaxLength() == null &&
                                    p.GetColumnType() == null)))
            property.SetColumnType("varchar(100)");

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in ChangeTracker.Entries())
        {
            if (entityEntry.Entity is BaseEntity be && entityEntry.State == EntityState.Added)
            {
                GerarSlug(be);
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    private void GerarSlug(BaseEntity be)
    {
        var hash = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                    .Replace("/", "-")
                    .Replace("+", "_");
        be.SetSlug(hash);
    }
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();

       builder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=apps",
                x => x.MigrationsHistoryTable("__ef_historico_migrations", "code_race"));

        return new AppDbContext(builder.Options);
    }
}
