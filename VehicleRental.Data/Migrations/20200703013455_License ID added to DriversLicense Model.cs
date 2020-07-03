using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRental.Data.Migrations
{
    public partial class LicenseIDaddedtoDriversLicenseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LicenseID",
                table: "DriverLicenses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseID",
                table: "DriverLicenses");
        }
    }
}
