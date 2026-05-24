using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Entities.Water;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMonitor.Domain.Entities.User
{
    public enum UserRole
    {
        User,
        Admin
    }
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email-ul este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Ai introdus un format greșit de email.")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola este obligatorie.")]
        public string Password { get; set; }

        public bool OnboardingCompleted { get; set; } = false;

        [MaxLength(20)]
        public string? Gender { get; set; }
        
        [Range(1, 120, ErrorMessage = "Vârsta trebuie să fie între 1 și 120 de ani.")]
        public int? Age { get; set; }
        
        [Range(30, 250, ErrorMessage = "Înălțimea (cm) este incorectă.")]
        public int? Height { get; set; }
        
        [Range(10, 300, ErrorMessage = "Greutatea (kg) este incorectă.")]
        public int? Weight { get; set; }

        [MaxLength(50)]
        public string? Goal { get; set; }

        [MaxLength(500)]
        public string? Bio { get; set; }

        [Range(100000, 999999)]
        public string? ResetPasswordCode { get; set; }

        [Range(1000, 9999)]
        public string? TwoFactorCode { get; set; }
        public bool TwoFactorEnabled { get; set; } = false;
        public UserRole Role { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisteredOn { get; set; }

        [InverseProperty("User")]
        public ICollection<FoodLogEntity> FoodLogs { get; set; }
        = new List<FoodLogEntity>();

        [InverseProperty("User")]
        public ICollection<WaterLogEntity> WaterLogs { get; set; }
        = new List<WaterLogEntity>();
    }
}
