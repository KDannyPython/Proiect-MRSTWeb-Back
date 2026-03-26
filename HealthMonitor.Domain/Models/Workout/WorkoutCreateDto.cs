using System;
using System.Collections.Generic;
using HealthMonitor.Domain.Models.Exercise;

namespace HealthMonitor.Domain.Models.Workout
{
    public class WorkoutCreateDto
    {
        public string UserId { get; set; } //asta nustiu
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Type { get; set; }
        public string Label{ get; set; }
        public int CaloriesBurned { get; set; } //asta as scoatem phd

        public List<ExerciseCreateDto> Exercises { get; set; } =
        new List<ExerciseCreateDto>();
    }
}