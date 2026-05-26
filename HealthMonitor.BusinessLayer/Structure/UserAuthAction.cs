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
                var bl = new BusinessLogic();
                var adminLogic = bl.GetAdminLogic();
                var admin = adminLogic.LoginAdminAction(udata);

                if (admin != null)
                {
                    var adminToken = adminLogic.AdminTokenGeneration(admin);
                    return new ServiceResponse
                    {
                        IsSuccess = true,
                        Message = adminToken
                    };
                }

                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Invalid username or password."
                };
            }

            if (user.Id == -1)
            {
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "2FA_REQUIRED"
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

