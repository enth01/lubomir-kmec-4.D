using biznis.Interfaces.Services;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service) => _service = service;

        [HttpGet("{userPublicId}")]
        public async Task<List<OrderDto>> GetByUser(Guid userPublicId)
            => await _service.GetByUserAsync(userPublicId);

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result ? Ok() : BadRequest("Cart is empty or user not found");
        }
    }
}