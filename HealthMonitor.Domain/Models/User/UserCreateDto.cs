using System;

namespace HealthMonitor.Domain.Models
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Goal { get; set; }
        public string Role { get; set; } = "User"; 
    }
}