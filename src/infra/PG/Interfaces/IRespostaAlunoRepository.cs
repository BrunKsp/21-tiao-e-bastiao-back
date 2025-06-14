using data.Infra.PG.Entities;

namespace infra.PG.Interfaces
{
    public interface IRespostaAlunoRepository
    {
        Task AddRange(IEnumerable<RespostaAlunoEntity> respostas);
        Task<IList<RespostaAlunoEntity>> BuscarComQuestoesEAlternativas(Guid usuarioId);
        Task<IList<RespostaAlunoEntity>> BuscarComQuestoes(Guid usuarioId);
    }
}