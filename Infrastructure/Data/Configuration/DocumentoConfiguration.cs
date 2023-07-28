using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.ToTable("Documento");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdDocumento")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Numero)
            .HasColumnName("Numero")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.TipoId)
            .HasColumnName("Tipo_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.TipoDeDocumento)
            .WithMany(p => p.Documentos)
            .HasForeignKey(p => p.TipoId);

    }
}
