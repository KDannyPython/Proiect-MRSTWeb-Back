using HealthMonitor.Domain.Entities.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Entities.Food
{
    public class FoodLogEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; } = null!;
        public int FoodId { get; set; }

        [ForeignKey("FoodId")]
        public FoodEntity Food { get; set; } = null!;
        public int QuantityGrams { get; set; }
        public DateTime LoggedAt { get; set; }
    }
}
