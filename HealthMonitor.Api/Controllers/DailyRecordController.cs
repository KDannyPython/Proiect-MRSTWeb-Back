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

    // CREATE (C)
    [HttpPost("create")]
    public IActionResult CreateDailyRecord([FromBody] DailyRecordCreateDto record)
    {
        var result = _dailyRecordLogic.CreateDailyRecord(record);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    // READ BY ID (R)
    [HttpGet("{id}")]
    public IActionResult GetDailyRecordById(int id)
    {
        var result = _dailyRecordLogic.GetDailyRecordById(id);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    // READ ALL (R)
    [HttpGet("list")]
    public IActionResult GetDailyRecordList()
    {
        var result = _dailyRecordLogic.GetDailyRecordList();
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    // UPDATE (U)
    [HttpPut("update/{id}")]
    public IActionResult UpdateDailyRecord(int id, [FromBody] DailyRecordCreateDto record)
    {
        var result = _dailyRecordLogic.UpdateDailyRecord(id, record);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    // DELETE (D)
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteDailyRecord(int id)
    {
        var result = _dailyRecordLogic.DeleteDailyRecord(id);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }
}
