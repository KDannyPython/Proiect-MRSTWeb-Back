using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMonitor.Domain.Entities.Workout
{
    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 480)] //8 ore (Rich Piana reference)
        public int Duration { get; set; }

        [Required]
        public WorkoutType Type { get; set; }

        [MaxLength(100)]
        public string? Label{ get; set; }

        [InverseProperty("Workout")]
        public ICollection<WorkoutExercise.WorkoutExercise> WorkoutExercises { get; set; } 
        = new List<WorkoutExercise.WorkoutExercise>();
    }
}