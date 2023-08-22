﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Data;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(SicerContext))]
    partial class SicerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Contacto", b =>
                {
                    b.Property<int>("PkContacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PkContacto")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonaFk")
                        .HasColumnType("int")
                        .HasColumnName("PersonaFk");

                    b.Property<string>("TipoContactoFk")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("TipoContactoFk");

                    b.Property<string>("ValorContacto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("ValorContacto");

                    b.HasKey("PkContacto");

                    b.HasIndex("PersonaFk");

                    b.HasIndex("TipoContactoFk");

                    b.ToTable("Contacto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Login", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdUser")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("Password");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int")
                        .HasColumnName("PersonaId");

                    b.HasKey("IdUser");

                    b.HasIndex("PersonaId");

                    b.ToTable("Login", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<int>("NroDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NroDocumento")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Apellidos");

                    b.Property<int>("Edad")
                        .HasColumnType("int")
                        .HasColumnName("Edad");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombres");

                    b.Property<string>("Ocupacion")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("Ocupacion");

                    b.Property<string>("TipoDocumentoFk")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("TipoDocumentoFk");

                    b.HasKey("NroDocumento");

                    b.HasIndex("TipoDocumentoFk");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Property<string>("PkNombre")
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("PkNombre");

                    b.ToTable("TipoContacto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoDocumento", b =>
                {
                    b.Property<string>("PkNombre")
                        .HasMaxLength(25)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("PkNombre");

                    b.ToTable("TipoDocumento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Contacto", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Personas")
                        .WithMany("Contactos")
                        .HasForeignKey("PersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.TipoContacto", "TipoDeContactos")
                        .WithMany("Contactos")
                        .HasForeignKey("TipoContactoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personas");

                    b.Navigation("TipoDeContactos");
                });

            modelBuilder.Entity("Dominio.Entities.Login", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "Personas")
                        .WithMany("Logins")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.HasOne("Dominio.Entities.TipoDocumento", "TipoDeDocumentos")
                        .WithMany("Personas")
                        .HasForeignKey("TipoDocumentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeDocumentos");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("Contactos");

                    b.Navigation("Logins");
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("Dominio.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}