using Microsoft.AspNetCore.Mvc;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer;
using HealthMonitor.Domain.Models.Food;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodLogController : ControllerBase
{
    private readonly IFoodLogLogic _foodLogLogic;

    public FoodLogController()
    {
        var bl = new BusinessLogic();
        _foodLogLogic = bl.GetFoodLogLogic();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateFoodLog(int userId, [FromBody] FoodLogDto food)
    {
        var result = await _foodLogLogic.LogFoodAction(userId, food);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpPut("{foodLogId}")]
    public async Task<IActionResult> UpdateFoodQuantity(int foodLogId, [FromBody] FoodLogUpdateDto food)
    {
        var result = await _foodLogLogic.UpdateFoodQuantityAction(foodLogId, food.QuantityGrams);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpDelete("{foodLogId}")]
    public async Task<IActionResult> DeleteFoodLog(int foodLogId)
    {
        var result = await _foodLogLogic.DeleteFoodLogAction(foodLogId);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

}
