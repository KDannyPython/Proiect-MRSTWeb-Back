using System;
using System.Collections.Generic;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Models.WorkoutExercise;

namespace HealthMonitor.Domain.Models.Workout
{
    public class WorkoutInfoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public WorkoutType Type { get; set; }
        public string? Label{ get; set; }

        public List<WorkoutExerciseInfoDto> WorkoutExercises { get; set; } 
        = new List<WorkoutExerciseInfoDto>();
    }
}