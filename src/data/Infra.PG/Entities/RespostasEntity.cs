namespace data.Infra.PG.Entities;

public class RespostasEntity : BaseEntity
{
    public string Texto { get; set; }
    public bool Correta { get; set; }
    public Guid QuestaoId { get; set; }
    public QuestoesEntity Questao { get; set; }
}