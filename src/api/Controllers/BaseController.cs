using data.Infra.PG.Context;
using data.Infra.Documents.Context;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class BaseController(AppDbContext context, data.Infra.Documents.Context.DbContext mongoDbContext) : ControllerBase
{
    private readonly AppDbContext _context = context;
    private readonly data.Infra.Documents.Context.DbContext _mongoDbContext = mongoDbContext;

    [HttpGet("/")]
    public ContentResult Index() => new()
    {
        ContentType = "text/html",
        Content = "<div>Ola, Como voce esta?</div><br/>"
    };

    [HttpGet("teste-conexao")]
    public async Task<IActionResult> TestarConexao()
    {
        var resultado = new List<string>();

        // PostgreSQL
        try
        {
            var conectado = await _context.Database.CanConnectAsync();
            resultado.Add(conectado ? "✅ PostgreSQL OK" : "❌ PostgreSQL Falhou");
        }
        catch (Exception ex)
        {
            resultado.Add($"❌ PostgreSQL ERRO: {ex.Message}");
        }

        // MongoDB
        try
        {
            await _mongoDbContext.Database.ListCollectionsAsync(); // testa conexão
            resultado.Add("✅ MongoDB OK");
        }
        catch (Exception ex)
        {
            resultado.Add($"❌ MongoDB ERRO: {ex.Message}");
        }

        return Ok(string.Join(" | ", resultado));
    }
}
