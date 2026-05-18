using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.Food;

public class FoodLogUpdateDto
{
    [Required]
    public int QuantityGrams { get; set; }
}