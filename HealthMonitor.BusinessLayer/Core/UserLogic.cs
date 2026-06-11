using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Entities.User;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;
using Org.BouncyCastle.Asn1.Ocsp;

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
                    Message = "User not found."
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
                    Message = "User not found or an error occurred while updating."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "User information updated successfully."
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
                    Message = "User could not be deleted or was not found."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "User deleted successfully."
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
                Message = "Password changed successfully."
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
                Message = "Reset code sent successfully."
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
                Message = "Password reset successfully."
            };
        }

        public ServiceResponse ResetUserData(int userId)
        {
            return ResetUserDataAction(userId);
        }

        public UserEntity? VerifyTwoFactor(VerifyTwoFactorDto request)
        {
            return VerifyTwoFactorAction(request);
        }

        public ServiceResponse SendDeleteVerificationCode(int userId)
        {
            var result = SendDeleteVerificationCodeAction(userId);
            if (result == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Couldn't generate or send the email."
                };
            }
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Code generated and sent successfully."
            };
        }

        public string GetUserEmailByCredential(string credential)
        {
            return GetUserEmailByCredentialAction(credential);
        }

        public ServiceResponse CompleteOnboarding(int userId, OnboardingDto dto)
        {
            return CompleteOnboardingAction(userId, dto);
        }

        public ServiceResponse SetUserRole(int userId, string role)
        {
            if (!Enum.TryParse<UserRole>(role, ignoreCase: true, out var parsedRole))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Invalid role: '{role}'. Accepted values: User, Admin."
                };
            }

            return SetUserRoleAction(userId, parsedRole);
        }
    }
}
