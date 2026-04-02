using System;

namespace HealthMonitor.Domain.Entities.User
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Goal { get; set; } // lose weight, gain muscle, maintain weight 

    }
}