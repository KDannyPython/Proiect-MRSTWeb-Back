using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.Food;

public class FoodLogUpdateDto
{
    [Required]
    public double QuantityGrams { get; set; }
}