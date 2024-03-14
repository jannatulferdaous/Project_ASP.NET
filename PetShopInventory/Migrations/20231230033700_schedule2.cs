using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopInventory.Migrations
{
    /// <inheritdoc />
    public partial class schedule2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    petsname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mealsPerDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    morningTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noonTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eveningTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    foodItem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
