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
                u.Email == userDto.Email ||
                u.Name == userDto.Name);

            if (existingUser != null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = "Email or username already exists."
                };
            }

            var userEntity = new UserEntity
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = PasswordHasher.HashPassword(userDto.Password),
                OnboardingCompleted = false,
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
                "<h1>Welcome!</h1>");

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
            var passwordHash = PasswordHasher.HashPassword(loginDto.Password);

            var user = _context.Users.FirstOrDefault(u =>
                (u.Email == loginDto.Credential ||
                 u.Name == loginDto.Credential)
                 &&
                 u.Password == passwordHash);

            if (user == null) return null;

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
                OnboardingCompleted = userEntity.OnboardingCompleted,
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
                OnboardingCompleted = u.OnboardingCompleted,
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
                user.Weight = request.Weight.Value;

            if (request.Goal != null)
                user.Goal = request.Goal;

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
            userEntity.Password = PasswordHasher.HashPassword(userDto.Password);
            userEntity.Gender = userDto.Gender;
            userEntity.Age = userDto.Age;
            userEntity.Height = userDto.Height;
            userEntity.Weight = userDto.Weight;
            userEntity.Goal = userDto.Goal;

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

                var currentPasswordHash = PasswordHasher.HashPassword(request.CurrentPassword);

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

                var newPasswordHash = PasswordHasher.HashPassword(request.NewPassword);

                user.Password = newPasswordHash;

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
                    "Reset Password",
                    $"<h1>Your reset code is: {code}</h1>");

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

                user.Password = PasswordHasher.HashPassword(request.NewPassword);

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
    }
}
