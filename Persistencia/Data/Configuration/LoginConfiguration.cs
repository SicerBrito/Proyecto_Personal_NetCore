using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.ToTable("Login");

        builder.Property(p => p.IdUser)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdUser")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Email)
            .HasColumnName("Email")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(p => p.Password)
            .HasColumnName("Password")
            .HasColumnType("varchar")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(p => p.PersonaId)
            .HasColumnName("PersonaId")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Personas)
            .WithMany(p => p.Logins)
            .HasForeignKey(p => p.PersonaId);
            
    }
}
