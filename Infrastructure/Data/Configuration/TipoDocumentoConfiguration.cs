using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("TipoDeDocuemnto");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdTipo")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.DNI)
            .HasColumnName("DNI")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Cedula)
            .HasColumnName("Cedula")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Pasaporte)
            .HasColumnName("Pasaporte")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Licencia)
            .HasColumnName("Licencia")
            .HasColumnType("int")
            .IsRequired();


    }
}
