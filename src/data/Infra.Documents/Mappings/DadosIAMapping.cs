using data.Infra.Documents.Collections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace data.Infra.Documents.Mappings;

public class DadosIAMapping : DocumentMapping<DadosIACollection>
{
    public override void Map(BsonClassMap<DadosIACollection> cm)
    {
        cm.MapIdField(d => d.Id)
              .SetIdGenerator(StringObjectIdGenerator.Instance);

        cm.MapField(d => d.Score)
          .SetElementName("score");

        cm.MapField(d => d.Descricao)
          .SetElementName("descricao");

        cm.MapField(d => d.QuestionarioSlug)
         .SetElementName("questionario_slug");
    }
}