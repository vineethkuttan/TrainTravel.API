using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class TraininfoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainInfoData",
                columns: table => new
                {
                    trainRunsOnSun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainRunsOnMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainRunsOnTue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainRunsOnWed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainRunsOnThu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainRunsOnFri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainRunsOnSat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stationFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stationTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainInfoData");
        }
    }
}
