using HealthMonitor.BusinessLayer;
using HealthMonitor.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthMonitor.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/calendar")]
public class CalendarController : ControllerBase
{
    private readonly ICalendarLogic _calendarLogic;

    public CalendarController()
    {
        var bl = new BusinessLogic();
        _calendarLogic = bl.GetCalendarLogic();
    }

    [HttpGet("month")]
    public async Task<IActionResult> GetMonth(int year, int month)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _calendarLogic.GetMonth(userId, year, month);

        return Ok(result);
    }

    [HttpGet("day/{date}")]
    public async Task<IActionResult> GetDay(DateTime date)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _calendarLogic.GetDay(userId, date);

        return Ok(result);
    }
}