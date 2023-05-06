using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WashingCarDBJosue.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseWithForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehiclesDetails_VehiculeId",
                table: "VehiclesDetails",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ServiceId",
                table: "Vehicles",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Services_ServiceId",
                table: "Vehicles",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesDetails_Vehicles_VehiculeId",
                table: "VehiclesDetails",
                column: "VehiculeId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Services_ServiceId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesDetails_Vehicles_VehiculeId",
                table: "VehiclesDetails");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesDetails_VehiculeId",
                table: "VehiclesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ServiceId",
                table: "Vehicles");
        }
    }
}
