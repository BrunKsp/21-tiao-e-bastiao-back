using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace data.Infra.Documents.Context;

public class DbContext
{
    public IMongoDatabase Database { get; }

    public DbContext(IConfiguration config)
    {
        var conn = config["MongoDb:ConnectionString"];
        var database = config["MongoDb:DataBase"];

        var mongoClient = new MongoClient(conn);
        Database = mongoClient.GetDatabase(database);
    }
}
