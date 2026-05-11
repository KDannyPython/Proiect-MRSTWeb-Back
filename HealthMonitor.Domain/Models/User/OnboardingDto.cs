using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.User
{
    public class OnboardingDto
    {
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
