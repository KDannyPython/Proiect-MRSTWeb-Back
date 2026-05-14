using HealthMonitor.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMonitor.Domain.Entities.Water
{
    public class WaterLogEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; } = null!;
        public int AmountMl { get; set; }
        public DateTime LoggedAt { get; set; }
    }
}
