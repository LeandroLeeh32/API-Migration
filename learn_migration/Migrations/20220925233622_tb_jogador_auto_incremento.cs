using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learn_migration.Migrations
{
    public partial class tb_jogador_auto_incremento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_jogador",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_jogador",
                newName: "id");
        }
    }
}
