using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class QuestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbl_exercicios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "dataTermino", "tempo" },
                values: new object[] { new DateTime(2025, 10, 21, 21, 57, 4, 50, DateTimeKind.Local).AddTicks(1602), new TimeSpan(2999999990) });

            migrationBuilder.UpdateData(
                table: "tbl_pagina",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCriacaoPagina",
                value: new DateTime(2025, 10, 21, 21, 52, 4, 43, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.InsertData(
                table: "tbl_perfil",
                columns: new[] { "Id", "IdNivel", "IdQuest", "IdUsuario", "infoPerfil", "nomePerfil" },
                values: new object[] { 1, 1, 1, 1, "Perfil de teste", "TesteDaSilva" });

            migrationBuilder.UpdateData(
                table: "tbl_usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 164, 223, 189, 43, 6, 182, 27, 35, 219, 114, 41, 192, 131, 203, 149, 253, 105, 159, 200, 143, 250, 217, 192, 84, 50, 59, 47, 253, 21, 71, 225, 87, 244, 0, 149, 156, 201, 248, 241, 80, 3, 234, 29, 150, 152, 147, 143, 133, 41, 245, 45, 108, 238, 217, 102, 78, 197, 183, 92, 145, 57, 108, 51, 2 }, new byte[] { 125, 200, 26, 6, 19, 191, 232, 104, 21, 43, 78, 69, 14, 245, 239, 156, 92, 30, 161, 150, 156, 175, 222, 73, 126, 219, 232, 160, 88, 231, 34, 156, 227, 94, 215, 39, 23, 179, 235, 220, 124, 229, 21, 190, 214, 129, 170, 105, 96, 104, 157, 160, 143, 94, 21, 32, 42, 1, 197, 254, 210, 69, 106, 126, 161, 3, 241, 181, 39, 195, 137, 49, 108, 107, 134, 103, 250, 69, 145, 218, 94, 161, 80, 181, 224, 182, 131, 170, 135, 202, 218, 47, 252, 55, 88, 112, 72, 85, 203, 249, 220, 175, 201, 86, 8, 215, 159, 124, 112, 205, 39, 233, 19, 170, 165, 96, 179, 43, 158, 65, 63, 136, 54, 129, 74, 178, 104, 195 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_perfil",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
