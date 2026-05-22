using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Entities.User;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Core
{
    public class UserLogic : UserActions, IUserLogic
    {
        public ServiceResponse GetUserById(int id)
        {
            var user = GetUserByIdAction(id);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Utilizatorul nu a fost găsit în baza de date."
                };
            }

            return new ServiceResponse
            {
                IsSuccess = true,
                Data = user
            };
        }

        public ServiceResponse GetUserList()
        {
            var userList = GetUserListAction();
            return new ServiceResponse
            {
                IsSuccess = true,
                Data = userList
            };
        }

        public async Task UpdateMe(int userId, UpdateUserDto userDto)
        {
            var result = UpdateMeAction(userId, userDto);
        }

        public ServiceResponse UpdateUser(int id, UserCreateDto userDto)
        {
            var result = UpdateUserAction(id, userDto);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Utilizatorul nu a fost găsit sau a apărut o eroare la actualizare."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Informațiile utilizatorului au fost actualizate cu succes."
            };
        }

        public ServiceResponse DeleteUser(int id)
        {
            var result = DeleteUserAction(id);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Utilizatorul nu a putut fi șters sau nu a fost găsit."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Utilizatorul a fost șters cu succes din baza de date."
            };
        }

        public ServiceResponse ChangePassword(int userId, ChangePasswordDto password)
        {
            var result = ChangePasswordAction(userId, password);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Password change error."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Password changed succesfully."
            };
        }

        public ServiceResponse SendResetCode(ForgotPasswordDto request)
        {
            var result = SendResetCodeAction(request);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Reset code sending error."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Reset code sent succesfully."
            };
        }

        public ServiceResponse ResetPassword(ResetPasswordDto request)
        {
            var result = ResetPasswordAction(request);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Couldn't reset the password."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Password reset succesfully."
            };
        }

        public UserEntity? VerifyTwoFactor(VerifyTwoFactorDto request)
        {
            return VerifyTwoFactorAction(request);
        }
    }
}
