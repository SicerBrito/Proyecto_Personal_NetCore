using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoContactoConfiguration : IEntityTypeConfiguration<TipoContacto>
{
    public void Configure(EntityTypeBuilder<TipoContacto> builder)
    {
        builder.ToTable("TipoContacto");

        builder.Property(p => p.PkNombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired();
    }
}
