using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnwanteddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trainRunsOnFri",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnMon",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnSat",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnSun",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnThu",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnTue",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnWed",
                table: "TrainInfoData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "trainRunsOnFri",
                table: "TrainInfoData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trainRunsOnMon",
                table: "TrainInfoData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trainRunsOnSat",
                table: "TrainInfoData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trainRunsOnSun",
                table: "TrainInfoData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trainRunsOnThu",
                table: "TrainInfoData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trainRunsOnTue",
                table: "TrainInfoData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trainRunsOnWed",
                table: "TrainInfoData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
