using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class TrainData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainTimeTableData",
                columns: table => new
                {
                    trainNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departureTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    haltTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dayCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    distance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    arrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainTimeTableData");
        }
    }
}
