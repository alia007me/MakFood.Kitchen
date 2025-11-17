using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Migrations
{
    /// <inheritdoc />
    public partial class DiscountCodeOneOneFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discounts_DiscountCodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discounts_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Discounts_DiscountCodeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId",
                unique: true,
                filter: "[DiscountCodeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Discounts_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }
    }
}
