using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainTravel.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_TrainTimeTableData_TrainInfoData_trainNumber",
                table: "TrainTimeTableData",
                column: "trainNumber",
                principalTable: "TrainInfoData",
                principalColumn: "trainNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainTimeTableData_TrainInfoData_trainNumber",
                table: "TrainTimeTableData");
        }
    }
}
