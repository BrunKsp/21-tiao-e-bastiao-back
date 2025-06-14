using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class Questionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "questao",
                schema: "code_race",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    enunciado = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Tema = table.Column<string>(type: "varchar(100)", nullable: true),
                    alternativa_correta = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "alternativa",
                schema: "code_race",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    letra = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    texto = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternativa", x => x.id);
                    table.ForeignKey(
                        name: "FK_alternativa_questao_QuestaoId",
                        column: x => x.QuestaoId,
                        principalSchema: "code_race",
                        principalTable: "questao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resposta_aluno",
                schema: "code_race",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    questao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    letra_escolhida = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    respondido_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    acertou = table.Column<bool>(type: "boolean", nullable: false),
                    slug = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    criado_em = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resposta_aluno", x => x.id);
                    table.ForeignKey(
                        name: "FK_resposta_aluno_questao_questao_id",
                        column: x => x.questao_id,
                        principalSchema: "code_race",
                        principalTable: "questao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alternativa_QuestaoId",
                schema: "code_race",
                table: "alternativa",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_alternativa_slug",
                schema: "code_race",
                table: "alternativa",
                column: "slug");

            migrationBuilder.CreateIndex(
                name: "IX_questao_slug",
                schema: "code_race",
                table: "questao",
                column: "slug");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_aluno_questao_id",
                schema: "code_race",
                table: "resposta_aluno",
                column: "questao_id");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_aluno_slug",
                schema: "code_race",
                table: "resposta_aluno",
                column: "slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alternativa",
                schema: "code_race");

            migrationBuilder.DropTable(
                name: "resposta_aluno",
                schema: "code_race");

            migrationBuilder.DropTable(
                name: "questao",
                schema: "code_race");
        }
    }
}
