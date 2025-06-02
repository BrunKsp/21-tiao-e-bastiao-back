using data.Infra.Documents;
using data.Infra.PG.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Ioc;

public static class NativeCoreDependecyInjection
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<AppDbContext>();
        // services.AddScoped<DbContext>();
       services.AddSingleton<data.Infra.Documents.Context.DbContext>();

        #region Documents

        #endregion

        #region Repositorys
        #endregion

        #region Services
        #endregion

        //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //configuração Postgree
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PG"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        //CONFIGURAÇÃO MONGO
        RegisterDocumentsMappings.RegisterDocumentsMapping();


        //  services.AddScoped(x =>
        //  {
        //      var context = x.GetRequiredService<DocumentContext>();
        //      return context.PropriedadeCollection;
        //  });
    }
}
