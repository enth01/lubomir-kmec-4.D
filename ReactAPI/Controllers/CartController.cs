using biznis.Interfaces.Services;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartItemService _service;
        public CartController(ICartItemService service) => _service = service;

        [HttpGet("{userPublicId}")]
        public async Task<List<CartItemDto>> GetByUser(Guid userPublicId)
            => await _service.GetByUserAsync(userPublicId);

        [HttpPost]
        public async Task<IActionResult> Add(CartItemCreateDto dto)
        {
            var result = await _service.AddAsync(dto);
            return result ? Ok() : BadRequest("Product not found");
        }

        [HttpDelete("{publicId}")]
        public async Task<IActionResult> Remove(Guid publicId)
        {
            var result = await _service.RemoveAsync(publicId);
            return result ? Ok() : NotFound();
        }
    }
}