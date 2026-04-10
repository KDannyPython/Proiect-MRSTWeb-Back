using System;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Entities.User
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email-ul este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Ai introdus un format greșit de email.")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola este obligatorie.")]
        public string PasswordHash { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; }
        
        [Range(1, 120, ErrorMessage = "Vârsta trebuie să fie între 1 și 120 de ani.")]
        public int Age { get; set; }
        
        [Range(30, 250, ErrorMessage = "Înălțimea (cm) este incorectă.")]
        public int Height { get; set; }
        
        [Range(10, 300, ErrorMessage = "Greutatea (kg) este incorectă.")]
        public int Weight { get; set; }

        [MaxLength(50)]
        public string Goal { get; set; } 
    }
}
