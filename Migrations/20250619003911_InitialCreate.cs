using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PAGINAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codDiario = table.Column<int>(type: "int", nullable: false),
                    Humor = table.Column<int>(type: "int", nullable: false),
                    tituloPagina = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    temaPagina = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    qtdCaracteresPagina = table.Column<int>(type: "int", nullable: false),
                    dtCriacaoPagina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtExclusaoPagina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtModificacaoPagina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contPagina = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PAGINAS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_PAGINAS",
                columns: new[] { "Id", "Humor", "codDiario", "contPagina", "dtCriacaoPagina", "dtExclusaoPagina", "dtModificacaoPagina", "qtdCaracteresPagina", "temaPagina", "tituloPagina" },
                values: new object[] { 1, 1, 1, "teste 123 123 teste de novo", new DateTime(2025, 6, 18, 21, 39, 10, 109, DateTimeKind.Local).AddTicks(8457), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, "teste", "Pagina1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PAGINAS");
        }
    }
}
