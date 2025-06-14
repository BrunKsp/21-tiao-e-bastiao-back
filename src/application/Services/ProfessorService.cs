using application.Dtos.Alunos;
using application.Dtos.Usuario;
using application.Interfaces;
using application.Utils;
using infra.Documents.Interfaces;

namespace application.Services;

public class ProfessorService : BaseService, IProfessorService
{
    private readonly IDadosIARepository _dadosIaRepository;
    private readonly IUsuarioService _usuarioService;
    public ProfessorService(IUserInfo user, IDadosIARepository dadosIaRepository, IUsuarioService usuarioService) : base(user)
    {
        _dadosIaRepository = dadosIaRepository;
        _usuarioService = usuarioService;
    }

    public async Task<TodosAlunosDto> BuscarTodosAlunos()
    {
        var dados = await _dadosIaRepository.BuscarTodos();

        var alunosUnicos = dados.Select(d => d.AlunoSlug).Distinct();

        var alunosInfo = new Dictionary<string, string>();

       
        foreach (var slug in alunosUnicos)
        {
            var usuario = await _usuarioService.BuscarPorSlug(slug);
            if (usuario != null)
                alunosInfo[slug] = usuario.Nome;
        }

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

                int totalPontuacao = grupo.Sum(q => q.Score);
                int totalQuestionarios = grupo.Count();
                int media = totalQuestionarios > 0
                    ? (int)Math.Round((double)totalPontuacao / totalQuestionarios)
                    : 0;

                return new AlunoComQuestionariosDto
                {
                    AlunoSlug = grupo.Key,
                    Nome = alunosInfo.TryGetValue(grupo.Key, out var nome) ? nome : "(Desconhecido)",
                    PontuacaoTotal = media,
                    Questionarios = questionarios
                };
            })
            .ToList();

        return new TodosAlunosDto { Alunos = agrupado };
    }
}