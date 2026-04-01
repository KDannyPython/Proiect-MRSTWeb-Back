using System.ComponentModel.DataAnnotations;

namespace HealthMonitor.Domain.Models.Food
{
    public class FoodUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public float Calories { get; set; }
        [Required]
        public float Protein { get; set; }
        public float Carbohydrates { get; set; }
        public float Fat { get; set; }
        public float Fiber { get; set; }
        public float VitaminC { get; set; }
    }
}
