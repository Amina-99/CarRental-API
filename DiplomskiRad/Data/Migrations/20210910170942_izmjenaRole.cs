using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiRad.Data.Migrations
{
    public partial class izmjenaRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.AddColumn<int>(
                name: "RolaId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolaId",
                table: "Users",
                column: "RolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RolaId",
                table: "Users",
                column: "RolaId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RolaId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    AppUsersId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => new { x.AppUsersId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_AppUserRole_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRole_Users_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RolesId",
                table: "AppUserRole",
                column: "RolesId");
        }
    }
}
