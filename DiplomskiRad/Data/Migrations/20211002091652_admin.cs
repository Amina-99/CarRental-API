using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiRad.Data.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "RolaId", "UserName" },
                values: new object[] { 5, new byte[] { 44, 223, 8, 167, 193, 169, 251, 179, 58, 244, 105, 153, 223, 155, 183, 58, 192, 173, 100, 200, 252, 217, 242, 174, 187, 19, 41, 238, 76, 12, 183, 74, 211, 66, 62, 188, 57, 234, 98, 234, 152, 207, 218, 128, 247, 108, 85, 212, 198, 128, 44, 9, 225, 163, 71, 234, 204, 91, 247, 205, 117, 164, 24, 158 }, new byte[] { 224, 133, 211, 27, 116, 84, 91, 147, 149, 190, 180, 64, 124, 179, 245, 246, 186, 85, 28, 231, 161, 63, 191, 141, 6, 101, 83, 31, 96, 99, 235, 193, 114, 58, 104, 92, 103, 157, 133, 49, 43, 192, 188, 204, 158, 201, 77, 27, 63, 78, 133, 164, 123, 248, 42, 82, 188, 186, 237, 244, 199, 151, 74, 207, 215, 225, 240, 199, 115, 65, 6, 247, 219, 50, 138, 156, 10, 53, 28, 80, 92, 4, 203, 67, 207, 173, 244, 55, 108, 139, 21, 150, 23, 102, 99, 75, 62, 228, 114, 151, 114, 220, 242, 215, 150, 225, 165, 83, 236, 233, 223, 131, 171, 136, 15, 102, 36, 154, 148, 164, 249, 115, 60, 115, 187, 141, 142, 207 }, 1, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
