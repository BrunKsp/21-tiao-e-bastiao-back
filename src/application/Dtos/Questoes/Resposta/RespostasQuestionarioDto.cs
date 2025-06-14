namespace application.Dtos.Questoes.Resposta;

public class RespostasQuestionarioDto
{
    public string Slug { get; set; }
    public List<RespostaAlunoDto> Respostas { get; set; }
}