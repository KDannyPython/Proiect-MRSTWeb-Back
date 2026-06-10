using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer;
using HealthMonitor.Domain.Models.Food;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/food")]
public class FoodController : ControllerBase
{
    private readonly IFoodLogic _foodLogic;

    public FoodController()
    {
        var bl = new BusinessLogic();
        _foodLogic = bl.GetFoodLogic();
    }

    // ── READ (public — orice utilizator poate citi baza de date cu alimente) ──

    [HttpGet("{Id}")]
    public IActionResult GetFoodById(int Id)
    {
        var result = _foodLogic.GetFoodById(Id);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet("search")]
    public IActionResult GetFoodByName(string Name)
    {
        var result = _foodLogic.GetFoodByName(Name);
        if (!result.IsSuccess)
        {
            return NotFound(result.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet("list")]
    public IActionResult GetFoodList()
    {
        var result = _foodLogic.GetFoodList();
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Data);
    }

    // ── WRITE (protejat — doar Admin poate crea, modifica sau sterge alimente) ──

    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public IActionResult CreateFood([FromBody] FoodCreateDto food)
    {
        var result = _foodLogic.CreateFood(food);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{Id}")]
    public IActionResult UpdateFoodById(int Id, FoodUpdateDto food)
    {
        var result = _foodLogic.UpdateFoodById(Id, food);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{Id}")]
    public IActionResult DeleteFoodById(int Id)
    {
        var result = _foodLogic.DeleteFoodById(Id);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }
}
