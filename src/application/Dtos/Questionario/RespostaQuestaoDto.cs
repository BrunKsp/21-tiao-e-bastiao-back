namespace application.Dtos.Questionario;

public class RespostaQuestaoDto
{
    public string QuestaoSlug { get; set; }
    public string Enunciado { get; set; }
    public string AlternativaCorreta { get; set; }
    public string LetraEscolhida { get; set; }
    public bool Acertou { get; set; }
    // public DateTime RespondidoEm { get; set; }
}