using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.User;
using HealthMonitor.BusinessLayer.Structure;
using Microsoft.AspNetCore.Mvc;

namespace HealthMonitor.Api.Controllers
{
    [Route("api/reg")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRegLogic _userReg;
        private readonly IUserLoginLogic _userAction;
        public RegisterController()
        {
            var bl = new BusinessLayer.BusinessLogic();
            _userReg = bl.GetUserRegLogic();
            _userAction = bl.GetUserLoginLogic();
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterDto uRegData)
        {
            var data = _userReg.UserRegDataValidation(uRegData);
            if (!data.IsSuccess)
            {
                return BadRequest(data.Message);
            }

            var createdUser = _userAction.UserLoginDataValidation(
                new UserLoginDto
                {
                    Credential = uRegData.Email,
                    Password = uRegData.Password
                });

            if (!createdUser.IsSuccess)
            {
                return BadRequest(createdUser.Message);
            }

            return Ok(new
            {
                token = createdUser.Message,
                onboardingCompleted = false
            });
        }
    }
}
