using data.Infra.PG.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Infra.PG.Configurations;

public class AlternativaConfiguration : BaseConfiguration<AlternativasEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<AlternativasEntity> builder)
    {
        builder.ToTable("alternativa");

        builder.Property(a => a.Letra)
            .HasColumnName("letra")
            .IsRequired()
            .HasMaxLength(1);

        builder.Property(a => a.Texto)
            .HasColumnName("texto")
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(a => a.QuestaoId)
           .HasColumnName("questao_id")
           .IsRequired();

        builder.HasOne(a => a.Questao)
            .WithMany(q => q.Alternativas)
            .HasForeignKey(a => a.QuestaoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
