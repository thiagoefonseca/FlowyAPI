using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class TesteNivelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_nivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nivelUsuario = table.Column<int>(type: "int", nullable: false),
                    qtdXp = table.Column<int>(type: "int", nullable: false),
                    idPerfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_nivel", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "tbl_exercicios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "dataTermino", "tempo" },
                values: new object[] { new DateTime(2025, 10, 13, 22, 19, 56, 114, DateTimeKind.Local).AddTicks(5742), new TimeSpan(2999999995) });

            migrationBuilder.UpdateData(
                table: "tbl_pagina",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCriacaoPagina",
                value: new DateTime(2025, 10, 13, 22, 14, 56, 111, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "tbl_usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 54, 180, 59, 134, 101, 114, 163, 74, 190, 66, 140, 170, 81, 190, 1, 156, 238, 52, 70, 185, 0, 244, 97, 217, 109, 189, 185, 39, 89, 152, 96, 160, 173, 81, 127, 91, 249, 248, 46, 241, 124, 48, 123, 213, 130, 135, 224, 173, 26, 232, 5, 151, 142, 163, 198, 101, 181, 146, 200, 21, 177, 187, 51, 241 }, new byte[] { 182, 205, 113, 177, 52, 159, 67, 1, 221, 51, 123, 230, 97, 152, 50, 196, 9, 244, 95, 116, 97, 192, 169, 211, 147, 193, 154, 67, 103, 198, 48, 99, 84, 40, 223, 185, 194, 191, 145, 225, 118, 121, 238, 138, 62, 197, 228, 49, 37, 25, 85, 197, 29, 143, 83, 227, 57, 113, 189, 148, 186, 176, 123, 33, 155, 166, 204, 16, 50, 216, 235, 87, 158, 148, 230, 133, 152, 25, 35, 169, 112, 77, 156, 169, 73, 151, 158, 126, 86, 79, 208, 88, 19, 79, 81, 254, 34, 41, 195, 226, 44, 251, 97, 122, 182, 31, 34, 195, 154, 194, 77, 219, 45, 119, 37, 123, 70, 3, 151, 158, 36, 85, 24, 190, 208, 212, 147, 242 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_nivel");

            migrationBuilder.UpdateData(
                table: "tbl_exercicios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "dataTermino", "tempo" },
                values: new object[] { new DateTime(2025, 10, 13, 21, 50, 25, 570, DateTimeKind.Local).AddTicks(7811), new TimeSpan(2999999991) });

            migrationBuilder.UpdateData(
                table: "tbl_pagina",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCriacaoPagina",
                value: new DateTime(2025, 10, 13, 21, 45, 25, 566, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.UpdateData(
                table: "tbl_usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 126, 54, 74, 227, 223, 40, 203, 201, 248, 163, 63, 136, 107, 210, 166, 224, 126, 184, 86, 39, 188, 62, 14, 147, 68, 223, 221, 114, 100, 238, 125, 17, 206, 108, 120, 15, 9, 58, 164, 199, 220, 168, 80, 202, 96, 153, 142, 71, 0, 240, 112, 240, 18, 39, 58, 243, 235, 176, 96, 12, 178, 161, 42, 170 }, new byte[] { 228, 135, 89, 148, 0, 85, 23, 70, 170, 165, 63, 170, 22, 190, 142, 118, 22, 59, 5, 180, 111, 168, 237, 216, 236, 156, 232, 108, 240, 231, 195, 189, 238, 249, 31, 154, 55, 135, 182, 8, 159, 181, 32, 28, 174, 177, 132, 102, 182, 116, 97, 174, 57, 59, 176, 234, 106, 167, 2, 172, 76, 51, 88, 128, 18, 81, 69, 232, 115, 10, 149, 90, 153, 13, 252, 138, 166, 83, 35, 178, 176, 114, 28, 178, 233, 179, 48, 103, 171, 244, 65, 63, 204, 179, 195, 160, 42, 225, 213, 5, 26, 106, 95, 224, 42, 122, 169, 9, 81, 225, 93, 219, 60, 42, 209, 19, 195, 97, 191, 177, 212, 126, 233, 251, 215, 140, 97, 99 } });
        }
    }
}
