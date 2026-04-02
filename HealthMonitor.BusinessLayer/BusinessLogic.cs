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

    //NotificationLogic
    public INotificationLogic GetNotificationLogic()
    {
        return new NotificationLogic();
    }
}
