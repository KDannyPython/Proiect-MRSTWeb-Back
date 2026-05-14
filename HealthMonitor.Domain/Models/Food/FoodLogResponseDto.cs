namespace HealthMonitor.Domain.Models.Food;

public class FoodLogResponseDto
{
    public int Id { get; set; }

    public int FoodId { get; set; }

    public string FoodName { get; set; } = null!;

    public float CaloriesPer100g { get; set; }

    public float ProteinPer100g { get; set; }

    public float CarbsPer100g { get; set; }

    public float FatPer100g { get; set; }

    public float FiberPer100g { get; set; }

    public float VitaminCPer100g { get; set; }

    public double QuantityGrams { get; set; }

    public DateTime LoggedAt { get; set; }
}
