using data.Infra.Documents.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace data.Infra.Documents.Context;

public class DocumentContext
{
    public IMongoDatabase Database { get; }

    public DocumentContext(IConfiguration config)
    {
        var conn = config["MongoDb:ConnectionString"];
        var database = config["MongoDb:DataBase"];

        var mongoClient = new MongoClient(conn);
        Database = mongoClient.GetDatabase(database);
    }

    public IMongoCollection<DadosIACollection> DadosIACollection =>
          Database.GetCollection<DadosIACollection>("dados_ia");
}
