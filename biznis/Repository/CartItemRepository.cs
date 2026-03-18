using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace biznis.Repository
{
    public class CartItemRepository(AppDbContext context)
        : BaseRepository<CartItemEntity>(context), ICartItemRepository
    {
        public async Task<List<CartItemEntity>> GetByUserPublicIdAsync(Guid userPublicId)
        {
            return await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userPublicId)
                .ToListAsync();
        }
    }
}