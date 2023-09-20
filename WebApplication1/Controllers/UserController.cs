using Lab12.Models;
using Lab12.Models.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private JwtToken tokenService;

        public UserController(UserManager<ApplicationUser> manager, JwtToken _tokenService, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = manager;
            tokenService = _tokenService;
            signInManager = _signInManager;
        }

        [HttpPost("Register")]
        [AllowAnonymous]

        public async Task<ActionResult<ApplicationUser>> Register(ApplicationUser user)
        {
            var result = await userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                List<string> roles = new List<string>
                {
                    "Anonymous"
                };
                await signInManager.SignInAsync(user, null);

                return new ApplicationUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = roles
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey =

                    error.Code.Contains("Password") ? nameof(user.Password) :
                    error.Code.Contains("Email") ? nameof(user.Email) :
                    error.Code.Contains("UserName") ? nameof(user.UserName) :
                    "";
                ModelState.AddModelError(errorKey, error.Description);
            }

            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [Authorize]
        [Authorize(Policy = "PropertyManager")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("Agent")]

        public async Task<ActionResult<ApplicationUser>> CreateAgent(ApplicationUser user)
        {
            var result = await userManager.CreateAsync(user, user.Password);

            if (result.Succeeded)
            {
                return new ApplicationUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = new List<string> { "Agent" },
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey =

                   error.Code.Contains("Password") ? nameof(user.Password) :
                   error.Code.Contains("Email") ? nameof(user.Email) :
                   error.Code.Contains("UserName") ? nameof(user.UserName) :
                   "";
                ModelState.AddModelError(errorKey, error.Description);
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApplicationUser>> Login(ApplicationUser data)
        {
            var user = await userManager.FindByNameAsync(data.UserName);

            if (await userManager.CheckPasswordAsync(user, data.Password))
            {
                await signInManager.SignInAsync(user, null);

                return new ApplicationUser()
                {
                    Id = user.Id,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = user.Roles
                };
            }
            if(user == null)
            {
                return Unauthorized();
            }
            return BadRequest();
        }

        [Authorize(Policy = "create")]
        [HttpGet("me")]
        public async Task<ApplicationUser> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);

            return new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = await userManager.GetRolesAsync(user),
            };
        }
    }
}
