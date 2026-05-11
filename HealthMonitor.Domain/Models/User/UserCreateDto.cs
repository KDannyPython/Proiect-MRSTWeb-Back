using System;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.User
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public bool OnboardingCompleted { get; set; } = false;

        [MaxLength(20)]
        public string Gender { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public int Age { get; set; }

        [Range(30, 250, ErrorMessage = "Height (cm) is incorrect.")]
        public int Height { get; set; }

        [Range(10, 300, ErrorMessage = "Weight (kg) is incorrect.")]
        public int Weight { get; set; }

        [MaxLength(50)]
        public string Goal { get; set; }
    }
}
