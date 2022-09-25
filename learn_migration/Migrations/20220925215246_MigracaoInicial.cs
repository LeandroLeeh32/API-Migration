using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace learn_migration.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_genero",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    genero = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genero", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_instituicao",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_instituicao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_jogador",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    sobrenome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    data_nasc = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_jogador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_inscrito",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    jogador = table.Column<int>(type: "integer", nullable: false),
                    instituicao = table.Column<int>(type: "integer", nullable: false),
                    data_pub = table.Column<DateOnly>(type: "date", nullable: true),
                    genero = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_inscrito", x => x.id);
                    table.ForeignKey(
                        name: "tb_inscrito_genero_fkey",
                        column: x => x.genero,
                        principalTable: "tb_genero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tb_inscrito_instituicao_fkey",
                        column: x => x.instituicao,
                        principalTable: "tb_instituicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "tb_inscrito_jogador_fkey",
                        column: x => x.jogador,
                        principalTable: "tb_jogador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "tb_genero_genero_key",
                table: "tb_genero",
                column: "genero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscrito_genero",
                table: "tb_inscrito",
                column: "genero");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscrito_instituicao",
                table: "tb_inscrito",
                column: "instituicao");

            migrationBuilder.CreateIndex(
                name: "IX_tb_inscrito_jogador",
                table: "tb_inscrito",
                column: "jogador");

            migrationBuilder.CreateIndex(
                name: "tb_instituicao_nome_key",
                table: "tb_instituicao",
                column: "nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_inscrito");

            migrationBuilder.DropTable(
                name: "tb_genero");

            migrationBuilder.DropTable(
                name: "tb_instituicao");

            migrationBuilder.DropTable(
                name: "tb_jogador");
        }
    }
}
