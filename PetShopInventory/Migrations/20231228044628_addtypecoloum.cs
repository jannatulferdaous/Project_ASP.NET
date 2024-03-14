using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopInventory.Migrations
{
    /// <inheritdoc />
    public partial class addtypecoloum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Fish",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "cats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Fish");

            migrationBuilder.DropColumn(
                name: "type",
                table: "cats");
        }
    }
}
