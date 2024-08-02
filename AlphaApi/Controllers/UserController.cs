using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Domain;
using Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlphaApi.Dto;

namespace AlphaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Create
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto user)
        {
            var createdUser = await _userService.CreateUser(CreateUserDto.ToDto(user));
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, new DefaultReturnDto<User>()
            {
                Status = 200,
                Message = "User successfully created",
                Data = createdUser
            });
        }

        // Read
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        //{
        //    var users = await _userService.GetAllUsers();
        //    return Ok(users);
        //}

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            if(id != userDto.Id)
            {
                return BadRequest(new DefaultReturnDto<int>()
                {
                    Status = 401,
                    Message = "Bad Communication",
                    Data = 0
                });
            }

            var user = await _userService.GetUserById(id);
            var updatedUser = await _userService.UpdateUser(UpdateUserDto.ToDto(userDto,user));
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(new DefaultReturnDto<User>()
            {
                Status = 200,
                Message = "User successfuly updated",
                Data = updatedUser
            });
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(id);
            return Ok(new DefaultReturnDto<User>()
            {
                Status = 200,
                Message = "User successfuly deleted",
                Data = user
            });
        }
    }
}
