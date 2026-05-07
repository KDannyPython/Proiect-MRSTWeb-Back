using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;

namespace HealthMonitor.BusinessLayer.Core
{
    public class UserRegLogic : UserActions, IUserRegLogic
    {
        public ServiceResponse UserRegDataValidation(UserCreateDto uReg)
        {
            return RegisterUserAction(uReg);
        }
    }
}
