using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Entities.Workout
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(1, 480)] //8 ore (Rich Piana arm day reference xd)
        public int Duration { get; set; }

        [Required]
        public WorkoutType Type { get; set; }

        [MaxLength(100)]
        public string? Label{ get; set; }

        public List<WorkoutExercise.WorkoutExercise> WorkoutExercises { get; set; } =
        new List<WorkoutExercise.WorkoutExercise>();
    }
}