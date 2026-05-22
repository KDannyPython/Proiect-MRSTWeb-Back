using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer; 
using HealthMonitor.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader))
            {
                return Unauthorized();
            }

            var token = authHeader.Replace("Bearer ", "");
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var idClaim = jwt.Claims.FirstOrDefault(x =>
                x.Type == ClaimTypes.NameIdentifier);

            if (idClaim == null)
            {
                return Unauthorized();
            }

            int userId = int.Parse(idClaim.Value);

            var user = _userLogic.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var response = _userLogic.GetUserById(id);
            if (!response.IsSuccess)
            {
                return NotFound(response);
            }

            return Ok(response.Data);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetUserList()
        {
            var response = _userLogic.GetUserList();
            return Ok(response.Data);
        }

        [Authorize]
        [HttpPatch("me")]
        public async Task<IActionResult> UpdateMe([FromBody] UpdateUserDto request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            await _userLogic.UpdateMe(userId, request);

            return Ok();
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

            return Ok(response.Message);
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var response = _userLogic.DeleteUser(id);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response.Message);
        }

        [Authorize]
        [HttpPatch("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordDto request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var response = _userLogic.ChangePassword(userId, request);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("send-reset-code")]
        public IActionResult SendResetCode([FromBody] ForgotPasswordDto request)
        {
            var response = _userLogic.SendResetCode(request);

            if (!response.IsSuccess)
            { 
                return BadRequest(response); 
            }

            return Ok(response);
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto request)
        {
            var response = _userLogic.ResetPassword(request);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}