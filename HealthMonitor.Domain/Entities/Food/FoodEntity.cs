namespace HealthMonitor.Domain.Entities.Food
{
    public class FoodEntity
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
