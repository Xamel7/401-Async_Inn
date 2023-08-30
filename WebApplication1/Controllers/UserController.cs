using System;
using System.Linq;
using Lab12.Models;
using Lab12.Models.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> Manager)
        {
            userManager = Manager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ApplicationUser>> Register(ApplicationUser data)
        {
            var user = new ApplicationUser
            {
                UserName = data.UserName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };
            var result = await userManager.CreateAsync(user, data.Password);

            if(result.Succeeded)
            {
                return new ApplicationUser
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.UserName) :
                    "";
                ModelState.AddModelError(errorKey, error.Description);
            }

            if (ModelState.IsValid)
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ApplicationUser>> Login(ApplicationUser data)
        {
            var user = await userManager.FindByNameAsync(data.UserName);

            if(await userManager.CheckPasswordAsync(user, data.Password))
            {
                return new ApplicationUser()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };
            }
            if(user == null)
            {
                return Unauthorized();
            }
            return user;
        }
    }
}
