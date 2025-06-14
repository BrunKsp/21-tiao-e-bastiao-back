using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alternativa_questao_QuestaoId",
                schema: "code_race",
                table: "alternativa");

            migrationBuilder.RenameColumn(
                name: "QuestaoId",
                schema: "code_race",
                table: "alternativa",
                newName: "questao_id");

            migrationBuilder.RenameIndex(
                name: "IX_alternativa_QuestaoId",
                schema: "code_race",
                table: "alternativa",
                newName: "IX_alternativa_questao_id");

            migrationBuilder.AddForeignKey(
                name: "FK_alternativa_questao_questao_id",
                schema: "code_race",
                table: "alternativa",
                column: "questao_id",
                principalSchema: "code_race",
                principalTable: "questao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alternativa_questao_questao_id",
                schema: "code_race",
                table: "alternativa");

            migrationBuilder.RenameColumn(
                name: "questao_id",
                schema: "code_race",
                table: "alternativa",
                newName: "QuestaoId");

            migrationBuilder.RenameIndex(
                name: "IX_alternativa_questao_id",
                schema: "code_race",
                table: "alternativa",
                newName: "IX_alternativa_QuestaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_alternativa_questao_QuestaoId",
                schema: "code_race",
                table: "alternativa",
                column: "QuestaoId",
                principalSchema: "code_race",
                principalTable: "questao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
