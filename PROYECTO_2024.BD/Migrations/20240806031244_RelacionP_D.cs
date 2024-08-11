using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROYECTO_2024.BD.Migrations
{
    /// <inheritdoc />
    public partial class RelacionP_D : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personas_TdocumentoId",
                table: "Personas",
                column: "TdocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Tdocumentos_TdocumentoId",
                table: "Personas",
                column: "TdocumentoId",
                principalTable: "Tdocumentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Tdocumentos_TdocumentoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TdocumentoId",
                table: "Personas");
        }
    }
}
