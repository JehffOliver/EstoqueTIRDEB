using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueTIRDEB.Migrations
{
    public partial class AtualizandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especificações",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Itens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Especificações",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Itens",
                nullable: false,
                defaultValue: "");
        }
    }
}
