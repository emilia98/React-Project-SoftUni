using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EventTracker.InputModels;
using EventTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace EventTracker.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthController(
            ILogger<AuthController> logger, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginInputModel loginInput)
        {
            var user = await this.userManager.FindByNameAsync(loginInput.Username);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var isPasswordCorrect = await this.userManager.CheckPasswordAsync(user, loginInput.Password);

            if (!isPasswordCorrect)
            {
                return this.Unauthorized();
            }

            var userRoles = await this.userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: this.configuration["JWT:ValidIssuer"],
                audience: this.configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return this.Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterInputModel registerInput)
        {
            var dbUser = await this.userManager.FindByNameAsync(registerInput.Username);

            if (dbUser != null)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User already exist!" });
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = registerInput.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerInput.Username,
                CreatedOn = DateTime.UtcNow,
                EditedOn = DateTime.UtcNow,
                IsActive = true
            };

            var result = await this.userManager.CreateAsync(user, registerInput.Password);

            if (!result.Succeeded)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User cannot be created!" });
            }

            return this.Ok(new Response
            {
                Status = "Success",
                Message = "User created successfully"
            });
        }
    }
}