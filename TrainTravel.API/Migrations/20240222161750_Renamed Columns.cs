using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class RenamedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "departureTime2",
                table: "TrainTimeTableData",
                newName: "departureTime");

            migrationBuilder.RenameColumn(
                name: "arrivalTime2",
                table: "TrainTimeTableData",
                newName: "arrivalTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "departureTime",
                table: "TrainTimeTableData",
                newName: "departureTime2");

            migrationBuilder.RenameColumn(
                name: "arrivalTime",
                table: "TrainTimeTableData",
                newName: "arrivalTime2");
        }
    }
}
