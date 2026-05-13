namespace HealthMonitor.Domain.Entities.Food
{
    public class FoodEntity
    {
        public int Id { get; set; }
        public int FdcId { get; set; }
        public string Name { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbohydrates { get; set; }
        public float Fat { get; set; }
        public float Fiber { get; set; }
        public float VitaminC { get; set; }
        public ICollection<FoodLogEntity> FoodLogs { get; set; }
        = new List<FoodLogEntity>();
    }
}
