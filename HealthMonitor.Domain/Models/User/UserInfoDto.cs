using System;

namespace HealthMonitor.Domain.Models.User
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string? Goal { get; set; }
        public string? Bio { get; set; }
        public bool OnboardingCompleted { get; set; } = false;
        public bool TwoFactorEnabled { get; set; } = false;
        public string Role { get; set; }

    }
}