namespace data.Infra.PG.Entities;

public class QuestoesEntity : BaseEntity
{
    public string Enunciado { get; set; }
    public string Tema { get; set; }
    public string AlternativaCorreta { get; set; }
    public ICollection<AlternativasEntity> Alternativas { get; set; }
}