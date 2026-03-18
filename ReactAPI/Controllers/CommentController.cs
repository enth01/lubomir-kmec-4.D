using biznis.Interfaces.Services;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service) => _service = service;

        [HttpGet("{productPublicId}")]
        public async Task<List<CommentDto>> GetByProduct(Guid productPublicId)
            => await _service.GetByProductAsync(productPublicId);

        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result ? Ok() : BadRequest("User or product not found");
        }

        [HttpDelete("{publicId}")]
        public async Task<IActionResult> Delete(Guid publicId)
        {
            var result = await _service.DeleteAsync(publicId);
            return result ? Ok() : NotFound();
        }
    }
}