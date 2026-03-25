using Microsoft.AspNetCore.Mvc;
using HealthMonitor.BusinessLayer;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.Exercise;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/exercise")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseLogic _exerciseLogic;

    public ExerciseController()
    {
        var bl = new BusinessLogic();
        _exerciseLogic = bl.GetExerciseLogic();
    }

    [HttpGet("{id}")]
    public IActionResult GetExerciseById(int id)
    {
        var result = _exerciseLogic.GetExerciseById(id);
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpGet("list")]
    public IActionResult GetExerciseList()
    {
        var result = _exerciseLogic.GetExerciseList();
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    [HttpPost("create")]
    public IActionResult CreateExercise([FromBody] ExerciseCreateDto exercise)
    {
        var result = _exerciseLogic.CreateExercise(exercise);
        if (!result.IsSucces) return BadRequest(result.Message);
        return Ok(result.Message);
    }
}
