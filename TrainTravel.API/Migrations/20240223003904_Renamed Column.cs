using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class RenamedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "trainRunsOnWed2",
                table: "TrainInfoData",
                newName: "trainRunsOnWed");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnTue2",
                table: "TrainInfoData",
                newName: "trainRunsOnTue");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnThu2",
                table: "TrainInfoData",
                newName: "trainRunsOnThu");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnSun2",
                table: "TrainInfoData",
                newName: "trainRunsOnSun");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnSat2",
                table: "TrainInfoData",
                newName: "trainRunsOnSat");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnMon2",
                table: "TrainInfoData",
                newName: "trainRunsOnMon");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnFri2",
                table: "TrainInfoData",
                newName: "trainRunsOnFri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "trainRunsOnWed",
                table: "TrainInfoData",
                newName: "trainRunsOnWed2");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnTue",
                table: "TrainInfoData",
                newName: "trainRunsOnTue2");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnThu",
                table: "TrainInfoData",
                newName: "trainRunsOnThu2");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnSun",
                table: "TrainInfoData",
                newName: "trainRunsOnSun2");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnSat",
                table: "TrainInfoData",
                newName: "trainRunsOnSat2");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnMon",
                table: "TrainInfoData",
                newName: "trainRunsOnMon2");

            migrationBuilder.RenameColumn(
                name: "trainRunsOnFri",
                table: "TrainInfoData",
                newName: "trainRunsOnFri2");
        }
    }
}
