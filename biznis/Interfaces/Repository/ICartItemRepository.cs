using ClassLibrary1.Entities;

namespace biznis.Interfaces.Repository
{
    public interface ICartItemRepository : IBaseRepository<CartItemEntity>
    {
        Task<List<CartItemEntity>> GetByUserPublicIdAsync(Guid userPublicId);
    }
}