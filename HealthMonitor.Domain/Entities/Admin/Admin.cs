using System;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Entities.Admin
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele adminului este obligatoriu.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email-ul adminului este obligatoriu.")]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
