using api.Configurations;
using api.Extensions;
using ConfigurationSubstitution;
using CrossCutting.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

EnvironmentsConfig.Load();

builder.Configuration.EnableSubstitutions();

builder.Services.AutoMapperServiceConfig(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerServiceConfig();

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(ExceptionFilter));
    //opt.Filters.Add(typeof(ValidacaoUsuarioFilter));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});
// builder.Services.AuthServiceConfig(builder.Configuration);

var app = builder.Build();

// app.AuthAppConfig();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
