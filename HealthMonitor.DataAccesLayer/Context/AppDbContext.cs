using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.DataAccesLayer.Context;

public class AppDbContext: DbContext
{
    public DbSet<FoodEntity> Foods { get; set; }
    public DbSet<NotificationEntity> Notification { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=healthmonitor;Username=postgres;Password=postgres");
        }
    }
}