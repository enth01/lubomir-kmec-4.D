using ClassLibrary1.Entities;

namespace biznis.Interfaces.Repository
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        Task<List<OrderEntity>> GetByUserPublicIdAsync(Guid userPublicId);
    }
}