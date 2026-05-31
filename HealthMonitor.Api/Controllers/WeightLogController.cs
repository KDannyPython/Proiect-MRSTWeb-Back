using HealthMonitor.BusinessLayer;
using HealthMonitor.Domain.Models.Service;
using HealthMonitor.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthMonitor.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeightLogController : ControllerBase
    {
        private readonly BusinessLogic _businessLogic;

        public WeightLogController(BusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        [POST]
        public async Task<IActionResult> LogWeight([FromBody] WeightLogDto dto)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                return Unauthorized(new ServiceResponse { IsSuccess = false, Message = "Invalid user token." });
            }

            var result = await _businessLogic.GetWeightLogLogic().LogWeight(userId, dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetWeightHistory([FromQuery] int? limit)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                return Unauthorized(new { IsSuccess = false, Message = "Invalid user token." });
            }

            var history = await _businessLogic.GetWeightLogLogic().GetWeightHistory(userId, limit);
            return Ok(history);
        }
    }
}
