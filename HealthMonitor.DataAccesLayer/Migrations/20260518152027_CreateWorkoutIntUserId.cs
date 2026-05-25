using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMonitor.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateWorkoutIntUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ștergem datele existente din Workouts ca să evităm erori de conversie
            migrationBuilder.Sql("DELETE FROM \"WorkoutExercises\";");
            migrationBuilder.Sql("DELETE FROM \"Workouts\";");

            // Convertim coloana UserId din varchar -> integer
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Workouts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Workouts",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
