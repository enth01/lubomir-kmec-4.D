using biznis.Interfaces.Services;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service) => _service = service;

        [HttpGet]
        public async Task<List<ProductDto>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{publicId}")]
        public async Task<IActionResult> GetById(Guid publicId)
        {
            var p = await _service.GetByPublicIdAsync(publicId);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            var result = await _service.UpdateAsync(dto);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{publicId}")]
        public async Task<IActionResult> Delete(Guid publicId)
        {
            var result = await _service.DeleteAsync(publicId);
            return result ? Ok() : NotFound();
        }
    }
}