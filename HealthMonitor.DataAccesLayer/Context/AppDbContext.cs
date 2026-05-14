using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Entities.Notification;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Entities.Exercise;
using HealthMonitor.Domain.Entities.WorkoutExercise;
using HealthMonitor.Domain.Entities.Admin;
using HealthMonitor.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using HealthMonitor.Domain.Entities.Water;

namespace HealthMonitor.DataAccesLayer.Context;

public class AppDbContext: DbContext
{
    public DbSet<FoodEntity> Foods { get; set; }
    public DbSet<NotificationEntity> Notification { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<FoodLogEntity> FoodLogs { get; set; }
    public DbSet<WaterLogEntity> WaterLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=healthmonitor;Username=postgres;Password=postgres");
        }
    }
}