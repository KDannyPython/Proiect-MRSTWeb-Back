using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Entities.WorkoutExercise;
using HealthMonitor.Domain.Entities.Admin;
using HealthMonitor.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using HealthMonitor.Domain.Entities.Water;
using Microsoft.Extensions.Configuration;

namespace HealthMonitor.DataAccesLayer.Context;

public class AppDbContext: DbContext
{
    public DbSet<FoodEntity> Foods { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<FoodLogEntity> FoodLogs { get; set; }
    public DbSet<WaterLogEntity> WaterLogs { get; set; }
    public DbSet<WeightLogEntity> WeightLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString =
                configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}