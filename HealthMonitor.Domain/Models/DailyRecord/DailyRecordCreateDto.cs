using System;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.DailyRecord
{
    public class DailyRecordCreateDto
    {
        public DateTime Date { get; set; }

        [Range(0, 20000, ErrorMessage = "Aici nu poti avea valori negative.")]
        public int? CaloriesConsumed { get; set; }
        
        public int? CaloriesGoal { get; set; }
        public int? Weight { get; set; }
        public int? WaterConsumedMl { get; set; } 
        public int? WaterGoalMl { get; set; }   
    }
}
