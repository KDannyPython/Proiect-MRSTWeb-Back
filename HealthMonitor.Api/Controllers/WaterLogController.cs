using HealthMonitor.BusinessLayer;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Water;
using Microsoft.AspNetCore.Mvc;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WaterLogController : ControllerBase
{
    private readonly IWaterLogLogic _waterLogLogic;
    public WaterLogController()
    {
        var bl = new BusinessLogic();
        _waterLogLogic = bl.GetWaterLogLogic();
    }

    [HttpPost("add")]
    public IActionResult AddWater(int userId, [FromBody] WaterLogDto water)
    {
        var result = _waterLogLogic.AddWater(userId, water);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpPost("remove")]
    public IActionResult RemoveWater(int userId, [FromBody] WaterLogDto water)
    {
        var result = _waterLogLogic.RemoveWater(userId, water);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpGet("today")]
    public IActionResult GetTodayWater(int userId)
    {
        var amount = _waterLogLogic.GetTodayWater(userId);

        return Ok(amount);
    }
}
