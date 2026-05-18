namespace HealthMonitor.Domain.Models.Calendar;

using HealthMonitor.Domain.Models.Workout;

public class CalendarDayDetailsDto
{
    public int Calories { get; set; }
    public int CalGoal { get; set; }

    public int WaterMl { get; set; }
    public int WaterGoal { get; set; }

    public List<WorkoutInfoDto> Workouts { get; set; } = null!;
}
