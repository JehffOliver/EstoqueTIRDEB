using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueTIRDEB.Migrations
{
    public partial class AtualizandoItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CD",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartamentoSetor",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipamento",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hostname",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotaFiscal",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroSerie",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patrimonio",
                table: "Itens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SistemaOperacional",
                table: "Itens",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CD",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "DepartamentoSetor",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Equipamento",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Hostname",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "NotaFiscal",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "NumeroSerie",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Patrimonio",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "SistemaOperacional",
                table: "Itens");
        }
    }
}
