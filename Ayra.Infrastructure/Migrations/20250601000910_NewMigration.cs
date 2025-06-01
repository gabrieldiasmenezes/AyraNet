using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ayra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Coordinates_CoordinatesId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_MapMarkers_Coordinates_CoordinatesId",
                table: "MapMarkers");

            migrationBuilder.RenameColumn(
                name: "CoordinatesId",
                table: "MapMarkers",
                newName: "CoordinateId");

            migrationBuilder.RenameIndex(
                name: "IX_MapMarkers_CoordinatesId",
                table: "MapMarkers",
                newName: "IX_MapMarkers_CoordinateId");

            migrationBuilder.RenameColumn(
                name: "CoordinatesId",
                table: "Alerts",
                newName: "CoordinateId");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_CoordinatesId",
                table: "Alerts",
                newName: "IX_Alerts_CoordinateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Coordinates_CoordinateId",
                table: "Alerts",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapMarkers_Coordinates_CoordinateId",
                table: "MapMarkers",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Coordinates_CoordinateId",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_MapMarkers_Coordinates_CoordinateId",
                table: "MapMarkers");

            migrationBuilder.RenameColumn(
                name: "CoordinateId",
                table: "MapMarkers",
                newName: "CoordinatesId");

            migrationBuilder.RenameIndex(
                name: "IX_MapMarkers_CoordinateId",
                table: "MapMarkers",
                newName: "IX_MapMarkers_CoordinatesId");

            migrationBuilder.RenameColumn(
                name: "CoordinateId",
                table: "Alerts",
                newName: "CoordinatesId");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_CoordinateId",
                table: "Alerts",
                newName: "IX_Alerts_CoordinatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Coordinates_CoordinatesId",
                table: "Alerts",
                column: "CoordinatesId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapMarkers_Coordinates_CoordinatesId",
                table: "MapMarkers",
                column: "CoordinatesId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
