using data.Infra.PG.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Infra.PG.Configurations;

public class QuestoesConfiguration : BaseConfiguration<QuestoesEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<QuestoesEntity> builder)
    {
        builder.ToTable("questao");

        builder.Property(q => q.Enunciado)
            .HasColumnName("enunciado")
            .IsRequired()
            .HasMaxLength(500);
        
         builder.Property(q => q.Tema)
            .HasColumnName("tema")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(q => q.AlternativaCorreta)
            .HasColumnName("alternativa_correta")
            .IsRequired()
            .HasMaxLength(1);

        builder.HasMany(q => q.Alternativas)
            .WithOne(a => a.Questao)
            .HasForeignKey(a => a.QuestaoId);
    }
}
