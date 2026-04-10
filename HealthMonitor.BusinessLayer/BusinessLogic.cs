using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Core;

namespace HealthMonitor.BusinessLayer;

public class BusinessLogic
{
    public BusinessLogic() { }

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
