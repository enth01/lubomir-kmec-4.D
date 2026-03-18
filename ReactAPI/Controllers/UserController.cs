using biznis.Interfaces.Services;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            var user = await _userService.CreateAsync(dto);
            if (!user) return BadRequest("Email already in use");
            var created = await _userService.GetByEmailAsync(dto.Email);
            return Ok(created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto.Email, dto.Password);
            if (user == null) return Unauthorized("Invalid credentials");
            return Ok(user);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(UserUpdateDto dto)
        {
            var result = await _userService.UpdateAsync(dto);
            if (!result) return BadRequest("Update failed");
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid publicId)
        {
            var result = await _userService.DeleteAsync(publicId);
            if (!result) return NotFound();
            return Ok();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}