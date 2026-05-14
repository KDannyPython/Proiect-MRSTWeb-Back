using HealthMonitor.Domain.Entities.Exercise;

namespace HealthMonitor.Domain.Models.Exercise
{
    public class ExerciseCreateDto
    {
        public string Name { get; set; }
        public MuscleGroup PrimaryMuscleGroup { get; set; }
        public string? SecondaryMuscleGroup { get; set; }
        public Difficulty Difficulty { get; set; }
        public FatigueCost FatigueCost { get; set; }
    }
}