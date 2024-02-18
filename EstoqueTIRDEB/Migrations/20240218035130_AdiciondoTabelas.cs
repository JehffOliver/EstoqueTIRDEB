using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueTIRDEB.Migrations
{
    public partial class AdiciondoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "EntradaeSaidas",
                newName: "DataSaida");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrada",
                table: "EntradaeSaidas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEntrada",
                table: "EntradaeSaidas");

            migrationBuilder.RenameColumn(
                name: "DataSaida",
                table: "EntradaeSaidas",
                newName: "Date");
        }
    }
}
