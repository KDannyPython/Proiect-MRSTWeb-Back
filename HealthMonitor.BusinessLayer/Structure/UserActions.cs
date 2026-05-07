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

        public UserActions()
        {
            _context = new AppDbContext();
            _tokenService = new TokenService();
        }

        // REGISTER
        public ServiceResponse RegisterUserAction(UserCreateDto userDto)
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
                Gender = userDto.Gender,
                Age = userDto.Age,
                Height = userDto.Height,
                Weight = userDto.Weight,
                Goal = userDto.Goal,
                Role = UserRole.User,
                RegisteredOn = DateTime.UtcNow
            };

            try
            {
                _context.Users.Add(userEntity);
                _context.SaveChanges();

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
        internal string UserTokenGeneration(UserEntity user)
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
                Role = u.Role.ToString()
            }).ToList();
        }

        // UPDATE
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
    }
}
