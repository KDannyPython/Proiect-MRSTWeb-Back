using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Structure
{
    public class UserAuthAction : UserActions, IUserLoginLogic
    {
        public UserAuthAction() { }

        public ServiceResponse UserLoginDataValidation(UserLoginDto udata)
        {
            var user = LoginUserAction(udata);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Invalid username or password."
                };
            }

            var token = UserTokenGeneration(user);
            
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = token
            };
        }
    }
}
