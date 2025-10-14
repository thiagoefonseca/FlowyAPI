using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class TesteQuestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "tbl_usuario");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "tbl_usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idPerfil",
                table: "tbl_usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    infoPerfil = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: false),
                    nomePerfil = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: false),
                    IdNivel = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdQuest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_quest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: false),
                    qtdXpResgatavel = table.Column<int>(type: "int", nullable: false),
                    idDificuldade = table.Column<int>(type: "int", nullable: false),
                    idPerfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_quest", x => x.Id);
                });

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
                columns: new[] { "Email", "PasswordHash", "PasswordSalt", "PerfilId", "idPerfil" },
                values: new object[] { "seuemail@email.com", new byte[] { 126, 54, 74, 227, 223, 40, 203, 201, 248, 163, 63, 136, 107, 210, 166, 224, 126, 184, 86, 39, 188, 62, 14, 147, 68, 223, 221, 114, 100, 238, 125, 17, 206, 108, 120, 15, 9, 58, 164, 199, 220, 168, 80, 202, 96, 153, 142, 71, 0, 240, 112, 240, 18, 39, 58, 243, 235, 176, 96, 12, 178, 161, 42, 170 }, new byte[] { 228, 135, 89, 148, 0, 85, 23, 70, 170, 165, 63, 170, 22, 190, 142, 118, 22, 59, 5, 180, 111, 168, 237, 216, 236, 156, 232, 108, 240, 231, 195, 189, 238, 249, 31, 154, 55, 135, 182, 8, 159, 181, 32, 28, 174, 177, 132, 102, 182, 116, 97, 174, 57, 59, 176, 234, 106, 167, 2, 172, 76, 51, 88, 128, 18, 81, 69, 232, 115, 10, 149, 90, 153, 13, 252, 138, 166, 83, 35, 178, 176, 114, 28, 178, 233, 179, 48, 103, 171, 244, 65, 63, 204, 179, 195, 160, 42, 225, 213, 5, 26, 106, 95, 224, 42, 122, 169, 9, 81, 225, 93, 219, 60, 42, 209, 19, 195, 97, 191, 177, 212, 126, 233, 251, 215, 140, 97, 99 }, null, 1 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_usuario_tbl_perfil_PerfilId",
                table: "tbl_usuario");

            migrationBuilder.DropTable(
                name: "tbl_perfil");

            migrationBuilder.DropTable(
                name: "tbl_quest");

            migrationBuilder.DropIndex(
                name: "IX_tbl_usuario_PerfilId",
                table: "tbl_usuario");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "tbl_usuario");

            migrationBuilder.DropColumn(
                name: "idPerfil",
                table: "tbl_usuario");

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "tbl_usuario",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: true,
                defaultValue: "Utilizador");

            migrationBuilder.UpdateData(
                table: "tbl_exercicios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "dataTermino", "tempo" },
                values: new object[] { new DateTime(2025, 9, 29, 22, 9, 49, 543, DateTimeKind.Local).AddTicks(4472), new TimeSpan(2999999995) });

            migrationBuilder.UpdateData(
                table: "tbl_pagina",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCriacaoPagina",
                value: new DateTime(2025, 9, 29, 22, 4, 49, 540, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "tbl_usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash", "PasswordSalt", "Perfil" },
                values: new object[] { "thiagoefonseca2007@gmail.com", new byte[] { 32, 19, 147, 196, 61, 63, 178, 69, 177, 126, 197, 247, 33, 53, 160, 65, 229, 125, 152, 208, 226, 168, 46, 105, 108, 185, 73, 236, 255, 53, 53, 148, 71, 182, 228, 32, 46, 140, 14, 188, 40, 86, 165, 22, 166, 89, 20, 65, 41, 231, 38, 175, 223, 143, 0, 128, 83, 171, 90, 52, 234, 147, 76, 38 }, new byte[] { 51, 39, 4, 123, 122, 95, 200, 193, 175, 50, 133, 219, 251, 253, 203, 170, 211, 8, 181, 57, 76, 231, 136, 12, 19, 18, 161, 58, 219, 167, 247, 171, 253, 199, 87, 252, 52, 153, 157, 242, 171, 228, 201, 137, 148, 213, 179, 117, 159, 73, 15, 21, 57, 37, 65, 68, 252, 145, 196, 209, 56, 50, 184, 234, 223, 159, 253, 41, 198, 176, 244, 150, 187, 234, 180, 142, 247, 160, 36, 50, 55, 163, 194, 7, 36, 89, 204, 95, 5, 130, 91, 84, 85, 196, 200, 54, 140, 83, 74, 132, 19, 109, 170, 51, 41, 15, 202, 249, 90, 113, 11, 237, 93, 8, 33, 205, 62, 183, 101, 227, 199, 198, 243, 219, 211, 196, 227, 90 }, "Admin" });
        }
    }
}
