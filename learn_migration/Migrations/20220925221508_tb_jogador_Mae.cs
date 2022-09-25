using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learn_migration.Migrations
{
    public partial class tb_jogador_Mae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mae",
                table: "tb_jogador",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mae",
                table: "tb_jogador");
        }
    }
}
