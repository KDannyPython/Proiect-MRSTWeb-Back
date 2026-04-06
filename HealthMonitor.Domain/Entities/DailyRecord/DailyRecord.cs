using System;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Entities.DailyRecord

{
    public class DailyRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(0, 20000, ErrorMessage = "Aici nu poti avea valori negative.")]
        public int? CaloriesConsumed { get; set; }

        [Range(0, 20000)]
        public int? CaloriesGoal { get; set; }

        [Range(0, 300)]
        public int? Weight { get; set; }
        
        [Range(0, 8000)]
        public int? WaterConsumedMl { get; set; }

        [Range(0, 8000)]
        public int? WaterGoalMl { get; set; }

    }
}