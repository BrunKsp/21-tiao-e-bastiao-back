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
    public IAService(IUserInfo user, IMapper mapper = null, IDadosIARepository repository = null) : base(user)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task SalvarRespostaIa(RespostaIADto dto)
    {
        var dados = new DadosIACollection
        {
            Score = dto.Score,
            Descricao = dto.Descricao,
            QuestionarioSlug = dto.QuestionarioSlug
        };

        await _repository.Create(dados);
    }
}