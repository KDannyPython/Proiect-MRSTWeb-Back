namespace HealthMonitor.Domain.Models.Food
{
    public class FoodInfoDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public float calories { get; set; }
        public float protein { get; set; }
        public float carbohydrates { get; set; }
        public float fat { get; set; }
        public float fiber { get; set; }
        public float vitaminC { get; set; }
    }
}
