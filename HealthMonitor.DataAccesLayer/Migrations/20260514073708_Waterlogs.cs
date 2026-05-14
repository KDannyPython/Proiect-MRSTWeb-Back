using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMonitor.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class Waterlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterLogEntity_Users_UserId",
                table: "WaterLogEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaterLogEntity",
                table: "WaterLogEntity");

            migrationBuilder.RenameTable(
                name: "WaterLogEntity",
                newName: "WaterLogs");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "WaterLogs",
                newName: "LoggedAt");

            migrationBuilder.RenameIndex(
                name: "IX_WaterLogEntity_UserId",
                table: "WaterLogs",
                newName: "IX_WaterLogs_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "AmountMl",
                table: "WaterLogs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaterLogs",
                table: "WaterLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterLogs_Users_UserId",
                table: "WaterLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterLogs_Users_UserId",
                table: "WaterLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaterLogs",
                table: "WaterLogs");

            migrationBuilder.RenameTable(
                name: "WaterLogs",
                newName: "WaterLogEntity");

            migrationBuilder.RenameColumn(
                name: "LoggedAt",
                table: "WaterLogEntity",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_WaterLogs_UserId",
                table: "WaterLogEntity",
                newName: "IX_WaterLogEntity_UserId");

            migrationBuilder.AlterColumn<double>(
                name: "AmountMl",
                table: "WaterLogEntity",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaterLogEntity",
                table: "WaterLogEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterLogEntity_Users_UserId",
                table: "WaterLogEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
