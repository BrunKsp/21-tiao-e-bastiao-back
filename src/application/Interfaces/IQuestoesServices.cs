using application.Dtos.Questionario;
using application.Dtos.Questoes;
using application.Dtos.Questoes.Resposta;
using Microsoft.AspNetCore.Mvc;

namespace application.Interfaces;

public interface IQuestoesServices
{
    Task<IList<QuestoesDto>> BuscarTodas();
    Task<IList<RespostaQuestaoDto>> RegistrarRespostas(RespostasQuestionarioDto dto);
    // Task<IList<RespostaAlunoDetalhadaDto>> BuscarRespostasPorUsuario(string usuarioSlug);
    Task<IList<QuestionarioRespondidoDto>> BuscarRespostasAgrupadasPorTema(string usuarioSlug);
}