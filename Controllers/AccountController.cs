using bobsbodymetrics.Dtos.Account;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bobsbodymetrics.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // No need to convert to lower case if UserManager is case insensitive by default.
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            var token = _tokenService.CreateToken(user);

            HttpContext.Response.Cookies.Append("token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Set to true in production
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddDays(7)
            });

            return Ok(
                new NewUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                }
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        var token = _tokenService.CreateToken(appUser);

                        // Set the token as an HTTP-only cookie
                        HttpContext.Response.Cookies.Append("token", token, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true, // Set to true in production
                            SameSite = SameSiteMode.Strict,
                            Expires = DateTime.Now.AddDays(7)
                        });

                        return Ok(
                            new NewUserDto
                            {
                                Id = appUser.Id,
                                UserName = appUser.UserName,
                                Email = appUser.Email
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}