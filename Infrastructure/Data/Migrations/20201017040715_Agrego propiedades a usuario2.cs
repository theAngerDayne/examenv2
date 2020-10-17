using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Agregopropiedadesausuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "PasswordSalt", "UltimoAcceso", "Username" },
                values: new object[] { 100, "angel@duoc.cl", true, new byte[] { 178, 159, 174, 87, 158, 73, 196, 233, 239, 18, 94, 32, 248, 231, 154, 84, 225, 65, 204, 22, 192, 175, 96, 91, 218, 239, 216, 143, 152, 9, 145, 67, 2, 63, 64, 84, 130, 150, 16, 88, 0, 124, 200, 102, 36, 38, 149, 215, 84, 120, 199, 183, 33, 156, 18, 65, 95, 111, 33, 90, 206, 35, 200, 162 }, new byte[] { 122, 89, 167, 68, 130, 184, 2, 149, 33, 198, 63, 74, 49, 34, 88, 175, 243, 236, 192, 117, 248, 15, 2, 75, 119, 158, 170, 236, 161, 28, 184, 226, 179, 250, 153, 211, 91, 80, 81, 106, 45, 43, 90, 60, 209, 245, 226, 107, 104, 1, 96, 144, 241, 215, 56, 126, 29, 17, 94, 111, 20, 197, 82, 76, 54, 195, 38, 182, 249, 177, 235, 211, 27, 242, 156, 230, 185, 17, 155, 58, 159, 191, 144, 52, 81, 219, 201, 129, 239, 219, 93, 146, 87, 188, 63, 252, 95, 132, 68, 245, 169, 223, 167, 31, 254, 166, 193, 58, 108, 158, 136, 11, 84, 1, 2, 158, 117, 124, 24, 179, 6, 173, 174, 88, 178, 126, 220, 228 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angel" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "PasswordSalt", "UltimoAcceso", "Username" },
                values: new object[] { 101, "profe.moises@duoc.cl", true, new byte[] { 178, 159, 174, 87, 158, 73, 196, 233, 239, 18, 94, 32, 248, 231, 154, 84, 225, 65, 204, 22, 192, 175, 96, 91, 218, 239, 216, 143, 152, 9, 145, 67, 2, 63, 64, 84, 130, 150, 16, 88, 0, 124, 200, 102, 36, 38, 149, 215, 84, 120, 199, 183, 33, 156, 18, 65, 95, 111, 33, 90, 206, 35, 200, 162 }, new byte[] { 122, 89, 167, 68, 130, 184, 2, 149, 33, 198, 63, 74, 49, 34, 88, 175, 243, 236, 192, 117, 248, 15, 2, 75, 119, 158, 170, 236, 161, 28, 184, 226, 179, 250, 153, 211, 91, 80, 81, 106, 45, 43, 90, 60, 209, 245, 226, 107, 104, 1, 96, 144, 241, 215, 56, 126, 29, 17, 94, 111, 20, 197, 82, 76, 54, 195, 38, 182, 249, 177, 235, 211, 27, 242, 156, 230, 185, 17, 155, 58, 159, 191, 144, 52, 81, 219, 201, 129, 239, 219, 93, 146, 87, 188, 63, 252, 95, 132, 68, 245, 169, 223, 167, 31, 254, 166, 193, 58, 108, 158, 136, 11, 84, 1, 2, 158, 117, 124, 24, 179, 6, 173, 174, 88, 178, 126, 220, 228 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfeMoises" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "PasswordSalt", "UltimoAcceso", "Username" },
                values: new object[] { 1, "angel@duoc.cl", false, new byte[] { 229, 165, 53, 177, 179, 225, 131, 230, 30, 212, 240, 25, 137, 72, 44, 118, 56, 98, 120, 142, 175, 44, 132, 108, 110, 76, 105, 119, 28, 98, 104, 180, 81, 57, 223, 205, 157, 190, 181, 172, 182, 127, 141, 236, 7, 206, 191, 232, 157, 77, 70, 38, 87, 156, 249, 69, 84, 107, 253, 56, 139, 34, 24, 204 }, new byte[] { 171, 192, 38, 254, 36, 17, 18, 194, 187, 130, 77, 92, 41, 244, 51, 84, 67, 85, 114, 183, 230, 136, 108, 78, 148, 116, 46, 205, 231, 120, 169, 167, 106, 249, 109, 117, 84, 176, 59, 205, 165, 65, 34, 221, 38, 214, 179, 222, 18, 125, 71, 0, 61, 151, 14, 204, 179, 44, 178, 255, 6, 183, 86, 28, 242, 81, 123, 28, 228, 243, 64, 150, 210, 190, 92, 86, 81, 19, 78, 117, 131, 9, 202, 175, 72, 141, 172, 167, 88, 0, 249, 240, 176, 168, 117, 163, 171, 105, 56, 223, 164, 139, 208, 1, 41, 112, 170, 71, 49, 137, 196, 204, 114, 27, 108, 138, 167, 88, 29, 251, 225, 141, 45, 136, 212, 221, 170, 226 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angel" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsActive", "PasswordHash", "PasswordSalt", "UltimoAcceso", "Username" },
                values: new object[] { 2, "profe.moises@duoc.cl", false, new byte[] { 229, 165, 53, 177, 179, 225, 131, 230, 30, 212, 240, 25, 137, 72, 44, 118, 56, 98, 120, 142, 175, 44, 132, 108, 110, 76, 105, 119, 28, 98, 104, 180, 81, 57, 223, 205, 157, 190, 181, 172, 182, 127, 141, 236, 7, 206, 191, 232, 157, 77, 70, 38, 87, 156, 249, 69, 84, 107, 253, 56, 139, 34, 24, 204 }, new byte[] { 171, 192, 38, 254, 36, 17, 18, 194, 187, 130, 77, 92, 41, 244, 51, 84, 67, 85, 114, 183, 230, 136, 108, 78, 148, 116, 46, 205, 231, 120, 169, 167, 106, 249, 109, 117, 84, 176, 59, 205, 165, 65, 34, 221, 38, 214, 179, 222, 18, 125, 71, 0, 61, 151, 14, 204, 179, 44, 178, 255, 6, 183, 86, 28, 242, 81, 123, 28, 228, 243, 64, 150, 210, 190, 92, 86, 81, 19, 78, 117, 131, 9, 202, 175, 72, 141, 172, 167, 88, 0, 249, 240, 176, 168, 117, 163, 171, 105, 56, 223, 164, 139, 208, 1, 41, 112, 170, 71, 49, 137, 196, 204, 114, 27, 108, 138, 167, 88, 29, 251, 225, 141, 45, 136, 212, 221, 170, 226 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfeMoises" });
        }
    }
}
