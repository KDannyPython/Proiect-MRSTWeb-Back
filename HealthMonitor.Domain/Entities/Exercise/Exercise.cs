using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMonitor.Domain.Entities.Exercise
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public MuscleGroup PrimaryMuscleGroup { get; set; }

        [MaxLength(100)]
        public string? SecondaryMuscleGroup { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; }

        [Required]
        public FatigueCost FatigueCost { get; set; }
        
        [InverseProperty("Exercise")]
        public ICollection<WorkoutExercise.WorkoutExercise> WorkoutExercises { get; set; } 
        = new List<WorkoutExercise.WorkoutExercise>();
    }
}
    