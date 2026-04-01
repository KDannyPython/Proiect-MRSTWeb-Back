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
            name = food.name,
            calories = food.calories,
            protein = food.protein,
            carbohydrates = food.carbohydrates,
            fat = food.fat,
            fiber = food.fiber,
            vitaminC = food.vitaminC
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

    public bool DeleteFoodAction(int Id)
    {
        var foodEntity = _context.Foods.FirstOrDefault(f => f.id == Id);

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

    public FoodInfoDto? GetFoodByIdAction(int id)
    {
        var foodEntity = _context.Foods.Find(id);
        if (foodEntity == null)
        {
            return null;
        }

        var foodInfoDto = new FoodInfoDto
        {
            id = foodEntity.id,
            name = foodEntity.name,
            calories = foodEntity.calories,
            protein = foodEntity.protein,
            carbohydrates = foodEntity.carbohydrates,
            fat = foodEntity.fat,
            fiber = foodEntity.fiber,
            vitaminC = foodEntity.vitaminC
        };

        return foodInfoDto;
    }

    public List<FoodInfoDto> GetFoodListAction()
    {
        var foodList = _context.Foods.Select(FoodEntity => new FoodInfoDto
            {
                id = FoodEntity.id,
                name = FoodEntity.name,
                calories = FoodEntity.calories,
                protein = FoodEntity.protein,
                carbohydrates = FoodEntity.carbohydrates,
                fat = FoodEntity.fat,
                fiber = FoodEntity.fiber,
                vitaminC = FoodEntity.vitaminC
        })
            .ToList();
        return foodList;
    }
}