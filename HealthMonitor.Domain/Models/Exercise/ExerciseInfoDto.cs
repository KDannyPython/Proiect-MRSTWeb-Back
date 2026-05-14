using HealthMonitor.Domain.Entities.Exercise;

namespace HealthMonitor.Domain.Models.Exercise
{
    public class ExerciseInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public MuscleGroup PrimaryMuscleGroup { get; set; }
        public string? SecondaryMuscleGroup { get; set; }
        public Difficulty Difficulty { get; set; }
        public FatigueCost FatigueCost { get; set; }
    }
}
