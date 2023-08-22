using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");

        builder.Property(p => p.NroDocumento)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("NroDocumento")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.TipoDocumentoFk)
            .HasColumnName("TipoDocumentoFk")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.HasOne(p => p.TipoDeDocumentos)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.TipoDocumentoFk);

        builder.Property(p => p.Nombres)
            .HasColumnName("Nombres")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Apellidos)
            .HasColumnName("Apellidos")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Ocupacion)
            .HasColumnName("Ocupacion")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(p => p.Edad)
            .HasColumnName("Edad")
            .HasColumnType("int")
            .IsRequired();

    }
}
