using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddProductNameToFoodRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "FoodRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "FoodRequests");
        }
    }
}
