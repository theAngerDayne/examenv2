using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Listadecuentasausuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_User_UserId",
                table: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cuentas");

            migrationBuilder.AddColumn<int>(
                name: "CuentaId",
                table: "Cuentas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 188, 105, 74, 77, 217, 42, 14, 81, 71, 155, 9, 127, 35, 119, 242, 77, 195, 238, 129, 51, 35, 51, 184, 200, 144, 4, 129, 157, 17, 131, 172, 116, 23, 154, 83, 95, 94, 40, 254, 129, 215, 219, 64, 103, 4, 215, 63, 109, 184, 103, 31, 26, 15, 216, 225, 191, 46, 252, 210, 246, 255, 195, 226, 153 }, new byte[] { 76, 133, 21, 149, 178, 190, 218, 180, 227, 103, 71, 27, 200, 210, 37, 61, 87, 144, 21, 216, 224, 199, 238, 248, 202, 159, 146, 220, 159, 80, 136, 165, 123, 180, 43, 62, 156, 45, 127, 92, 56, 179, 143, 118, 215, 133, 228, 10, 85, 120, 200, 213, 25, 237, 164, 170, 198, 70, 164, 202, 245, 127, 22, 109, 211, 148, 211, 215, 143, 220, 241, 249, 101, 143, 207, 147, 131, 226, 71, 190, 151, 93, 31, 172, 90, 244, 240, 140, 233, 151, 92, 128, 95, 156, 139, 205, 192, 181, 142, 168, 224, 40, 245, 192, 67, 61, 60, 245, 195, 119, 178, 160, 190, 65, 31, 174, 143, 42, 166, 60, 249, 203, 30, 122, 77, 103, 49, 43 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 188, 105, 74, 77, 217, 42, 14, 81, 71, 155, 9, 127, 35, 119, 242, 77, 195, 238, 129, 51, 35, 51, 184, 200, 144, 4, 129, 157, 17, 131, 172, 116, 23, 154, 83, 95, 94, 40, 254, 129, 215, 219, 64, 103, 4, 215, 63, 109, 184, 103, 31, 26, 15, 216, 225, 191, 46, 252, 210, 246, 255, 195, 226, 153 }, new byte[] { 76, 133, 21, 149, 178, 190, 218, 180, 227, 103, 71, 27, 200, 210, 37, 61, 87, 144, 21, 216, 224, 199, 238, 248, 202, 159, 146, 220, 159, 80, 136, 165, 123, 180, 43, 62, 156, 45, 127, 92, 56, 179, 143, 118, 215, 133, 228, 10, 85, 120, 200, 213, 25, 237, 164, 170, 198, 70, 164, 202, 245, 127, 22, 109, 211, 148, 211, 215, 143, 220, 241, 249, 101, 143, 207, 147, 131, 226, 71, 190, 151, 93, 31, 172, 90, 244, 240, 140, 233, 151, 92, 128, 95, 156, 139, 205, 192, 181, 142, 168, 224, 40, 245, 192, 67, 61, 60, 245, 195, 119, 178, 160, 190, 65, 31, 174, 143, 42, 166, 60, 249, 203, 30, 122, 77, 103, 49, 43 } });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_CuentaId",
                table: "Cuentas",
                column: "CuentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Cuentas_CuentaId",
                table: "Cuentas",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Cuentas_CuentaId",
                table: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_CuentaId",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "CuentaId",
                table: "Cuentas");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cuentas",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 104, 38, 112, 172, 178, 20, 85, 58, 68, 5, 247, 67, 47, 199, 73, 61, 123, 186, 226, 9, 164, 106, 242, 196, 85, 166, 115, 18, 105, 152, 98, 103, 128, 167, 34, 214, 121, 82, 155, 158, 133, 224, 5, 222, 87, 117, 253, 38, 118, 137, 38, 197, 62, 214, 16, 186, 110, 16, 157, 169, 194, 47, 190, 76 }, new byte[] { 251, 135, 39, 38, 38, 147, 157, 228, 144, 52, 66, 193, 144, 111, 240, 119, 58, 77, 119, 127, 91, 21, 154, 71, 238, 106, 103, 33, 136, 145, 255, 172, 241, 180, 105, 13, 231, 78, 229, 76, 31, 190, 37, 252, 65, 39, 65, 242, 126, 133, 69, 222, 33, 178, 129, 70, 34, 247, 111, 103, 177, 249, 70, 159, 88, 235, 132, 129, 102, 205, 102, 113, 22, 167, 58, 7, 251, 186, 72, 142, 85, 100, 178, 108, 6, 195, 227, 13, 57, 235, 253, 200, 221, 0, 113, 232, 92, 129, 9, 185, 196, 142, 83, 129, 92, 192, 89, 142, 117, 125, 215, 69, 120, 74, 80, 208, 20, 86, 38, 140, 122, 77, 111, 83, 14, 170, 44, 145 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 104, 38, 112, 172, 178, 20, 85, 58, 68, 5, 247, 67, 47, 199, 73, 61, 123, 186, 226, 9, 164, 106, 242, 196, 85, 166, 115, 18, 105, 152, 98, 103, 128, 167, 34, 214, 121, 82, 155, 158, 133, 224, 5, 222, 87, 117, 253, 38, 118, 137, 38, 197, 62, 214, 16, 186, 110, 16, 157, 169, 194, 47, 190, 76 }, new byte[] { 251, 135, 39, 38, 38, 147, 157, 228, 144, 52, 66, 193, 144, 111, 240, 119, 58, 77, 119, 127, 91, 21, 154, 71, 238, 106, 103, 33, 136, 145, 255, 172, 241, 180, 105, 13, 231, 78, 229, 76, 31, 190, 37, 252, 65, 39, 65, 242, 126, 133, 69, 222, 33, 178, 129, 70, 34, 247, 111, 103, 177, 249, 70, 159, 88, 235, 132, 129, 102, 205, 102, 113, 22, 167, 58, 7, 251, 186, 72, 142, 85, 100, 178, 108, 6, 195, 227, 13, 57, 235, 253, 200, 221, 0, 113, 232, 92, 129, 9, 185, 196, 142, 83, 129, 92, 192, 89, 142, 117, 125, 215, 69, 120, 74, 80, 208, 20, 86, 38, 140, 122, 77, 111, 83, 14, 170, 44, 145 } });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_User_UserId",
                table: "Cuentas",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
