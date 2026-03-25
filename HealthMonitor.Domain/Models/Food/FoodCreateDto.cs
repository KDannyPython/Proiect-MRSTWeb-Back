namespace HealthMonitor.Domain.Models.Food
{
    public class FoodCreateDto
    {
        public string name { get; set; }
        public float calories { get; set; }
        public float protein { get; set; }
        public float carbohydrates { get; set; }
    }
}
