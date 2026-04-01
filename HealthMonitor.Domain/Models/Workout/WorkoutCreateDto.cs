using System;
using System.Collections.Generic;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Models.WorkoutExercise;

namespace HealthMonitor.Domain.Models.Workout
{
    public class WorkoutCreateDto
    {
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public WorkoutType Type { get; set; }
        public string? Label { get; set; }

        public List<WorkoutExerciseCreateDto> WorkoutExercises { get; set; } = new List<WorkoutExerciseCreateDto>();
    }
}