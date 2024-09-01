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
                if (result.Status != 200)
                {
                    return NotFound(DefaultReturnDto<Dictionary<string, object>>.ToDto(result.Status, result.Message, new Dictionary<string, object>
                    {
                        { "Data", result.Data },
                    }));
                }

                var user = await _userService.GetUserByField("Email", loginDto.Email);
                var isActive = await _userService.IsActive(user);

                if (!isActive.Data)
                {
                    return NotFound(DefaultReturnDto<Dictionary<string, object>>.ToDto(isActive.Status, isActive.Message, new Dictionary<string, object>
                    {
                        { "Data", result.Data },
                    }));
                }

                return Ok(DefaultReturnDto<Dictionary<string, object>>.ToDto(200, "Logged", new Dictionary<string, object>
                {
                    { "Token", result.Data },
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
