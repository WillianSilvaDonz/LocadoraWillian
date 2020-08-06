using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoFilmes.Repositorio.Migrations
{
    public partial class AlterouReferenciaGenero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoGenero",
                table: "Filme");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Genero",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "GeneroId",
                table: "Filme",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Genero",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<long>(
                name: "GeneroId",
                table: "Filme",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "CodigoGenero",
                table: "Filme",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
