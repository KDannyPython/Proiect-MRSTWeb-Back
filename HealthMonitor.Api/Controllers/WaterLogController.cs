using HealthMonitor.BusinessLayer;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Water;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthMonitor.Api.Controllers;

[Authorize]
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
    [Authorize]
    public IActionResult AddWater([FromBody] WaterLogDto water)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim);
        var result = _waterLogLogic.AddWater(userId, water);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpPost("remove")]
    [Authorize]
    public IActionResult RemoveWater([FromBody] WaterLogDto water)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim);
        var result = _waterLogLogic.RemoveWater(userId, water);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result.Message);
    }

    [HttpGet("today")]
    [Authorize]
    public IActionResult GetTodayWater()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        int userId = int.Parse(userIdClaim);

        var amount = _waterLogLogic.GetTodayWater(userId);

        return Ok(new
        {
            amountMl = amount
        });
    }
}
