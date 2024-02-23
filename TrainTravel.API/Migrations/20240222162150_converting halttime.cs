using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class convertinghalttime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "haltTime2",
                table: "TrainTimeTableData",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "haltTime2",
                table: "TrainTimeTableData");
        }
    }
}
