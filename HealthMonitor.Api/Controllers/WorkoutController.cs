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

    //CREATE (C)
    [HttpPost("create")]
    public IActionResult CreateWorkout([FromBody] WorkoutCreateDto workout)
    {
        var result = _workoutLogic.CreateWorkout(workout);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    //READ by id (R)
    [HttpGet("{id}")]
    public IActionResult GetWorkoutById(int id)
    {
        var result = _workoutLogic.GetWorkoutById(id);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    //READ ALL (R)
    [HttpGet("list")]
    public IActionResult GetWorkoutList()
    {
        var result = _workoutLogic.GetWorkoutList();
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    //UPDATE (U)
    [HttpPut("update/{id}")]
    public IActionResult UpdateWorkout(int id, [FromBody] WorkoutCreateDto workout)
    {
        var result = _workoutLogic.UpdateWorkout(id, workout);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    //DELETE (D)
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteWorkout(int id)
    {
        var result = _workoutLogic.DeleteWorkout(id);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }

}
