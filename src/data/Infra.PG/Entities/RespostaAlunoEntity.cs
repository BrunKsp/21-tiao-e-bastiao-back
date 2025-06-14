namespace data.Infra.PG.Entities;

public class RespostaAlunoEntity : BaseEntity
{
     public Guid UsuarioId { get; set; } 
    public Guid QuestaoId { get; set; }
    public string LetraEscolhida { get; set; } 
    public DateTime RespondidoEm { get; set; }
    public QuestoesEntity Questao { get; set; }
    public bool Acertou { get; set; }
}