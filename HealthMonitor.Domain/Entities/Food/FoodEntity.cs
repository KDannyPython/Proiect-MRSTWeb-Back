namespace HealthMonitor.Domain.Entities.Food
{
    public class FoodEntity
    {
        public int Id { get; set; }
        public int FdcId { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double VitaminC { get; set; }
        public ICollection<FoodLogEntity> FoodLogs { get; set; }
        = new List<FoodLogEntity>();
    }
}
