namespace HealthMonitor.Domain.Entities.Exercise
{
    public class Exercise
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }

        public Workout.Workout Workout { get; set; }
    }
}
    