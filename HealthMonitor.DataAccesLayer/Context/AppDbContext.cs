using HealthMonitor.Domain.Entities.Admin;
using HealthMonitor.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.DataAccesLayer.Context;

public class AppDbContext: DbContext
{
    public DbSet<Admin> Admins { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=healthmonitor;Username=postgres;Password=postgres");
        }
    }
}
