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

            var user = _userAction.LoginUserAction(udata);

            return Ok(new
            {
                token = result.Message,
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
