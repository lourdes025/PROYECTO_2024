using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROYECTO_2024.BD.Migrations
{
    /// <inheritdoc />
    public partial class Indices_Persona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personas_TdocumentoId",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "PersonaApellido_Nombre",
                table: "Personas",
                columns: new[] { "Apellido", "Nombre" });

            migrationBuilder.CreateIndex(
                name: "PersonaUq",
                table: "Personas",
                columns: new[] { "TdocumentoId", "NumDoc" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "PersonaApellido_Nombre",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "PersonaUq",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TdocumentoId",
                table: "Personas",
                column: "TdocumentoId");
        }
    }
}
