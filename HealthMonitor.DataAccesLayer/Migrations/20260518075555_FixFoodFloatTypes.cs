using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMonitor.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixFoodFloatTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "VitaminC",
                table: "Foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Protein",
                table: "Foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Fiber",
                table: "Foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Fat",
                table: "Foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Carbohydrates",
                table: "Foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Calories",
                table: "Foods",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityGrams",
                table: "FoodLogs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "VitaminC",
                table: "Foods",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "Protein",
                table: "Foods",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "Fiber",
                table: "Foods",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "Fat",
                table: "Foods",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "Carbohydrates",
                table: "Foods",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<float>(
                name: "Calories",
                table: "Foods",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "QuantityGrams",
                table: "FoodLogs",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
