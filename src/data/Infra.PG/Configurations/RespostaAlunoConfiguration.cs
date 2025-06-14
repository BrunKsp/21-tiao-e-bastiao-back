using data.Infra.PG.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Infra.PG.Configurations;

public class RespostaAlunoConfiguration : BaseConfiguration<RespostaAlunoEntity>
{
    public override void ConfigureOtherProperties(EntityTypeBuilder<RespostaAlunoEntity> builder)
    {
        builder.ToTable("resposta_aluno");

        builder.Property(r => r.UsuarioId)
            .HasColumnName("usuario_id")
            .IsRequired();

        builder.Property(r => r.QuestaoId)
            .HasColumnName("questao_id")
            .IsRequired();

        builder.Property(r => r.LetraEscolhida)
            .HasColumnName("letra_escolhida")
            .IsRequired()
            .HasMaxLength(1);

        builder.Property(r => r.RespondidoEm)
            .HasColumnName("respondido_em")
            .IsRequired();

        builder.Property(r => r.Acertou)
            .HasColumnName("acertou")
            .IsRequired();
    }
}
