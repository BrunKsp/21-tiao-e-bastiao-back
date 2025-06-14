using data.Infra.Documents.Collections;
using data.Infra.Documents.Context;
using infra.Documents.Interfaces;
using MongoDB.Driver;

namespace infra.Documents.Repositories;

public class DadosIARepository : IDadosIARepository
{
    protected IMongoCollection<DadosIACollection> _dataBase;

    public DadosIARepository(DocumentContext context)
    {
        _dataBase = context.DadosIACollection;
    }
    public async Task Create(DadosIACollection collection)
    {
        await _dataBase.InsertOneAsync(collection);
    }
}