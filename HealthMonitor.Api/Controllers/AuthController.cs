using HealthMonitor.Domain.Models.User;
using HealthMonitor.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthMonitor.Api.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserLoginLogic _userAction;
        public AuthController()
        {
            var bl = new BusinessLayer.BusinessLogic();
            _userAction = bl.GetUserLoginLogic();
        }

        [HttpPost("auth")]
        public IActionResult Auth([FromBody] UserLoginDto udata)
        {
            var result = _userAction.UserLoginDataValidation(udata);

            if (!result.IsSuccess)
            {
                return Unauthorized(result.Message);
            }

            return Ok(new { token = result.Message });
        }
    }
}
