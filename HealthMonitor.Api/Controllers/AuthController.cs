using HealthMonitor.BusinessLayer.Core;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.Domain.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthMonitor.Api.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly IUserLoginLogic _userAction;
        public AuthController()
        {
            var bl = new BusinessLayer.BusinessLogic();
            _userAction = bl.GetUserLoginLogic();
            _userLogic = bl.GetUserLogic();
        }

        [HttpPost("auth")]
        public IActionResult Auth([FromBody] UserLoginDto udata)
        {
            var result = _userAction.UserLoginDataValidation(udata);

            if (!result.IsSuccess)
            {
                return Unauthorized(result.Message);
            }

            if (result.Message == "2FA_REQUIRED")
            {
                var actualEmail = _userLogic.GetUserEmailByCredential(udata.Credential);

                return Ok(new
                {
                    requiresTwoFactor = true,
                    email = actualEmail
                });
            }

            var user = _userAction.LoginUserAction(udata);

            return Ok(new
            {
                token = result.Message,
                onboardingCompleted = user?.OnboardingCompleted ?? true
            });
        }

        [HttpPost("verify-2fa")]
        public IActionResult VerifyTwoFactor([FromBody] VerifyTwoFactorDto request)
        {
            var user = _userLogic.VerifyTwoFactor(request);

            if (user == null)
            {
                return BadRequest("Invalid verification code.");
            }

            var token = _userAction.UserTokenGeneration(user);

            return Ok(new
            {
                token,
                onboardingCompleted = user.OnboardingCompleted
            });
        }

        [Authorize]
        [HttpPost("complete-onboarding")]
        public IActionResult CompleteOnboarding([FromBody] OnboardingDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);

            var response = _userLogic.CompleteOnboarding(userId, dto);

            if (!response.IsSuccess)
                return NotFound(response.Message);

            return Ok();
        }
    }
}
