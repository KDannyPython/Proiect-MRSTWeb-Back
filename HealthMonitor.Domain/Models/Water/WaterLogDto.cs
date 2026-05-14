using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.Water;

public class WaterLogDto
{
    [Required]
    public int AmountMl { get; set; }
}
