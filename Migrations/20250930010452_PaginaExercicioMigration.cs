using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class PaginaExercicioMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_EXERCICIOS_TB_USUARIOS_UsuarioId",
                table: "TB_EXERCICIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PAGINAS_TB_USUARIOS_UsuarioId",
                table: "TB_PAGINAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_PAGINAS",
                table: "TB_PAGINAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_EXERCICIOS",
                table: "TB_EXERCICIOS");

            migrationBuilder.RenameTable(
                name: "TB_USUARIOS",
                newName: "tbl_usuario");

            migrationBuilder.RenameTable(
                name: "TB_PAGINAS",
                newName: "tbl_pagina");

            migrationBuilder.RenameTable(
                name: "TB_EXERCICIOS",
                newName: "tbl_exercicios");

            migrationBuilder.RenameIndex(
                name: "IX_TB_PAGINAS_UsuarioId",
                table: "tbl_pagina",
                newName: "IX_tbl_pagina_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_EXERCICIOS_UsuarioId",
                table: "tbl_exercicios",
                newName: "IX_tbl_exercicios_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "tbl_usuario",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "tbl_usuario",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: true,
                defaultValue: "Utilizador",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldDefaultValue: "Utilizador");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tbl_usuario",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "codDiarioUsuario",
                table: "tbl_usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "tituloPagina",
                table: "tbl_pagina",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "temaPagina",
                table: "tbl_pagina",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "contPagina",
                table: "tbl_pagina",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "tbl_exercicios",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "atividade",
                table: "tbl_exercicios",
                type: "varchar(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_usuario",
                table: "tbl_usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_pagina",
                table: "tbl_pagina",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_exercicios",
                table: "tbl_exercicios",
                column: "Id");

            migrationBuilder.InsertData(
                table: "tbl_exercicios",
                columns: new[] { "Id", "UsuarioId", "atividade", "dataTermino", "descricao", "quantidade", "relogio", "tempo" },
                values: new object[] { 1, 1, "Respiração", new DateTime(2025, 9, 29, 22, 9, 49, 543, DateTimeKind.Local).AddTicks(4472), "Eu adoro respirar", 1, 5.0, new TimeSpan(2999999995) });

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
                columns: new[] { "PasswordHash", "PasswordSalt", "codDiarioUsuario" },
                values: new object[] { new byte[] { 32, 19, 147, 196, 61, 63, 178, 69, 177, 126, 197, 247, 33, 53, 160, 65, 229, 125, 152, 208, 226, 168, 46, 105, 108, 185, 73, 236, 255, 53, 53, 148, 71, 182, 228, 32, 46, 140, 14, 188, 40, 86, 165, 22, 166, 89, 20, 65, 41, 231, 38, 175, 223, 143, 0, 128, 83, 171, 90, 52, 234, 147, 76, 38 }, new byte[] { 51, 39, 4, 123, 122, 95, 200, 193, 175, 50, 133, 219, 251, 253, 203, 170, 211, 8, 181, 57, 76, 231, 136, 12, 19, 18, 161, 58, 219, 167, 247, 171, 253, 199, 87, 252, 52, 153, 157, 242, 171, 228, 201, 137, 148, 213, 179, 117, 159, 73, 15, 21, 57, 37, 65, 68, 252, 145, 196, 209, 56, 50, 184, 234, 223, 159, 253, 41, 198, 176, 244, 150, 187, 234, 180, 142, 247, 160, 36, 50, 55, 163, 194, 7, 36, 89, 204, 95, 5, 130, 91, 84, 85, 196, 200, 54, 140, 83, 74, 132, 19, 109, 170, 51, 41, 15, 202, 249, 90, 113, 11, 237, 93, 8, 33, 205, 62, 183, 101, 227, 199, 198, 243, 219, 211, 196, 227, 90 }, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_exercicios_tbl_usuario_UsuarioId",
                table: "tbl_exercicios",
                column: "UsuarioId",
                principalTable: "tbl_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_pagina_tbl_usuario_UsuarioId",
                table: "tbl_pagina",
                column: "UsuarioId",
                principalTable: "tbl_usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_exercicios_tbl_usuario_UsuarioId",
                table: "tbl_exercicios");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_pagina_tbl_usuario_UsuarioId",
                table: "tbl_pagina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_usuario",
                table: "tbl_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_pagina",
                table: "tbl_pagina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_exercicios",
                table: "tbl_exercicios");

            migrationBuilder.DeleteData(
                table: "tbl_exercicios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "codDiarioUsuario",
                table: "tbl_usuario");

            migrationBuilder.RenameTable(
                name: "tbl_usuario",
                newName: "TB_USUARIOS");

            migrationBuilder.RenameTable(
                name: "tbl_pagina",
                newName: "TB_PAGINAS");

            migrationBuilder.RenameTable(
                name: "tbl_exercicios",
                newName: "TB_EXERCICIOS");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_pagina_UsuarioId",
                table: "TB_PAGINAS",
                newName: "IX_TB_PAGINAS_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_exercicios_UsuarioId",
                table: "TB_EXERCICIOS",
                newName: "IX_TB_EXERCICIOS_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "TB_USUARIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "TB_USUARIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "Utilizador",
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true,
                oldDefaultValue: "Utilizador");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TB_USUARIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tituloPagina",
                table: "TB_PAGINAS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "temaPagina",
                table: "TB_PAGINAS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "contPagina",
                table: "TB_PAGINAS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "TB_EXERCICIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "atividade",
                table: "TB_EXERCICIOS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USUARIOS",
                table: "TB_USUARIOS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_PAGINAS",
                table: "TB_PAGINAS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_EXERCICIOS",
                table: "TB_EXERCICIOS",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TB_PAGINAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCriacaoPagina",
                value: new DateTime(2025, 9, 8, 20, 34, 27, 824, DateTimeKind.Local).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 214, 109, 199, 212, 37, 107, 32, 230, 202, 242, 71, 58, 121, 188, 177, 101, 92, 231, 160, 69, 246, 155, 122, 116, 73, 81, 16, 231, 90, 252, 81, 10, 237, 254, 67, 88, 219, 57, 158, 34, 226, 145, 97, 227, 234, 131, 128, 227, 48, 161, 19, 244, 87, 91, 50, 29, 103, 49, 166, 192, 251, 228, 225, 180 }, new byte[] { 184, 156, 0, 13, 116, 0, 226, 195, 107, 168, 54, 214, 201, 148, 49, 182, 233, 2, 182, 174, 223, 145, 62, 84, 182, 10, 131, 250, 47, 176, 101, 78, 232, 141, 41, 196, 139, 218, 208, 181, 219, 1, 182, 202, 142, 97, 78, 17, 249, 134, 149, 211, 98, 182, 44, 121, 162, 36, 30, 140, 164, 100, 220, 87, 108, 60, 73, 128, 62, 19, 113, 220, 88, 138, 22, 253, 129, 106, 117, 15, 18, 108, 118, 88, 73, 100, 182, 147, 88, 77, 52, 191, 12, 131, 168, 31, 47, 151, 177, 123, 234, 45, 222, 0, 178, 47, 109, 83, 32, 126, 206, 63, 141, 210, 88, 217, 168, 148, 226, 229, 166, 182, 242, 130, 203, 107, 149, 5 } });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_EXERCICIOS_TB_USUARIOS_UsuarioId",
                table: "TB_EXERCICIOS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PAGINAS_TB_USUARIOS_UsuarioId",
                table: "TB_PAGINAS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }
    }
}
