using HealthMonitor.BusinessLayer;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Food;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    [Authorize]
    public async Task<IActionResult> CreateFoodLog([FromBody] FoodLogDto food)
    {
        foreach (var claim in User.Claims)
        {
            Console.WriteLine($"{claim.Type}: {claim.Value}");
        }
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim.Value);
        var result = await _foodLogLogic.AddFoodLog(userId, food);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpPut("{foodLogId}")]
    [Authorize]
    public async Task<IActionResult> UpdateFoodQuantity(int foodLogId, [FromBody] FoodLogUpdateDto food)
    {
        var result = await _foodLogLogic.UpdateFoodQuantity(foodLogId, food.QuantityGrams);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpDelete("{foodLogId}")]
    [Authorize]
    public async Task<IActionResult> DeleteFoodLog(int foodLogId)
    {
        var result = await _foodLogLogic.DeleteFoodLog(foodLogId);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpGet("today")]
    [Authorize]
    public IActionResult GetTodayUserCalories()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim);

        var calories = _foodLogLogic.GetTodayCalories(userId);

        return Ok(new
        {
            Calories = calories
        });
    }
}
