using data.Infra.PG.Entities;

namespace infra.PG.Interfaces
{
    public interface IRespostaAlunoRepository
    {
        Task AddRange(IEnumerable<RespostaAlunoEntity> respostas);
    }
}