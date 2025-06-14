namespace data.Infra.PG.Entities;

public class AlternativasEntity : BaseEntity
{
    public string Letra { get; set; }
    public string Texto { get; set; }
    public Guid QuestaoId { get; set; }
    public QuestoesEntity Questao { get; set; }
}