using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_usuario_tbl_perfil_PerfilId",
                table: "tbl_usuario");

            migrationBuilder.DropIndex(
                name: "IX_tbl_usuario_PerfilId",
                table: "tbl_usuario");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "tbl_usuario");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "tbl_pagina",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_exercicios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "dataTermino", "tempo" },
                values: new object[] { new DateTime(2025, 11, 24, 22, 10, 39, 842, DateTimeKind.Local).AddTicks(197), new TimeSpan(2999999988) });

            migrationBuilder.UpdateData(
                table: "tbl_pagina",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCriacaoPagina",
                value: new DateTime(2025, 11, 24, 22, 5, 39, 836, DateTimeKind.Local).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "tbl_usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "codDiarioUsuario" },
                values: new object[] { new byte[] { 49, 246, 249, 39, 41, 71, 32, 75, 248, 38, 33, 37, 131, 206, 126, 91, 220, 179, 143, 67, 99, 206, 156, 42, 234, 182, 119, 65, 153, 138, 24, 20, 3, 102, 171, 70, 49, 211, 54, 241, 68, 136, 14, 226, 151, 183, 44, 7, 58, 180, 122, 54, 233, 250, 131, 47, 50, 85, 204, 9, 100, 24, 145, 202 }, new byte[] { 127, 252, 48, 77, 131, 229, 131, 85, 75, 236, 103, 28, 160, 252, 46, 150, 158, 41, 251, 193, 171, 72, 99, 68, 160, 150, 85, 196, 157, 182, 29, 165, 85, 231, 69, 121, 127, 232, 30, 180, 119, 97, 170, 218, 146, 111, 182, 28, 66, 32, 247, 226, 58, 19, 22, 228, 79, 178, 119, 123, 171, 146, 144, 216, 134, 8, 141, 191, 37, 138, 4, 59, 246, 193, 198, 73, 178, 21, 71, 182, 216, 132, 43, 145, 131, 158, 0, 117, 2, 69, 66, 12, 182, 91, 28, 127, 167, 103, 184, 169, 87, 134, 108, 187, 136, 49, 34, 211, 207, 48, 63, 114, 20, 145, 16, 41, 18, 244, 170, 213, 163, 108, 209, 180, 113, 50, 105, 195 }, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "tbl_usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "tbl_pagina",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.UpdateData(
                table: "tbl_usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "PerfilId", "codDiarioUsuario" },
                values: new object[] { new byte[] { 164, 223, 189, 43, 6, 182, 27, 35, 219, 114, 41, 192, 131, 203, 149, 253, 105, 159, 200, 143, 250, 217, 192, 84, 50, 59, 47, 253, 21, 71, 225, 87, 244, 0, 149, 156, 201, 248, 241, 80, 3, 234, 29, 150, 152, 147, 143, 133, 41, 245, 45, 108, 238, 217, 102, 78, 197, 183, 92, 145, 57, 108, 51, 2 }, new byte[] { 125, 200, 26, 6, 19, 191, 232, 104, 21, 43, 78, 69, 14, 245, 239, 156, 92, 30, 161, 150, 156, 175, 222, 73, 126, 219, 232, 160, 88, 231, 34, 156, 227, 94, 215, 39, 23, 179, 235, 220, 124, 229, 21, 190, 214, 129, 170, 105, 96, 104, 157, 160, 143, 94, 21, 32, 42, 1, 197, 254, 210, 69, 106, 126, 161, 3, 241, 181, 39, 195, 137, 49, 108, 107, 134, 103, 250, 69, 145, 218, 94, 161, 80, 181, 224, 182, 131, 170, 135, 202, 218, 47, 252, 55, 88, 112, 72, 85, 203, 249, 220, 175, 201, 86, 8, 215, 159, 124, 112, 205, 39, 233, 19, 170, 165, 96, 179, 43, 158, 65, 63, 136, 54, 129, 74, 178, 104, 195 }, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_usuario_PerfilId",
                table: "tbl_usuario",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_usuario_tbl_perfil_PerfilId",
                table: "tbl_usuario",
                column: "PerfilId",
                principalTable: "tbl_perfil",
                principalColumn: "Id");
        }
    }
}
