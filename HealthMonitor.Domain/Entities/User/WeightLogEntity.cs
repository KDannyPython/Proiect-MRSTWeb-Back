using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMonitor.Domain.Entities.User
{
    public class WeightLogEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public UserEntity User { get; set; } = null!;

        [Required]
        public float Weight { get; set; }

        [Required]
        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
    }
}
