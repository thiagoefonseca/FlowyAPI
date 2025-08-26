using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_PAGINAS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, defaultValue: "Utilizador"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_PAGINAS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UsuarioId", "dtCriacaoPagina" },
                values: new object[] { null, new DateTime(2025, 8, 25, 19, 48, 25, 269, DateTimeKind.Local).AddTicks(311) });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "thiagoefonseca2007@gmail.com", new byte[] { 44, 119, 107, 95, 6, 137, 15, 189, 52, 165, 58, 36, 214, 72, 92, 206, 197, 135, 25, 113, 121, 39, 138, 53, 78, 87, 175, 236, 230, 130, 147, 20, 0, 220, 254, 114, 77, 148, 166, 169, 88, 68, 50, 109, 109, 214, 204, 128, 101, 183, 112, 147, 80, 0, 33, 75, 217, 76, 60, 4, 116, 102, 2, 177 }, new byte[] { 13, 142, 38, 16, 47, 3, 135, 131, 152, 4, 160, 245, 148, 157, 211, 49, 252, 203, 53, 210, 173, 224, 86, 222, 225, 109, 202, 189, 232, 24, 51, 250, 82, 55, 114, 3, 3, 155, 137, 151, 140, 196, 146, 251, 175, 22, 225, 106, 123, 26, 95, 248, 188, 134, 152, 121, 31, 164, 170, 224, 184, 212, 113, 67, 63, 36, 214, 185, 161, 252, 147, 176, 58, 101, 128, 105, 153, 18, 12, 95, 53, 191, 6, 113, 168, 52, 110, 36, 62, 252, 247, 105, 37, 49, 135, 17, 57, 36, 127, 26, 145, 112, 72, 84, 152, 81, 49, 212, 120, 215, 63, 233, 203, 25, 253, 17, 124, 59, 233, 103, 94, 71, 64, 107, 226, 196, 57, 242 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PAGINAS_UsuarioId",
                table: "TB_PAGINAS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PAGINAS_TB_USUARIOS_UsuarioId",
                table: "TB_PAGINAS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PAGINAS_TB_USUARIOS_UsuarioId",
                table: "TB_PAGINAS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PAGINAS_UsuarioId",
                table: "TB_PAGINAS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_PAGINAS");

            migrationBuilder.UpdateData(
                table: "TB_PAGINAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCriacaoPagina",
                value: new DateTime(2025, 6, 25, 19, 44, 3, 449, DateTimeKind.Local).AddTicks(2754));
        }
    }
}
