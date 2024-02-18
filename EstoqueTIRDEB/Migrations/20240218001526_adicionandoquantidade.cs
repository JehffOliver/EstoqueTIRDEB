using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueTIRDEB.Migrations
{
    public partial class adicionandoquantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDisponivel",
                table: "Itens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeDisponivel",
                table: "Itens");
        }
    }
}
