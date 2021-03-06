using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiRad.Data.Migrations
{
    public partial class removeprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 122, 45, 53, 122, 126, 204, 144, 38, 227, 99, 25, 127, 68, 191, 223, 39, 236, 117, 181, 142, 186, 197, 203, 58, 119, 163, 254, 12, 188, 133, 227, 239, 107, 160, 100, 177, 59, 131, 17, 102, 220, 178, 184, 105, 98, 150, 158, 209, 162, 125, 1, 10, 69, 184, 91, 173, 226, 118, 246, 254, 233, 139, 195 }, new byte[] { 172, 12, 169, 188, 220, 216, 193, 105, 167, 223, 219, 7, 91, 186, 161, 215, 132, 244, 212, 232, 138, 61, 219, 202, 163, 12, 181, 107, 17, 153, 94, 40, 232, 141, 163, 229, 60, 139, 133, 58, 125, 152, 142, 86, 50, 168, 69, 9, 56, 198, 228, 225, 109, 239, 151, 66, 88, 203, 19, 76, 132, 204, 10, 137, 118, 0, 12, 210, 126, 15, 75, 55, 121, 251, 154, 25, 71, 166, 68, 225, 86, 13, 93, 211, 151, 10, 109, 30, 152, 61, 241, 141, 213, 67, 116, 251, 128, 163, 240, 7, 1, 223, 182, 123, 60, 189, 123, 65, 179, 252, 61, 184, 81, 131, 238, 9, 199, 150, 222, 72, 91, 150, 249, 2, 20, 86, 0, 211 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricePerDay",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 44, 223, 8, 167, 193, 169, 251, 179, 58, 244, 105, 153, 223, 155, 183, 58, 192, 173, 100, 200, 252, 217, 242, 174, 187, 19, 41, 238, 76, 12, 183, 74, 211, 66, 62, 188, 57, 234, 98, 234, 152, 207, 218, 128, 247, 108, 85, 212, 198, 128, 44, 9, 225, 163, 71, 234, 204, 91, 247, 205, 117, 164, 24, 158 }, new byte[] { 224, 133, 211, 27, 116, 84, 91, 147, 149, 190, 180, 64, 124, 179, 245, 246, 186, 85, 28, 231, 161, 63, 191, 141, 6, 101, 83, 31, 96, 99, 235, 193, 114, 58, 104, 92, 103, 157, 133, 49, 43, 192, 188, 204, 158, 201, 77, 27, 63, 78, 133, 164, 123, 248, 42, 82, 188, 186, 237, 244, 199, 151, 74, 207, 215, 225, 240, 199, 115, 65, 6, 247, 219, 50, 138, 156, 10, 53, 28, 80, 92, 4, 203, 67, 207, 173, 244, 55, 108, 139, 21, 150, 23, 102, 99, 75, 62, 228, 114, 151, 114, 220, 242, 215, 150, 225, 165, 83, 236, 233, 223, 131, 171, 136, 15, 102, 36, 154, 148, 164, 249, 115, 60, 115, 187, 141, 142, 207 } });
        }
    }
}
