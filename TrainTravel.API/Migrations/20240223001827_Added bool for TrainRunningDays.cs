using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedboolforTrainRunningDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "trainRunsOnFri2",
                table: "TrainInfoData",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "trainRunsOnMon2",
                table: "TrainInfoData",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "trainRunsOnSat2",
                table: "TrainInfoData",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "trainRunsOnSun2",
                table: "TrainInfoData",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "trainRunsOnThu2",
                table: "TrainInfoData",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "trainRunsOnTue2",
                table: "TrainInfoData",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "trainRunsOnWed2",
                table: "TrainInfoData",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DepartureTime",
                table: "BookingsData",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "BookingsData",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trainRunsOnFri2",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnMon2",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnSat2",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnSun2",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnThu2",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnTue2",
                table: "TrainInfoData");

            migrationBuilder.DropColumn(
                name: "trainRunsOnWed2",
                table: "TrainInfoData");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureTime",
                table: "BookingsData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalTime",
                table: "BookingsData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
