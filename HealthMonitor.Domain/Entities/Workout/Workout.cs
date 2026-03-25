using System;
using System.Collections.Generic;

namespace HealthMonitor.Domain.Entities.Workout
{
    public class Workout
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; }
        public string Label{ get; set; }
        public int CaloriesBurned { get; set; }

        public List<Exercise.Exercise> Exercises { get; set; } =
        new List<Exercise.Exercise>();
    }
}