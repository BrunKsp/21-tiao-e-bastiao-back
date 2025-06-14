using application.Dtos.Usuario;

namespace application.Dtos.Alunos;

public class TodosAlunosDto
{
    public List<AlunoComQuestionariosDto> Alunos { get; set; } = new();
}