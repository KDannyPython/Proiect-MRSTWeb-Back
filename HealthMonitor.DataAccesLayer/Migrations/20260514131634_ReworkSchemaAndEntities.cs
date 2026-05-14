using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HealthMonitor.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class ReworkSchemaAndEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyRecords");

            migrationBuilder.DropColumn(
                name: "MuscleTarget",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FatigueCost",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryMuscleGroup",
                table: "Exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryMuscleGroup",
                table: "Exercises",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "FatigueCost",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "PrimaryMuscleGroup",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "SecondaryMuscleGroup",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "MuscleTarget",
                table: "Exercises",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DailyRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CaloriesConsumed = table.Column<int>(type: "integer", nullable: true),
                    CaloriesGoal = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    WaterConsumedMl = table.Column<int>(type: "integer", nullable: true),
                    WaterGoalMl = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRecords", x => x.Id);
                });
        }
    }
}
