using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IUserLoginLogic
    {
        public ServiceResponse UserLoginDataValidation(UserLoginDto udata);
    }
}
