using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowyAPI.Migrations
{
    /// <inheritdoc />
    public partial class ExercicioMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "TB_USUARIOS",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateTable(
                name: "TB_EXERCICIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atividade = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    dataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tempo = table.Column<TimeSpan>(type: "time", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    relogio = table.Column<double>(type: "float", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EXERCICIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_EXERCICIOS_TB_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_PAGINAS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UsuarioId", "dtCriacaoPagina" },
                values: new object[] { 1, new DateTime(2025, 9, 8, 20, 34, 27, 824, DateTimeKind.Local).AddTicks(2011) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 214, 109, 199, 212, 37, 107, 32, 230, 202, 242, 71, 58, 121, 188, 177, 101, 92, 231, 160, 69, 246, 155, 122, 116, 73, 81, 16, 231, 90, 252, 81, 10, 237, 254, 67, 88, 219, 57, 158, 34, 226, 145, 97, 227, 234, 131, 128, 227, 48, 161, 19, 244, 87, 91, 50, 29, 103, 49, 166, 192, 251, 228, 225, 180 }, new byte[] { 184, 156, 0, 13, 116, 0, 226, 195, 107, 168, 54, 214, 201, 148, 49, 182, 233, 2, 182, 174, 223, 145, 62, 84, 182, 10, 131, 250, 47, 176, 101, 78, 232, 141, 41, 196, 139, 218, 208, 181, 219, 1, 182, 202, 142, 97, 78, 17, 249, 134, 149, 211, 98, 182, 44, 121, 162, 36, 30, 140, 164, 100, 220, 87, 108, 60, 73, 128, 62, 19, 113, 220, 88, 138, 22, 253, 129, 106, 117, 15, 18, 108, 118, 88, 73, 100, 182, 147, 88, 77, 52, 191, 12, 131, 168, 31, 47, 151, 177, 123, 234, 45, 222, 0, 178, 47, 109, 83, 32, 126, 206, 63, 141, 210, 88, 217, 168, 148, 226, 229, 166, 182, 242, 130, 203, 107, 149, 5 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_EXERCICIOS_UsuarioId",
                table: "TB_EXERCICIOS",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_EXERCICIOS");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "TB_USUARIOS",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TB_PAGINAS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UsuarioId", "dtCriacaoPagina" },
                values: new object[] { null, new DateTime(2025, 8, 25, 19, 48, 25, 269, DateTimeKind.Local).AddTicks(311) });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 44, 119, 107, 95, 6, 137, 15, 189, 52, 165, 58, 36, 214, 72, 92, 206, 197, 135, 25, 113, 121, 39, 138, 53, 78, 87, 175, 236, 230, 130, 147, 20, 0, 220, 254, 114, 77, 148, 166, 169, 88, 68, 50, 109, 109, 214, 204, 128, 101, 183, 112, 147, 80, 0, 33, 75, 217, 76, 60, 4, 116, 102, 2, 177 }, new byte[] { 13, 142, 38, 16, 47, 3, 135, 131, 152, 4, 160, 245, 148, 157, 211, 49, 252, 203, 53, 210, 173, 224, 86, 222, 225, 109, 202, 189, 232, 24, 51, 250, 82, 55, 114, 3, 3, 155, 137, 151, 140, 196, 146, 251, 175, 22, 225, 106, 123, 26, 95, 248, 188, 134, 152, 121, 31, 164, 170, 224, 184, 212, 113, 67, 63, 36, 214, 185, 161, 252, 147, 176, 58, 101, 128, 105, 153, 18, 12, 95, 53, 191, 6, 113, 168, 52, 110, 36, 62, 252, 247, 105, 37, 49, 135, 17, 57, 36, 127, 26, 145, 112, 72, 84, 152, 81, 49, 212, 120, 215, 63, 233, 203, 25, 253, 17, 124, 59, 233, 103, 94, 71, 64, 107, 226, 196, 57, 242 } });
        }
    }
}
