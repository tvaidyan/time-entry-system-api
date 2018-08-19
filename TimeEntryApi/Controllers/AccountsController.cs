using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TimeEntryApi.Core;

namespace TimeEntryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<AccountsController> logger;
        private readonly SignInManager<Employee> signInManager;
        private readonly UserManager<Employee> userManager;
        private readonly IConfiguration configuration;

        public AccountsController(IRepository repository,
            ILogger<AccountsController> logger,
            SignInManager<Employee> signInManager,
            UserManager<Employee> userManager,
            IConfiguration configuration)
        {
            this.repository = repository;
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        // POST api/login
        [HttpPost]
        [Route("~/api/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        // Create the token
                        var claims = new[] {
                            new Claim (JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                            new Claim (JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            configuration["Jwt:Issuer"],
                            configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: creds);

                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            firstName = user.FirstName,
                            lastName = user.LastName,
                            userName = user.UserName,
                            id = user.Id
                        };

                        return Created("", results);
                    }
                }
                return Unauthorized();
            }
            return BadRequest();
        }

        // POST api/logout
        [HttpPost]
        [Route("~/api/logout")]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}