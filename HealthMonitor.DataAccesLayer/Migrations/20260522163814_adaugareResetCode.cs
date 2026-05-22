using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMonitor.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class adaugareResetCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordCode",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordCode",
                table: "Users");
        }
    }
}
