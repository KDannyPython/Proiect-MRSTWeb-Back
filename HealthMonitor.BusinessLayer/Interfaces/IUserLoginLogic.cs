using HealthMonitor.Domain.Entities.User;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IUserLoginLogic
    {
        public ServiceResponse UserLoginDataValidation(UserLoginDto udata);
        public UserEntity LoginUserAction(UserLoginDto udata);
        string UserTokenGeneration(UserEntity user);
    }
}
