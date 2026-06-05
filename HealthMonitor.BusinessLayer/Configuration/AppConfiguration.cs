namespace HealthMonitor.BusinessLayer.Configuration;
using Microsoft.Extensions.Configuration;

public static class AppConfiguration
{
    public static IConfiguration Configuration { get; set; } = null!;
}
