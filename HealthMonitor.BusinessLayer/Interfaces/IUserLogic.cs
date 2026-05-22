using HealthMonitor.Domain.Entities.User;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.BusinessLayer.Interfaces
{
    public interface IUserLogic
    {
        ServiceResponse GetUserById(int id);
        ServiceResponse GetUserList();
        Task UpdateMe(int userId, UpdateUserDto request);
        ServiceResponse UpdateUser(int id, UserCreateDto user);
        ServiceResponse DeleteUser(int id);
        ServiceResponse ChangePassword(int userId, ChangePasswordDto password);
        ServiceResponse SendResetCode(ForgotPasswordDto request);
        ServiceResponse ResetPassword(ResetPasswordDto request);
        UserEntity? VerifyTwoFactor(VerifyTwoFactorDto request);
    }
}
