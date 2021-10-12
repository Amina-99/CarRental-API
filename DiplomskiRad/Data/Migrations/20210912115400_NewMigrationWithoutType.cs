using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomskiRad.Data.Migrations
{
    public partial class NewMigrationWithoutType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Type_TypeId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TypeId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeId",
                table: "Cars",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Type_TypeId",
                table: "Cars",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
