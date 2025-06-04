using application.Interfaces;
using application.Services;
using application.Utils;
using data.Infra.Documents;
using data.Infra.PG.Context;
using infra.PG.Interfaces;
using infra.PG.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Ioc;

public static class NativeCoreDependecyInjection
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<AppDbContext>();
        services.AddScoped<DbContext>();

        #region Documents

        #endregion

        #region Repositorys
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        #endregion

        #region Services
        services.AddScoped<IUserInfo, UserInfo>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        #endregion

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
