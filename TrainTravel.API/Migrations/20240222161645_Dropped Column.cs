using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class DroppedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "arrivalTime",
                table: "TrainTimeTableData");

            migrationBuilder.DropColumn(
                name: "departureTime",
                table: "TrainTimeTableData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "arrivalTime",
                table: "TrainTimeTableData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "departureTime",
                table: "TrainTimeTableData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
