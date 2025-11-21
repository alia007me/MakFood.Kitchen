using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakFood.Kitchen.Infrastructure.Persistence.Context.Migrations
{
    /// <inheritdoc />
    public partial class delete_state_from_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "OwnerPaymentStatus",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartnerPaymentStatus",
                table: "Payments",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerPaymentStatus",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PartnerPaymentStatus",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
