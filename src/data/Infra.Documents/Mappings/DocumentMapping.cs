using MongoDB.Bson.Serialization;

namespace data.Infra.Documents.Mappings;

public abstract class DocumentMapping<T>
{
    protected DocumentMapping()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
            BsonClassMap.RegisterClassMap<T>(Map);
    }
    public abstract void Map(BsonClassMap<T> cm);
}