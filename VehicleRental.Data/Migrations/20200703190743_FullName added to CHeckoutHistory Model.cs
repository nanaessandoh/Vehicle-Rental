using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRental.Data.Migrations
{
    public partial class FullNameaddedtoCHeckoutHistoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "CheckoutHistories",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "CheckoutHistories");
        }
    }
}
