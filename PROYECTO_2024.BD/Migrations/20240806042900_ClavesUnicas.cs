using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROYECTO_2024.BD.Migrations
{
    /// <inheritdoc />
    public partial class ClavesUnicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Tdocumentos_TdocumentoId",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "Localidades",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "TdocumentoUq",
                table: "Tdocumentos",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LocalidadUq",
                table: "Localidades",
                column: "codigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Tdocumentos_TdocumentoId",
                table: "Personas",
                column: "TdocumentoId",
                principalTable: "Tdocumentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Tdocumentos_TdocumentoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "TdocumentoUq",
                table: "Tdocumentos");

            migrationBuilder.DropIndex(
                name: "LocalidadUq",
                table: "Localidades");

            migrationBuilder.AlterColumn<string>(
                name: "codigo",
                table: "Localidades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Tdocumentos_TdocumentoId",
                table: "Personas",
                column: "TdocumentoId",
                principalTable: "Tdocumentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
