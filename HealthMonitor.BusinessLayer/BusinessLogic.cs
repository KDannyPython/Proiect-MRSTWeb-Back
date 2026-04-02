using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Core;

namespace HealthMonitor.BusinessLayer;

public class BusinessLogic
{
    public BusinessLogic() { }

    //FoodLogic
    public IFoodLogic GetFoodLogic()
    {
        return new FoodLogic();
    }

    // WorkoutLogic
    public IWorkoutLogic GetWorkoutLogic()
    {
        return new WorkoutLogic();
    }

    // ExerciseLogic
    public IExerciseLogic GetExerciseLogic()
    {
        return new ExerciseLogic();
    }

    // DailyRecordLogic
    public IDailyRecordLogic GetDailyRecordLogic()
    {
        return new DailyRecordLogic();
    }
    // UserLogic
    public IUserLogic GetUserLogic()
    {
        return new UserLogic();
    }

}
