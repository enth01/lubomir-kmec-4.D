using Common.Dto;

namespace biznis.Interfaces.Services
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetByUserAsync(Guid userPublicId);
        Task<bool> CreateAsync(OrderCreateDto dto);
    }
}