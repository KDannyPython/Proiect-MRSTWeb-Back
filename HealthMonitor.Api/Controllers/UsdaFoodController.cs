using HealthMonitor.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsdaFoodController: ControllerBase
{
    private readonly IUsdaFoodLogic _usdaFoodLogic;

    public UsdaFoodController(IUsdaFoodLogic usdaFoodLogic)
    {
        _usdaFoodLogic = usdaFoodLogic;
    }

    [HttpGet("search-usda")]
    public async Task<IActionResult> SearchUsdaFood(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return BadRequest("Query is required.");
        }

        var result = await _usdaFoodLogic.SearchUsdaFoodAsync(query);

        return Ok(result);
    }   
}