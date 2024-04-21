using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SimpleEcommerce.Application.Features.Notifications;
using SimpleEcommerce.Application.Features.Users;
using SimpleEcommerce.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleEcommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config,IMediator mediator)
        {

            _signInManager = signInManager;
            _config = config;
            _userManager = userManager;
            _mediator = mediator;
          
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var token = GenerateJwtToken(model.Email);
                var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
                 NotificationVM notificationVM = new NotificationVM()
                 {
                     ConnectionId = user.Id,
                     GroupName="",
                     CreatedDate = DateTime.Now,
                     UserId = user.Id
                 };
               await _mediator.Send(notificationVM);

                return Ok(new { token });
            }
            else
            {
                return BadRequest("Invalid login attempt");
            }
        }

        private string GenerateJwtToken(string email)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    



    }
}
