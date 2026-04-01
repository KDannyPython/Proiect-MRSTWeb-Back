using Microsoft.AspNetCore.Mvc;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer;
using HealthMonitor.Domain.Models.Food;

namespace HealthMonitor.Api.Controllers;

[ApiController]
[Route("api/food")]
public class FoodController: ControllerBase
{
    private readonly IFoodLogic _foodLogic;

    public FoodController()
    {
        var bl = new BusinessLogic();
        _foodLogic = bl.GetFoodLogic();
    }

    [HttpGet("{id}")]
    public IActionResult GetFoodById(int id)
    {
        var result = _foodLogic.GetFoodById(id);
        if (!result.IsSucces)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Data);
    }

    [HttpGet("list")]
    public IActionResult GetFoodList()
    {
        var result = _foodLogic.GetFoodList();
        if (!result.IsSucces)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Data);
    }

    [HttpPost("create")]
    public IActionResult CreateFood([FromBody] FoodCreateDto food)
    {
        var result = _foodLogic.CreateFood(food);
        if (!result.IsSucces)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }

    [HttpGet("{id}")]
    public IActionResult DeleteFoodById(int id)
    {
        var result = _foodLogic.DeleteFoodById(id);
        if (!result.IsSucces)
        {
            return BadRequest(result.Message);
        }
        return Ok(result.Message);
    }
    //HttpPut / HttpPatch
    //HttpDelete
}
