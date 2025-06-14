namespace application.Dtos.Usuario;

public class AlunoComQuestionariosDto
{
    public string AlunoSlug { get; set; }
    public int PontuacaoTotal { get; set; }
    public List<QuestionarioAlunoDto> Questionarios { get; set; }
}