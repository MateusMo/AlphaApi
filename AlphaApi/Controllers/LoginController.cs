using AlphaApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Services.Domain;
using Services.Services;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AlphaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public LoginController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] PostLoginDto loginDto)
        {
            try
            {
                var result = await _loginService.AuthenticateAsync(loginDto.Email, loginDto.Password);
                if (result == null)
                {
                    return NotFound(DefaultReturnDto<int>.ToDto(401, "User not found", 0));
                }
                var user = await _userService.GetUserByField("Password", loginDto.Password);
                if (user == null)
                {
                    return NotFound(DefaultReturnDto<int>.ToDto(401, "User not found", 0));
                }

                return Ok(DefaultReturnDto<Dictionary<string, object>>.ToDto(200, "Logged", new Dictionary<string, object>
                {
                    { "Token", result },
                    { "User", user }
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, DefaultReturnDto<int>.ToDto(500, "System Error", 0));
            }
        }
    }
}
