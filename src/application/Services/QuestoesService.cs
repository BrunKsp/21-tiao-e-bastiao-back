using application.Dtos.Questionario;
using application.Dtos.Questoes;
using application.Dtos.Questoes.Resposta;
using application.Interfaces;
using application.Utils;
using AutoMapper;
using data.Infra.PG.Entities;
using infra.PG.Interfaces;

namespace application.Services;

public class QuestoesService : BaseService, IQuestoesServices
{
    private readonly IQuestoesRepository _repository;
    private readonly IRespostaAlunoRepository _respostaAlunoRepository;
    private readonly IMapper _mapper;
    private readonly IUsuarioService _usuarioService;

    public QuestoesService(
        IUserInfo user,
        IQuestoesRepository repository,
        IRespostaAlunoRepository respostaAlunoRepository,
        IMapper mapper
,
        IUsuarioService usuarioService) : base(user)
    {
        _repository = repository;
        _respostaAlunoRepository = respostaAlunoRepository;
        _mapper = mapper;
        _usuarioService = usuarioService;
    }

    public async Task<IList<QuestoesDto>> BuscarTodas()
    {
        var questoes = await _repository.BuscarTodas();
        return _mapper.Map<IList<QuestoesDto>>(questoes);
    }

    public async Task RegistrarRespostas(RespostasQuestionarioDto dto)
    {
        var usuarioSlug = GetUserSlug();
        var usuario = await _usuarioService.BuscarPorSlug(usuarioSlug);

        var entidades = new List<RespostaAlunoEntity>();

        foreach (var resposta in dto.Respostas)
        {
            var questao = await _repository.BuscarPorSlug(resposta.Slug);

            if (questao == null)
                throw new Exception($"Questão com slug '{resposta.Slug}' não encontrada.");

            var acertou = string.Equals(
                questao.AlternativaCorreta,
                resposta.LetraEscolhida,
                StringComparison.OrdinalIgnoreCase
            );

            entidades.Add(new RespostaAlunoEntity
            {
                UsuarioId = usuario.Id,
                QuestaoId = questao.Id,
                LetraEscolhida = resposta.LetraEscolhida.ToUpperInvariant(),
                RespondidoEm = DateTime.UtcNow,
                Acertou = acertou
            });
        }
        await _respostaAlunoRepository.AddRange(entidades);
    }

    public async Task<IList<QuestionarioRespondidoDto>> BuscarRespostasAgrupadasPorTema(string usuarioSlug)
    {
        var usuario = await _usuarioService.BuscarPorSlug(usuarioSlug);
        var respostas = await _respostaAlunoRepository.BuscarComQuestoes(usuario.Id);

        var agrupado = respostas
            .GroupBy(r => r.Questao.Tema)
            .Select(grupo => new QuestionarioRespondidoDto
            {
                Tema = grupo.Key,
                Questoes = grupo.Select(r => new RespostaQuestaoDto
                {
                    Enunciado = r.Questao.Enunciado,
                    AlternativaCorreta = r.Questao.AlternativaCorreta,
                    LetraEscolhida = r.LetraEscolhida,
                    Acertou = r.Acertou,
                }).ToList()
            }).ToList();

        return agrupado;
    }
}
