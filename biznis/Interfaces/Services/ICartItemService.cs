using Common.Dto;

namespace biznis.Interfaces.Services
{
    public interface ICartItemService
    {
        Task<List<CartItemDto>> GetByUserAsync(Guid userPublicId);
        Task<bool> AddAsync(CartItemCreateDto dto);
        Task<bool> RemoveAsync(Guid publicId);
    }
}