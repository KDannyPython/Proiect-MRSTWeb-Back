using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMonitor.Domain.Models.Food
{
    public class FoodLogDto
    {
        public int FdcId { get; set; }
        public int QuantityGrams { get; set; }
    }
}
