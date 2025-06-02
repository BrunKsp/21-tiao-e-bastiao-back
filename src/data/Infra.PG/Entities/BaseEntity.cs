namespace data.Infra.PG.Entities;

public class BaseEntity
{
    public virtual Guid Id { get; set; }
    public virtual string Slug { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;

    public void SetSlug(string slug)
    {
        if (string.IsNullOrWhiteSpace(Slug))
            Slug = slug;
    }
}