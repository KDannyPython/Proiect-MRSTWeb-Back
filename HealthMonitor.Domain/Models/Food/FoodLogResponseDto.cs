namespace HealthMonitor.Domain.Models.Food;

public class FoodLogResponseDto
{
    public int Id { get; set; }

    public int FoodId { get; set; }

    public string FoodName { get; set; } = null!;

    public double CaloriesPer100g { get; set; }

    public double ProteinPer100g { get; set; }

    public double CarbsPer100g { get; set; }

    public double FatPer100g { get; set; }

    public double FiberPer100g { get; set; }

    public double VitaminCPer100g { get; set; }

    public int QuantityGrams { get; set; }

    public DateTime LoggedAt { get; set; }
}
