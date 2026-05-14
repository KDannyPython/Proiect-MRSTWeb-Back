using HealthMonitor.Domain.Entities.Exercise;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.Exercise
{
    public class ExerciseCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        
        [Required]
        public MuscleGroup PrimaryMuscleGroup { get; set; }
        
        [MaxLength(200)]
        public string? SecondaryMuscleGroup { get; set; }
        
        [Required]
        public Difficulty Difficulty { get; set; }
        
        [Required]
        public FatigueCost FatigueCost { get; set; }
    }
}