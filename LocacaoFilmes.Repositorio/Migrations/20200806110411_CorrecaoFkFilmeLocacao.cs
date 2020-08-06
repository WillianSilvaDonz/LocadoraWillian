using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoFilmes.Repositorio.Migrations
{
    public partial class CorrecaoFkFilmeLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeLocacao_Locacao_LocacaoId",
                table: "FilmeLocacao");

            migrationBuilder.DropIndex(
                name: "IX_FilmeLocacao_FilmeId",
                table: "FilmeLocacao");

            migrationBuilder.DropIndex(
                name: "IX_FilmeLocacao_FilmeCodigo_LocacaoCodigo",
                table: "FilmeLocacao");

            migrationBuilder.DropColumn(
                name: "FilmeCodigo",
                table: "FilmeLocacao");

            migrationBuilder.DropColumn(
                name: "LocacaoCodigo",
                table: "FilmeLocacao");

            migrationBuilder.AlterColumn<long>(
                name: "LocacaoId",
                table: "FilmeLocacao",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FilmeId",
                table: "FilmeLocacao",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacao_FilmeId_LocacaoId",
                table: "FilmeLocacao",
                columns: new[] { "FilmeId", "LocacaoId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeLocacao_Locacao_LocacaoId",
                table: "FilmeLocacao",
                column: "LocacaoId",
                principalTable: "Locacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeLocacao_Locacao_LocacaoId",
                table: "FilmeLocacao");

            migrationBuilder.DropIndex(
                name: "IX_FilmeLocacao_FilmeId_LocacaoId",
                table: "FilmeLocacao");

            migrationBuilder.AlterColumn<long>(
                name: "LocacaoId",
                table: "FilmeLocacao",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "FilmeId",
                table: "FilmeLocacao",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "FilmeCodigo",
                table: "FilmeLocacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LocacaoCodigo",
                table: "FilmeLocacao",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacao_FilmeId",
                table: "FilmeLocacao",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacao_FilmeCodigo_LocacaoCodigo",
                table: "FilmeLocacao",
                columns: new[] { "FilmeCodigo", "LocacaoCodigo" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeLocacao_Locacao_LocacaoId",
                table: "FilmeLocacao",
                column: "LocacaoId",
                principalTable: "Locacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
