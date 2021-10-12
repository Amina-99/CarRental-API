using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiRad.Data.Migrations
{
    public partial class addingPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Cars_CarId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Users_AppUserId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CarId",
                table: "Reservations",
                newName: "IX_Reservations_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_AppUserId",
                table: "Reservations",
                newName: "IX_Reservations_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarId",
                table: "Reservations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_AppUserId",
                table: "Reservations",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_AppUserId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CarId",
                table: "Reservation",
                newName: "IX_Reservation_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_AppUserId",
                table: "Reservation",
                newName: "IX_Reservation_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Cars_CarId",
                table: "Reservation",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Users_AppUserId",
                table: "Reservation",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
