using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class InfoPersonalConfiguration : IEntityTypeConfiguration<InfoPersonal>
{
    public void Configure(EntityTypeBuilder<InfoPersonal> builder)
    {
        builder.ToTable("DatosPersonales");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdInfo")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.NombreCompleto)
            .HasColumnName("NombreCompleto")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Ocupacion)
            .HasColumnName("Ocupacion")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Edad)
            .HasColumnName("Edad")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.TelefonoId)
            .HasColumnName("Telefono_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Telefonos)
            .WithMany(p => p.DatosPersonales)
            .HasForeignKey(p => p.TelefonoId);

        builder.Property(p => p.DocumentoId)
            .HasColumnName("Documento_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Documentos)
            .WithMany(p => p.DatosPersonales)
            .HasForeignKey(p => p.DocumentoId);


    }
}
