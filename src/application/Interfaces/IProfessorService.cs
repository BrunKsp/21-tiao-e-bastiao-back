using application.Dtos.Alunos;

namespace application.Interfaces;

public interface IProfessorService
{
    Task<TodosAlunosDto> BuscarTodosAlunos();
}