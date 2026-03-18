using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace biznis.Repository
{
    public class UserAddressRepository(AppDbContext context)
        : BaseRepository<UserAddressEntity>(context), IUserAddressRepository
    {
        public async Task<List<UserAddressEntity>> GetByUserPublicIdAsync(Guid userPublicId)
        {
            return await _context.UserAddresses
                .Include(a => a.User)
                .Where(a => a.User.PublicId == userPublicId)
                .ToListAsync();
        }
    }
}