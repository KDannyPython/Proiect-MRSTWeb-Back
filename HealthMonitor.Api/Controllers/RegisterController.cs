using Microsoft.AspNetCore.Mvc;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.Domain.Models.User;

namespace HealthMonitor.Api.Controllers
{
    [Route("api/reg")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRegLogic _userReg;
        public RegisterController()
        {
            var bl = new BusinessLayer.BusinessLogic();
            _userReg = bl.GetUserRegLogic();
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserCreateDto uRegData)
        {
            var data = _userReg.UserRegDataValidation(uRegData);
            if (data.IsSuccess)
            {
                return Ok(data.Message);
            }

            return Ok(data.Message);
        }
    }
}
