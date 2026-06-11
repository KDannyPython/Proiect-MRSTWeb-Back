using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

    // ── READ (public — orice utilizator poate citi lista de exercitii) ──

    // READ BY ID (R)
    [HttpGet("{id}")]
    public IActionResult GetExerciseById(int id)
    {
        var result = _exerciseLogic.GetExerciseById(id);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    // READ ALL (R)
    [HttpGet("list")]
    public IActionResult GetExerciseList()
    {
        var result = _exerciseLogic.GetExerciseList();
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Data);
    }

    // ── WRITE (protejat — doar Admin poate crea, modifica sau sterge exercitii) ──

    // CREATE (C)
    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public IActionResult CreateExercise([FromBody] ExerciseCreateDto exercise)
    {
        var result = _exerciseLogic.CreateExercise(exercise);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    // UPDATE (U)
    [Authorize(Roles = "Admin")]
    [HttpPut("update/{id}")]
    public IActionResult UpdateExercise(int id, [FromBody] ExerciseCreateDto exercise)
    {
        var result = _exerciseLogic.UpdateExercise(id, exercise);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }

    // DELETE (D)
    [Authorize(Roles = "Admin")]
    [HttpDelete("delete/{id}")]
    public IActionResult DeleteExercise(int id)
    {
        var result = _exerciseLogic.DeleteExercise(id);
        if (!result.IsSuccess) return BadRequest(result.Message);
        return Ok(result.Message);
    }
}
