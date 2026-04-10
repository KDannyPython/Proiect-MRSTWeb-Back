using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMonitor.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class EntityTraitsChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "vitaminC",
                table: "Foods",
                newName: "VitaminC");

            migrationBuilder.RenameColumn(
                name: "protein",
                table: "Foods",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Foods",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "fiber",
                table: "Foods",
                newName: "Fiber");

            migrationBuilder.RenameColumn(
                name: "fat",
                table: "Foods",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "carbohydrates",
                table: "Foods",
                newName: "Carbohydrates");

            migrationBuilder.RenameColumn(
                name: "calories",
                table: "Foods",
                newName: "Calories");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Foods",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VitaminC",
                table: "Foods",
                newName: "vitaminC");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "Foods",
                newName: "protein");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Foods",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Fiber",
                table: "Foods",
                newName: "fiber");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "Foods",
                newName: "fat");

            migrationBuilder.RenameColumn(
                name: "Carbohydrates",
                table: "Foods",
                newName: "carbohydrates");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "Foods",
                newName: "calories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Foods",
                newName: "id");
        }
    }
}
