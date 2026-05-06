using System;
using System.Collections.Generic;
using System.Linq;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.User;
using HealthMonitor.Domain.Models.User;
using HealthMonitor.BusinessLayer.Core;

namespace HealthMonitor.BusinessLayer.Structure
{
    public class UserActions
    {
        private readonly AppDbContext _context;

        public UserActions()
        {
            _context = new AppDbContext();
        }

        // CREATE
        public bool CreateUserAction(UserCreateDto userDto)
        {
            var userEntity = new UserEntity
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = PasswordHasher.Hash(userDto.PasswordHash)
                Gender = userDto.Gender,
                Age = userDto.Age,
                Height = userDto.Height,
                Weight = userDto.Weight,
                Goal = userDto.Goal
            };

            try
            {
                _context.Users.Add(userEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                Goal = userEntity.Goal
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
                Goal = u.Goal
            }).ToList();
        }

        // UPDATE
        public bool UpdateUserAction(int id, UserCreateDto userDto)
        {
            var userEntity = _context.Users.Find(id);
            if (userEntity == null) return false;

            userEntity.Name = userDto.Name;
            userEntity.Email = userDto.Email;
            userEntity.PasswordHash = userDto.PasswordHash;
            userEntity.Gender = userDto.Gender;
            userEntity.Age = userDto.Age;
            userEntity.Height = userDto.Height;
            userEntity.Weight = userDto.Weight;
            userEntity.Goal = userDto.Goal;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE
        public bool DeleteUserAction(int id)
        {
            var userEntity = _context.Users.Find(id);
            if (userEntity == null) return false;

            try
            {
                _context.Users.Remove(userEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
