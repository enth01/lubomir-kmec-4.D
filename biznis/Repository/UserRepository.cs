using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace biznis.Repository
{
    public class UserRepository(AppDbContext context) : BaseRepository<UserEntity>(context), IUserRepository
    {
        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
