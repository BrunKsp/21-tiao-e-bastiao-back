using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tema",
                schema: "code_race",
                table: "questao",
                newName: "tema");

            migrationBuilder.AlterColumn<string>(
                name: "tema",
                schema: "code_race",
                table: "questao",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tema",
                schema: "code_race",
                table: "questao",
                newName: "Tema");

            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                schema: "code_race",
                table: "questao",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
