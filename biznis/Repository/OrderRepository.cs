using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace biznis.Repository
{
    public class OrderRepository(AppDbContext context)
        : BaseRepository<OrderEntity>(context), IOrderRepository
    {
        public async Task<List<OrderEntity>> GetByUserPublicIdAsync(Guid userPublicId)
        {
            return await _context.Orders
                .Include(o => o.Items).ThenInclude(i => i.Product)
                .Include(o => o.Address)
                .Where(o => o.UserPublicId == userPublicId)
                .ToListAsync();
        }
    }
}