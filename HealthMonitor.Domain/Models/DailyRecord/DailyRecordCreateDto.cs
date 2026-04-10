using System;

namespace HealthMonitor.Domain.Models.DailyRecord
{
    public class DailyRecordCreateDto
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int CaloriesBurned { get; set; }
        public int CaloriesConsumed { get; set; }
        public int CaloriesGoal { get; set; }
        public int Weight { get; set; }
        public int WaterConsumedMl { get; set; } 
        public int WaterGoalMl { get; set; }   
    }
}
