using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("TipoDocumento");

        builder.Property(p => p.PkNombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();
    }
}
