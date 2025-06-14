using application.Dtos.IA;
using application.Interfaces;
using application.Utils;
using AutoMapper;
using data.Infra.Documents.Collections;
using infra.Documents.Interfaces;


namespace application.Services;

public class IAService : BaseService, IIAService
{
    private readonly IMapper _mapper;
    private readonly IDadosIARepository _repository;
    private readonly IUsuarioService _usuarioService;
    public IAService(IUserInfo user, IMapper mapper = null, IDadosIARepository repository = null, IUsuarioService usuarioService = null) : base(user)
    {
        _mapper = mapper;
        _repository = repository;
        _usuarioService = usuarioService;
    }
    public async Task SalvarRespostaIa(RespostaIADto dto)
    {
        var usuario = GetUserSlug();
        var dadosUsuario = await _usuarioService.BuscarPorSlug(usuario);

        var dados = new DadosIACollection
        {
            AlunoSlug = dadosUsuario.Slug,
            Score = dto.Score,
            Descricao = dto.Descricao,
            QuestionarioSlug = dto.QuestionarioSlug
        };

        await _repository.Create(dados);
    }
}