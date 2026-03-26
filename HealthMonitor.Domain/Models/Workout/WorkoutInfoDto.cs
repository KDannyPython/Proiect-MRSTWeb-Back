using System;
using System.Collections.Generic;
using HealthMonitor.Domain.Models.Exercise;

namespace HealthMonitor.Domain.Models.Workout
{
    public class WorkoutInfoDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; }
        public string Label{ get; set; }
        public int CaloriesBurned { get; set; }

        public List<ExerciseInfoDto> Exercises { get; set; } =
         new List<ExerciseInfoDto>();
    }
}