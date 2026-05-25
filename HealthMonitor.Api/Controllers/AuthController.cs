using HealthMonitor.BusinessLayer.Core;
using HealthMonitor.BusinessLayer.Interfaces;
using HealthMonitor.BusinessLayer.Structure;
using HealthMonitor.DataAccesLayer.Context;
using HealthMonitor.Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
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
                var context = new AppDbContext();
                var userEntity = context.Users.FirstOrDefault(u => 
                    u.Email.ToLower() == udata.Credential.Trim().ToLower() || 
                    u.Name.ToLower() == udata.Credential.Trim().ToLower());
                var actualEmail = userEntity?.Email ?? udata.Credential;

                return Ok(new
                {
                    requiresTwoFactor = true,
                    email = actualEmail
                });
            }

            var user = _userAction.LoginUserAction(udata);

            // Daca user este null, inseamna ca s-a logat un Admin (gasit in tabela Admins)
            if (user == null)
            {
                return Ok(new
                {
                    token = result.Message,
                    onboardingCompleted = true // Adminii nu trec prin onboarding
                });
            }

            return Ok(new
            {
                token = result.Message,
                onboardingCompleted = user.OnboardingCompleted
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

        [HttpPost("complete-onboarding")]
        public IActionResult CompleteOnboarding([FromBody] OnboardingDto dto)
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader))
                return Unauthorized();

            var token = authHeader.Replace("Bearer ", "");

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var idClaim = jwt.Claims.FirstOrDefault(x =>
                x.Type == ClaimTypes.NameIdentifier);

            if (idClaim == null)
            { 
                return Unauthorized(); 
            }

            int userId = int.Parse(idClaim.Value);

            var context = new AppDbContext();

            var user = context.Users.Find(userId);

            if (user == null)
                return NotFound();

            user.Gender = dto.Gender;
            user.Age = dto.Age;
            user.Height = dto.Height;
            user.Weight = dto.Weight;
            user.Goal = dto.Goal;

            user.OnboardingCompleted = true;

            context.SaveChanges();

            return Ok();
        }
    }
}
