using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer; 
using HealthMonitor.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
namespace HealthMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController()
        {
            var bl = new BusinessLogic();
            _userLogic = bl.GetUserLogic();
        }
        
        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var response = _userLogic.GetUserById(id);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetUserList()
        {
            var response = _userLogic.GetUserList();
            return Ok(response);
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserCreateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var response = _userLogic.UpdateUser(id, userDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var response = _userLogic.DeleteUser(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
