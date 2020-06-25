using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRental.Data.Migrations
{
    public partial class DriverLicenseRemovedfromHold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holds_DriverLicenses_DriverLicenseId",
                table: "Holds");

            migrationBuilder.DropIndex(
                name: "IX_Holds_DriverLicenseId",
                table: "Holds");

            migrationBuilder.DropColumn(
                name: "DriverLicenseId",
                table: "Holds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverLicenseId",
                table: "Holds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holds_DriverLicenseId",
                table: "Holds",
                column: "DriverLicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holds_DriverLicenses_DriverLicenseId",
                table: "Holds",
                column: "DriverLicenseId",
                principalTable: "DriverLicenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
