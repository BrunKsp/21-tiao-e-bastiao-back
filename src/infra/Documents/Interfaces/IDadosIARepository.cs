using data.Infra.Documents.Collections;

namespace infra.Documents.Interfaces;

public interface IDadosIARepository
{
    Task Create(DadosIACollection collection);
}