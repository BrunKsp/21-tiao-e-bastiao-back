using data.Infra.PG.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data.Infra.PG.Configurations
{
    public class UsuarioConfiguration : BaseConfiguration<UsuarioEntity>
    {
        public override void ConfigureOtherProperties(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("usuario");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Senha)
                .HasColumnName("senha");

            builder.Property(p => p.TipoUsuario)
                .HasColumnName("tipo_usuario");
        }
    }
}