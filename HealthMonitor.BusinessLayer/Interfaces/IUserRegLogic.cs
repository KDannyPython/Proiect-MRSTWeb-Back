using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IUserRegLogic
    {
        public ServiceResponse UserRegDataValidation(RegisterDto uReg);
    }
}
