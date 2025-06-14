using application.Dtos.Alunos;
using application.Dtos.Usuario;
using application.Interfaces;
using application.Utils;
using infra.Documents.Interfaces;

namespace application.Services;

public class ProfessorService : BaseService, IProfessorService
{
    private readonly IDadosIARepository _dadosIaRepository;
    public ProfessorService(IUserInfo user, IDadosIARepository dadosIaRepository) : base(user)
    {
        _dadosIaRepository = dadosIaRepository;
    }

    public async Task<TodosAlunosDto> BuscarTodosAlunos()
    {
        var dados = await _dadosIaRepository.BuscarTodos();

        var agrupado = dados
            .GroupBy(x => x.AlunoSlug)
            .Select(grupo =>
            {
                var questionarios = grupo.Select(q => new QuestionarioAlunoDto
                {
                    QuestionarioSlug = q.QuestionarioSlug,
                    Score = q.Score,
                    Descricao = q.Descricao
                }).ToList();

                int somaPontuacao = grupo.Sum(q => q.Score);

                return new AlunoComQuestionariosDto
                {
                    AlunoSlug = grupo.Key,
                    PontuacaoTotal = somaPontuacao,
                    Questionarios = questionarios
                };
            })
            .ToList();

        return new TodosAlunosDto { Alunos = agrupado };
    }
}