using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Entities.DailyRecord;
using HealthMonitor.Domain.Entities.WorkoutExercise;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.DataAccesLayer.Context;

public class AppDbContext: DbContext
{
    public DbSet<FoodEntity> Foods { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<DailyRecord> DailyRecords { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=healthmonitor;Username=postgres;Password=postgres");
        }
    }
}
