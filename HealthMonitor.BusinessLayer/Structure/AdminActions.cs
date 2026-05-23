using System;
using System.Collections.Generic;
using System.Linq;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Admin;
using HealthMonitor.Domain.Models.Admin;
using HealthMonitor.Domain.Models.User;
using HealthMonitor.BusinessLayer.Core;

namespace HealthMonitor.BusinessLayer.Structure
{
    public class AdminActions
    {
        private readonly AppDbContext _context;

        public AdminActions()
        {
            _context = new AppDbContext();
        }

        public Admin? LoginAdminAction(UserLoginDto loginDto)
        {
            var passwordHash = PasswordHasher.HashPassword(loginDto.Password);
            var admin = _context.Admins.FirstOrDefault(a => 
                (a.Email == loginDto.Credential || a.Name == loginDto.Credential) && a.PasswordHash == passwordHash);
            
            return admin;
        }

        public string AdminTokenGeneration(Admin admin)
        {
            var token = new TokenService();
            return token.GenerateToken(admin.Id, admin.Name, "Admin");
        }

        public bool CreateAdminAction(AdminCreateDto adminDto)
        {
            var adminEntity = new Admin
            {
                Name = adminDto.Name,
                Email = adminDto.Email,
                PasswordHash = PasswordHasher.HashPassword(adminDto.PasswordHash) // adminDto.PasswordHash contine de fapt parola in clar din request
            };

            try
            {
                _context.Admins.Add(adminEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AdminInfoDto? GetAdminByIdAction(int id)
        {
            var adminEntity = _context.Admins.Find(id);
            if (adminEntity == null) return null;

            return new AdminInfoDto
            {
                Id = adminEntity.Id,
                Name = adminEntity.Name,
                Email = adminEntity.Email
            };
        }

        public List<AdminInfoDto> GetAdminListAction()
        {
            return _context.Admins.Select(a => new AdminInfoDto
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email
            }).ToList();
        }

        public bool UpdateAdminAction(int id, AdminCreateDto adminDto)
        {
            var adminEntity = _context.Admins.Find(id);
            if (adminEntity == null) return false;

            adminEntity.Name = adminDto.Name;
            adminEntity.Email = adminDto.Email;
            adminEntity.PasswordHash = PasswordHasher.HashPassword(adminDto.PasswordHash);

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

        public bool DeleteAdminAction(int id)
        {
            var adminEntity = _context.Admins.Find(id);
            if (adminEntity == null) return false;

            try
            {
                _context.Admins.Remove(adminEntity);
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

