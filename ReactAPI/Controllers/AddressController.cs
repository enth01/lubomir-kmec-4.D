using biznis.Interfaces.Services;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IUserAddressService _service;
        public AddressController(IUserAddressService service) => _service = service;

        [HttpGet("{userPublicId}")]
        public async Task<List<UserAddressDto>> GetByUser(Guid userPublicId)
            => await _service.GetByUserAsync(userPublicId);

        [HttpPost]
        public async Task<IActionResult> Create(UserAddressCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result ? Ok() : BadRequest("User not found");
        }

        [HttpDelete("{publicId}")]
        public async Task<IActionResult> Delete(Guid publicId)
        {
            var result = await _service.DeleteAsync(publicId);
            return result ? Ok() : NotFound();
        }
    }
}