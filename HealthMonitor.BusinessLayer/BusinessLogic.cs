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

    public IFoodLogLogic GetFoodLogLogic()
    {
        return new FoodLogLogic();
    }

    public IWaterLogLogic GetWaterLogLogic()
    {
        return new WaterLogLogic();
    }

    public ICalendarLogic GetCalendarLogic()
    {
        return new CalendarLogic();
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

    // UserLoginLogic
    public IUserLoginLogic GetUserLoginLogic()
    {
        return new UserAuthAction();
    }
    // UserRegLogic
    public IUserRegLogic GetUserRegLogic()
    {
        return new UserRegLogic();
    }
    // UserLogic
    public IUserLogic GetUserLogic()
    {
        return new UserLogic();
    }
    // AdminLogic
    public IAdminLogic GetAdminLogic()
    {
        return new AdminLogic();
    }

}
