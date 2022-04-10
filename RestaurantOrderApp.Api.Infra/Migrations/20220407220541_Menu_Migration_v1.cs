using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantOrderApp.Api.Infra.Migrations
{
    public partial class Menu_Migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishType = table.Column<int>(type: "int", nullable: false),
                    TimeOfDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "DishType", "Meal", "TimeOfDay" },
                values: new object[,]
                {
                    { 1, 1, "eggs", "morning" },
                    { 2, 2, "toast", "morning" },
                    { 3, 3, "coffee", "morning" },
                    { 4, 4, "Not Applicable", "morning" },
                    { 5, 1, "steak", "night" },
                    { 6, 2, "potato", "night" },
                    { 7, 3, "wine", "night" },
                    { 8, 4, "cake", "night" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
