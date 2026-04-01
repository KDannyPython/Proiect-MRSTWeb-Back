namespace HealthMonitor.Domain.Models.Food
{
    public class FoodCreateDto
    {
        public string Name { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbohydrates { get; set; }
        public float Fat { get; set; }
        public float Fiber { get; set; }
        public float VitaminC { get; set; }
    }
}
