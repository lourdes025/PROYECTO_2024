using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROYECTO_2024.BD.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personas_LocalidadId",
                table: "Personas",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Localidades_LocalidadId",
                table: "Personas",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Localidades_LocalidadId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_LocalidadId",
                table: "Personas");
        }
    }
}
