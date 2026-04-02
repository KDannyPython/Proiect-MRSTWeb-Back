using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Entities.Food;
using HealthMonitor.Domain.Models.Food;
namespace HealthMonitor.BusinessLayer.Structure;

public class FoodActions
{
    private readonly AppDbContext _context;

    public FoodActions()
    {
        _context = new AppDbContext();
    }

    public bool CreateFoodAction(FoodCreateDto food)
    {
        var foodEntity = new FoodEntity
        {
            Name = food.Name,
            Calories = food.Calories,
            Protein = food.Protein,
            Carbohydrates = food.Carbohydrates,
            Fat = food.Fat,
            Fiber = food.Fiber,
            VitaminC = food.VitaminC
        };

        try
        {
            _context.Add(foodEntity);
            _context.SaveChanges();
            return true;

        }
        catch (Exception e)
        {
            return false;
        }
    }

    public FoodInfoDto? GetFoodByIdAction(int Id)
    {
        var foodEntity = _context.Foods.Find(Id);
        if (foodEntity == null)
        {
            return null;
        }

        var foodInfoDto = new FoodInfoDto
        {
            Id = foodEntity.Id,
            Name = foodEntity.Name,
            Calories = foodEntity.Calories,
            Protein = foodEntity.Protein,
            Carbohydrates = foodEntity.Carbohydrates,
            Fat = foodEntity.Fat,
            Fiber = foodEntity.Fiber,
            VitaminC = foodEntity.VitaminC
        };

        return foodInfoDto;
    }

    public List<FoodInfoDto> GetFoodByNameAction(string Name)
    {
        if (string.IsNullOrWhiteSpace(Name))
            return new List<FoodInfoDto>();

        var foodList = GetFoodListAction();

        return foodList
            .Where(f => !string.IsNullOrWhiteSpace(f.Name) &&
                        f.Name.Contains(Name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<FoodInfoDto> GetFoodListAction()
    {
        var foodList = _context.Foods.Select(FoodEntity => new FoodInfoDto
        {
            Id = FoodEntity.Id,
            Name = FoodEntity.Name,
            Calories = FoodEntity.Calories,
            Protein = FoodEntity.Protein,
            Carbohydrates = FoodEntity.Carbohydrates,
            Fat = FoodEntity.Fat,
            Fiber = FoodEntity.Fiber,
            VitaminC = FoodEntity.VitaminC
        })
            .ToList();
        return foodList;
    }

    public bool DeleteFoodAction(int Id)
    {
        var foodEntity = _context.Foods.FirstOrDefault(f => f.Id == Id);

        if (foodEntity == null)
        {
            return false;
        }

        try
        {
            _context.Remove(foodEntity);
            _context.SaveChanges();
            return true;
        }

        catch (Exception e)
        {
            return false;
        }
    }

    public bool UpdateFoodAction(int Id, FoodUpdateDto food)
    {
        try
        {
            var foodEntity = _context.Foods.FirstOrDefault(f => f.Id == Id);

            if (foodEntity == null)
            {
                return false;
            }

            foodEntity.Name = food.Name;
            foodEntity.Calories = food.Calories;
            foodEntity.Protein = food.Protein;
            foodEntity.Carbohydrates = food.Carbohydrates;
            foodEntity.Fat = food.Fat;
            foodEntity.Fiber = food.Fiber;
            foodEntity.VitaminC = food.VitaminC;

            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}