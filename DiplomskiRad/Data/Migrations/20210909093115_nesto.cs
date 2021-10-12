using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiRad.Data.Migrations
{
    public partial class nesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Type_TypeId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Car_CarId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_Car_TypeId",
                table: "Cars",
                newName: "IX_Cars_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Type_TypeId",
                table: "Cars",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Cars_CarId",
                table: "Reservation",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Type_TypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Cars_CarId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Car");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_TypeId",
                table: "Car",
                newName: "IX_Car_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Type_TypeId",
                table: "Car",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Car_CarId",
                table: "Reservation",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
