using Microsoft.AspNetCore.Mvc;
using HealthMonitor.BusinessLayer;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.DailyRecord;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/dailyrecord")]
public class DailyRecordController : ControllerBase
{
    private readonly IDailyRecordLogic _dailyRecordLogic;

    public DailyRecordController()
    {
        var bl = new BusinessLogic();
        _dailyRecordLogic = bl.GetDailyRecordLogic();
    }

    [HttpGet("{id}")]
    public IActionResult GetDailyRecordById(int id)
    {
        var result = _dailyRecordLogic.GetDailyRecordById(id);
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpGet("list")]
    public IActionResult GetDailyRecordList()
    {
        var result = _dailyRecordLogic.GetDailyRecordList();
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPost("create")]
    public IActionResult CreateDailyRecord([FromBody] DailyRecordCreateDto record)
    {
        var result = _dailyRecordLogic.CreateDailyRecord(record);
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Message);
    }
}
