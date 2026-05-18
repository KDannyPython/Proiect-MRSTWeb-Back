using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.Food
{
    public class FoodUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public double Calories { get; set; }
        [Required]
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double VitaminC { get; set; }
    }
}
