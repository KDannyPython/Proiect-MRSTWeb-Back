namespace HealthMonitor.Domain.Models.Food
{
    public class FoodInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double VitaminC { get; set; }
    }
}
