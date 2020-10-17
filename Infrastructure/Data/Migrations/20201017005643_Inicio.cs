using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Rut = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TipoCuenta = table.Column<int>(nullable: false),
                    FechaApertura = table.Column<DateTime>(nullable: false),
                    SaldoInicial = table.Column<decimal>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    NombreUsuario = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cuentas_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 156, 147, 201, 119, 229, 165, 119, 219, 110, 128, 5, 59, 90, 44, 227, 196, 50, 138, 133, 159, 16, 145, 229, 117, 164, 121, 151, 92, 202, 15, 98, 200, 196, 66, 45, 160, 126, 51, 131, 118, 203, 133, 235, 195, 19, 87, 18, 88, 129, 53, 19, 87, 106, 72, 215, 89, 155, 164, 68, 227, 172, 28, 71, 131 }, new byte[] { 142, 75, 106, 131, 212, 137, 18, 135, 165, 133, 227, 193, 43, 8, 47, 54, 56, 120, 146, 199, 182, 128, 13, 76, 210, 163, 105, 37, 157, 32, 198, 250, 189, 118, 126, 129, 87, 50, 4, 215, 16, 160, 176, 187, 105, 247, 76, 196, 62, 99, 188, 7, 55, 203, 211, 160, 160, 133, 7, 201, 251, 69, 239, 223, 105, 202, 77, 147, 123, 91, 234, 154, 52, 106, 39, 251, 135, 27, 168, 86, 73, 176, 187, 204, 200, 190, 133, 47, 85, 255, 24, 172, 137, 149, 187, 41, 24, 145, 250, 48, 208, 86, 83, 226, 249, 85, 235, 215, 191, 15, 250, 167, 76, 193, 152, 250, 85, 14, 81, 196, 78, 187, 177, 129, 135, 7, 234, 15 }, "Angel" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, new byte[] { 156, 147, 201, 119, 229, 165, 119, 219, 110, 128, 5, 59, 90, 44, 227, 196, 50, 138, 133, 159, 16, 145, 229, 117, 164, 121, 151, 92, 202, 15, 98, 200, 196, 66, 45, 160, 126, 51, 131, 118, 203, 133, 235, 195, 19, 87, 18, 88, 129, 53, 19, 87, 106, 72, 215, 89, 155, 164, 68, 227, 172, 28, 71, 131 }, new byte[] { 142, 75, 106, 131, 212, 137, 18, 135, 165, 133, 227, 193, 43, 8, 47, 54, 56, 120, 146, 199, 182, 128, 13, 76, 210, 163, 105, 37, 157, 32, 198, 250, 189, 118, 126, 129, 87, 50, 4, 215, 16, 160, 176, 187, 105, 247, 76, 196, 62, 99, 188, 7, 55, 203, 211, 160, 160, 133, 7, 201, 251, 69, 239, 223, 105, 202, 77, 147, 123, 91, 234, 154, 52, 106, 39, 251, 135, 27, 168, 86, 73, 176, 187, 204, 200, 190, 133, 47, 85, 255, 24, 172, 137, 149, 187, 41, 24, 145, 250, 48, 208, 86, 83, 226, 249, 85, 235, 215, 191, 15, 250, 167, 76, 193, 152, 250, 85, 14, 81, 196, 78, 187, 177, 129, 135, 7, 234, 15 }, "ProfeMoises" });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ClienteId",
                table: "Cuentas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
