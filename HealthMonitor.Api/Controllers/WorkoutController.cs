using Microsoft.AspNetCore.Mvc;
using HealthMonitor.BusinessLayer;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Workout;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/workout")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutLogic _workoutLogic;

    public WorkoutController()
    {
        var bl = new BusinessLogic();
        _workoutLogic = bl.GetWorkoutLogic();
    }

    [HttpGet("{id}")]
    public IActionResult GetWorkoutById(int id)
    {
        var result = _workoutLogic.GetWorkoutById(id);
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpGet("list")]
    public IActionResult GetWorkoutList()
    {
        var result = _workoutLogic.GetWorkoutList();
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPost("create")]
    public IActionResult CreateWorkout([FromBody] WorkoutCreateDto workout)
    {
        var result = _workoutLogic.CreateWorkout(workout);
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Message);
    }
}
