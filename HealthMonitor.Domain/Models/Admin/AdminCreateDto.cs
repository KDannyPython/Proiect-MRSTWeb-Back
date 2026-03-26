using System;

namespace HealthMonitor.Domain.Models
{
    public class AdminCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "Admin";
    }
}
