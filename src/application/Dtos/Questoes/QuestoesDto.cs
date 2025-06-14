namespace application.Dtos.Questoes;

public class QuestoesDto
{
    public string Enunciado { get; set; }
    public string Tema { get; set; }
    public string Slug { get; set; }
    public ICollection<AlternativasDto> Alternativas { get; set; }
}