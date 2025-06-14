using application.Dtos.Questoes;
using application.Dtos.Questoes.Resposta;
using Microsoft.AspNetCore.Mvc;

namespace application.Interfaces;

public interface IQuestoesServices
{
    Task<IList<QuestoesDto>> BuscarTodas();
    Task RegistrarRespostas(RespostasQuestionarioDto dto);
}