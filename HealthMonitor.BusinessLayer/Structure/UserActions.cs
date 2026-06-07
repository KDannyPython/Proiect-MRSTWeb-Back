using System;
using System.Collections.Generic;
using System.Linq;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.User;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;
using HealthMonitor.BusinessLayer.Core;

namespace HealthMonitor.BusinessLayer.Structure
{
    public class UserActions
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly EmailLogic _emailLogic;


        public UserActions()
        { 
            _context = new AppDbContext();
            _tokenService = new TokenService();
            _emailLogic = new EmailLogic();
        }

        // REGISTER
        public ServiceResponse RegisterUserAction(RegisterDto userDto)
        {
            var existingUser = _context.Users.FirstOrDefault(u =>
                u.Email == userDto.Email);

            if (existingUser != null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Account with this email already exists."
                };
            }

            var salt = PasswordHasher.GenerateSalt();
            var hash = PasswordHasher.HashPassword(userDto.Password, salt);

            var userEntity = new UserEntity
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = hash,
                PasswordSalt = salt,
                OnboardingCompleted = false,
                TwoFactorEnabled = false,
                Role = UserRole.User,
                RegisteredOn = DateTime.UtcNow
            };

            try
            {
                _context.Users.Add(userEntity);
                _context.SaveChanges();
                _emailLogic.SendEmail(
                    userDto.Email,
                    "Welcome to OmniTrack",
                    @"<h1 style='color:#2E86DE;'>Welcome to OmniTrack 🚀</h1>

                    <p>Hello,</p>

                    <p>We’re excited to have you join <strong>OmniTrack</strong>!</p>

                    <p>Your account has been successfully created and you’re now ready to start tracking your progress, managing your activities, and reaching your goals more efficiently.</p>

                    <p>If you have any questions or need assistance, feel free to contact our support team anytime.</p>

                    <p style='margin-top:20px;'>
                    Best regards,<br>
                    <strong>The OmniTrack Team</strong>
                    </p>");

                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "Registration successful."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        // LOGIN
        public UserEntity? LoginUserAction(UserLoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u =>
                (u.Email == loginDto.Credential));

            if (user == null) return null;

            var passwordHash = PasswordHasher.HashPassword(loginDto.Password, user.PasswordSalt);

            if (user.Password != passwordHash) return null;

            if (user.TwoFactorEnabled)
            {
                var random = new Random();

                var code = random
                    .Next(1000, 9999)
                    .ToString();

                user.TwoFactorCode = code;

                _context.SaveChanges();

                var emailLogic = new EmailLogic();

                emailLogic.SendEmail(
                    user.Email,
                    "Two-Factor Authentication Code",
                    $@"<h1 style='color:#2E86DE;'>Two-Factor Authentication 🔐</h1>

                    <p>Hello,</p>

                    <p>Use the verification code below to complete your login:</p>

                    <div style='margin:20px 0; padding:15px; background-color:#f4f4f4; border-radius:8px; text-align:center;'>
                        <h2 style='letter-spacing:4px; margin:0;'>{code}</h2>
                    </div>

                    <p>If you did not attempt to sign in, please ignore this email or secure your account immediately.</p>

                    <p style='margin-top:20px;'>
                    Best regards,<br>
                    <strong>The OmniTrack Team</strong>
                    </p>");

                return new UserEntity
                {
                    Id = -1
                };
            }

            return user;
        }

        // Token Generator
        public string UserTokenGeneration(UserEntity user)
        {
            var token = new TokenService();
            return token.GenerateToken(user.Id, user.Name, user.Role.ToString());
        }

        // READ by Id
        public UserInfoDto? GetUserByIdAction(int id)
        {
            var userEntity = _context.Users.Find(id);
            if (userEntity == null) return null;

            return new UserInfoDto
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Gender = userEntity.Gender,
                Age = userEntity.Age,
                Height = userEntity.Height,
                Weight = userEntity.Weight,
                Goal = userEntity.Goal,
                Bio = userEntity.Bio,
                OnboardingCompleted = userEntity.OnboardingCompleted,
                TwoFactorEnabled = userEntity.TwoFactorEnabled,
                Role = userEntity.Role.ToString()
            };
        }

        // READ All
        public List<UserInfoDto> GetUserListAction()
        {
            return _context.Users.Select(u => new UserInfoDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Gender = u.Gender,
                Age = u.Age,
                Height = u.Height,
                Weight = u.Weight,
                Goal = u.Goal,
                Bio = u.Bio,
                OnboardingCompleted = u.OnboardingCompleted,
                TwoFactorEnabled = u.TwoFactorEnabled,
                Role = u.Role.ToString()
            }).ToList();
        }

        // UPDATE
        public async Task UpdateMeAction(int userId, UpdateUserDto request)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                throw new Exception("User not found");

            if (request.Name != null)
                user.Name = request.Name;

            if (request.Email != null)
                user.Email = request.Email;
            
            if (request.Gender != null)
                user.Gender = request.Gender;

            if (request.Age.HasValue)
                user.Age = request.Age.Value;

            if (request.Height.HasValue)
                user.Height = request.Height.Value;

            if (request.Weight.HasValue)
            {
                if (user.Weight != request.Weight.Value)
                {
                    user.Weight = request.Weight.Value;
                    var weightLog = new HealthMonitor.Domain.Entities.User.WeightLogEntity
                    {
                        UserId = userId,
                        Weight = request.Weight.Value,
                        LoggedAt = DateTime.UtcNow
                    };
                    _context.WeightLogs.Add(weightLog);
                }
            }

            if (request.Goal != null)
                user.Goal = request.Goal;

            if (request.Bio != null)
                user.Bio = request.Bio;

            if (request.TwoFactorEnabled.HasValue)
                user.TwoFactorEnabled = request.TwoFactorEnabled.Value;

            await _context.SaveChangesAsync();
        }

        public ServiceResponse UpdateUserAction(int id, UserCreateDto userDto)
        {
            var userEntity = _context.Users.Find(id);
            if (userEntity == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "User not found."
                };
            }

            userEntity.Name = userDto.Name;
            userEntity.Email = userDto.Email;
            userEntity.Gender = userDto.Gender;
            userEntity.Age = userDto.Age;
            userEntity.Height = userDto.Height;
            userEntity.Weight = userDto.Weight;
            userEntity.Goal = userDto.Goal;
            userEntity.Role = userDto.Role; 

            try
            {
                _context.SaveChanges();
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "User updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public ServiceResponse SendDeleteVerificationCodeAction(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "User not found."
                };
            }

            var random = new Random();

            var code = random
                .Next(1000, 9999)
                .ToString();

            user.TwoFactorCode = code;

            _context.SaveChanges();

            var emailLogic = new EmailLogic();

            emailLogic.SendEmail(
                user.Email,
                "Security Verification Code",
                $@"
                <div style='font-family:Arial,sans-serif; color:#333; line-height:1.6;'>
        
                    <h2 style='color:#2E86DE; margin-bottom:10px;'>
                        Account Deletion Verification
                    </h2>

                    <p>Hello,</p>

                    <p>
                        Use the verification code below to confirm your account deletion request:
                    </p>

                    <div style='
                        margin:24px 0;
                        padding:16px;
                        background:#f5f7fa;
                        border-radius:10px;
                        text-align:center;
                    '>
                        <span style='
                            font-size:28px;
                            font-weight:bold;
                            letter-spacing:6px;
                            color:#111;
                        '>
                            {code}
                        </span>
                    </div>

                    <p>
                        If you did not request to delete your account, you can safely ignore this email.
                    </p>

                    <p style='margin-top:30px;'>
                        Best regards,<br>
                        <strong>OmniTrack Team</strong>
                    </p>

                </div>"
            );


            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Verification code sent."
            };
        }

        // DELETE
        public ServiceResponse DeleteUserAction(int id)
        {
            var userEntity = _context.Users.Find(id);
            if (userEntity == null) return new ServiceResponse
            {
                IsSuccess = false,
                Message = "User not found."
            };

            try
            {
                _context.Users.Remove(userEntity);
                _context.SaveChanges();
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "User deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // CHANGE PASSWORD
        public ServiceResponse ChangePasswordAction(int userId, ChangePasswordDto request)
        {
            try
            {
                var user = _context.Users.Find(userId);

                if (user == null)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "User not found"
                    };
                }
                var currentPasswordSalt = user.PasswordSalt;
                var currentPasswordHash = PasswordHasher.HashPassword(request.CurrentPassword, currentPasswordSalt);

                if (user.Password != currentPasswordHash)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "Current password is incorrect"
                    };
                }

                if (request.CurrentPassword == request.NewPassword)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "New password must be different"
                    };
                }
                
                var newPasswordSalt = PasswordHasher.GenerateSalt();
                var newPasswordHash = PasswordHasher.HashPassword(request.NewPassword, newPasswordSalt);

                user.Password = newPasswordHash;
                user.PasswordSalt = newPasswordSalt;

                _context.SaveChanges();

                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "Password changed successfully"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public ServiceResponse CompleteOnboardingAction(int userId, OnboardingDto dto)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "User not found."
                };
            }

            user.Gender = dto.Gender;
            user.Age = dto.Age;
            user.Height = dto.Height;
            user.Weight = dto.Weight;
            user.Goal = dto.Goal;
            user.OnboardingCompleted = true;

            _context.SaveChanges();

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = "Onboarding completed."
            };
        }

        // FORGOT PASSWORD
        public ServiceResponse SendResetCodeAction(ForgotPasswordDto request)
        {
            try
            {
                var user = _context.Users
                    .FirstOrDefault(x =>
                        x.Email == request.Email);

                if (user == null)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "User not found."
                    };
                }

                var random = new Random();

                var code = random
                    .Next(100000, 999999)
                    .ToString();

                user.ResetPasswordCode = code;

                _context.SaveChanges();

                var emailLogic = new EmailLogic();

                emailLogic.SendEmail(
                    user.Email,
                    "Password Reset Code",
                    $@"<h1 style='color:#E67E22;'>Password Reset Request 🔑</h1>

                    <p>Hello,</p>

                    <p>We received a request to reset your password for your <strong>OmniTrack</strong> account.</p>

                    <p>Use the code below to continue:</p>

                    <div style='margin:20px 0; padding:15px; background-color:#f4f4f4; border-radius:8px; text-align:center;'>
                        <h2 style='letter-spacing:4px; margin:0;'>{code}</h2>
                    </div>

                    <p>If you did not request a password reset, you can safely ignore this email.</p>

                    <p style='margin-top:20px;'>
                    Best regards,<br>
                    <strong>The OmniTrack Team</strong>
                    </p>");

                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "Reset code sent."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // RESET PASSWORD
        public ServiceResponse ResetPasswordAction(ResetPasswordDto request)
        {
            try
            {
                var user = _context.Users
                    .FirstOrDefault(x =>
                        x.Email == request.Email);

                if (user == null)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "User not found."
                    };
                }

                if (user.ResetPasswordCode != request.Code)
                {
                    return new ServiceResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid code."
                    };
                }

                var newPasswordSalt = PasswordHasher.GenerateSalt();
                user.Password = PasswordHasher.HashPassword(request.NewPassword, newPasswordSalt);
                user.PasswordSalt = newPasswordSalt;

                user.ResetPasswordCode = null;

                _context.SaveChanges();

                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "Password reset successful."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // VERIFY 2FA
        public UserEntity? VerifyTwoFactorAction(VerifyTwoFactorDto request)
        {
            var emailOrName = request.Email?.Trim().ToLower();
            var user = _context.Users
                .FirstOrDefault(x =>
                    x.Email.ToLower() == emailOrName ||
                    x.Name.ToLower() == emailOrName);

            if (user == null) return null;

            if (user.TwoFactorCode?.Trim() != request.Code?.Trim()) return null;

            user.TwoFactorCode = null;

            _context.SaveChanges();

            return user;
        }

        public ServiceResponse ResetUserDataAction(int userId)
        {
            try
            {
                var foodLogs = _context.FoodLogs.Where(f => f.UserId == userId);
                _context.FoodLogs.RemoveRange(foodLogs);

                var waterLogs = _context.WaterLogs.Where(w => w.UserId == userId);
                _context.WaterLogs.RemoveRange(waterLogs);

                var weightLogs = _context.WeightLogs.Where(w => w.UserId == userId);
                _context.WeightLogs.RemoveRange(weightLogs);

                var workouts = _context.Workouts.Where(w => w.UserId == userId);
                _context.Workouts.RemoveRange(workouts);

                _context.SaveChanges();
                return new ServiceResponse { IsSuccess = true, Message = "User data reset successfully." };
            }
            catch (Exception ex)
            {
                return new ServiceResponse { IsSuccess = false, Message = ex.Message };
            }
        }

        public string GetUserEmailByCredentialAction(string credential)
        {
            var emailOrName = credential?.Trim().ToLower();
            var user = _context.Users.FirstOrDefault(u => 
                u.Email.ToLower() == emailOrName || 
                u.Name.ToLower() == emailOrName);
            return user?.Email ?? credential;
        }

        public ServiceResponse SetUserRoleAction(int userId, UserRole role)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "User not found."
                };
            }

            user.Role = role;

            try
            {
                _context.SaveChanges();
                return new ServiceResponse
                {
                    IsSuccess = true,
                    Message = "User role updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}