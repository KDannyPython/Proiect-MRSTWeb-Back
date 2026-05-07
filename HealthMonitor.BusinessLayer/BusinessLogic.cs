using HealthMonitor.BusinessLayer.Core;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;

namespace HealthMonitor.BusinessLayer;

public class BusinessLogic
{
    public BusinessLogic() { }

    //FoodLogic
    public IFoodLogic GetFoodLogic()
    {
        return new FoodLogic();
    }

    //NotificationLogic
    public INotificationLogic GetNotificationLogic()
    {
        return new NotificationLogic();
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
    // UserLoginLogic
    public IUserLoginLogic GetUserLogic()
    {
        return new UserAuthAction();
    }
    // UserRegLogic
    public IUserRegLogic GetUserRegLogic()
    {
        return new UserRegLogic();
    }
    // AdminLogic
    public IAdminLogic GetAdminLogic()
    {
        return new AdminLogic();
    }

}
