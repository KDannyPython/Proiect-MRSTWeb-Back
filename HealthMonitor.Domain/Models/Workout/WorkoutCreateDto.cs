using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HealthMonitor.Domain.Entities.Workout;
using HealthMonitor.Domain.Models.WorkoutExercise;

namespace HealthMonitor.Domain.Models.Workout
{
    public class WorkoutCreateDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 480)]
        public int Duration { get; set; }

        [Required]
        public WorkoutType Type { get; set; }
        [MaxLength(100)]
        public string? Label { get; set; }
        public List<WorkoutExerciseCreateDto> WorkoutExercises { get; set; } 
        = new List<WorkoutExerciseCreateDto>();
    }
}