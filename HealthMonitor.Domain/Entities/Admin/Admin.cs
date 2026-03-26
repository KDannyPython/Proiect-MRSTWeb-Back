using System;

namespace HealthMonitor.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "Admin"; // trebuie sa facem cumva sa intelegem ca e admin
    }
}