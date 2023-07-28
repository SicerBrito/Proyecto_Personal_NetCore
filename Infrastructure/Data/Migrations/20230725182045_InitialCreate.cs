using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    IdEmail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.IdEmail);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    IdTelefono = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Telefonos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.IdTelefono);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoDeDocuemnto",
                columns: table => new
                {
                    IdTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Pasaporte = table.Column<int>(type: "int", nullable: false),
                    Licencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeDocuemnto", x => x.IdTipo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Tipo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.IdDocumento);
                    table.ForeignKey(
                        name: "FK_Documento_TipoDeDocuemnto_Tipo_Id",
                        column: x => x.Tipo_Id,
                        principalTable: "TipoDeDocuemnto",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DatosPersonales",
                columns: table => new
                {
                    IdInfo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCompleto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ocupacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Telefono_Id = table.Column<int>(type: "int", nullable: false),
                    Documento_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosPersonales", x => x.IdInfo);
                    table.ForeignKey(
                        name: "FK_DatosPersonales_Documento_Documento_Id",
                        column: x => x.Documento_Id,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatosPersonales_Telefono_Telefono_Id",
                        column: x => x.Telefono_Id,
                        principalTable: "Telefono",
                        principalColumn: "IdTelefono",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    IdLogin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email_Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Info_Id = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.IdLogin);
                    table.ForeignKey(
                        name: "FK_Login_DatosPersonales_Info_Id",
                        column: x => x.Info_Id,
                        principalTable: "DatosPersonales",
                        principalColumn: "IdInfo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Login_Email_Email_Id",
                        column: x => x.Email_Id,
                        principalTable: "Email",
                        principalColumn: "IdEmail",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DatosPersonales_Documento_Id",
                table: "DatosPersonales",
                column: "Documento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DatosPersonales_Telefono_Id",
                table: "DatosPersonales",
                column: "Telefono_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_Tipo_Id",
                table: "Documento",
                column: "Tipo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Email_Id",
                table: "Login",
                column: "Email_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Info_Id",
                table: "Login",
                column: "Info_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "DatosPersonales");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "TipoDeDocuemnto");
        }
    }
}
