using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.Notification
{
    public class CreateNotificationDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(70)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(400)]
        public string Description { get; set; } = string.Empty;
    }
}
