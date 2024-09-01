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
            try
            {
                var createdUser = await _userService.CreateUser(CreateUserDto.ToDto(user));

                if(createdUser.Status == 500)
                {
                    return Ok(new DefaultReturnDto<int>()
                    {
                        Status = 500,
                        Message = createdUser.Message,
                        Data = 0
                    });
                }

                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Data.Id }, new DefaultReturnDto<User>()
                {
                    Status = 201,
                    Message = createdUser.Message,
                    Data = createdUser.Data 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500,new DefaultReturnDto<int>()
                {
                    Status = 500,
                    Message = "Internal Error",
                    Data = 0
                });
            }
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
                return NotFound(new DefaultReturnDto<int>()
                {
                    Status = 404,
                    Message = "The user was not found",
                    Data = 0
                });
            }
            return Ok(new DefaultReturnDto<User>()
            {
                Status = 200,
                Message = "User successfully updated",
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
                Message = "User successfully deleted",
                Data = user
            });
        }
    }
}
