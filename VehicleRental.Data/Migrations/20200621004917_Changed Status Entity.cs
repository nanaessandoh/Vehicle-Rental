using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRental.Data.Migrations
{
    public partial class ChangedStatusEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehicleRentalAssets_StatusId",
                table: "VehicleRentalAssets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleRentalAssets_Statuses_StatusId",
                table: "VehicleRentalAssets",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleRentalAssets_Statuses_StatusId",
                table: "VehicleRentalAssets");

            migrationBuilder.DropIndex(
                name: "IX_VehicleRentalAssets_StatusId",
                table: "VehicleRentalAssets");
        }
    }
}
