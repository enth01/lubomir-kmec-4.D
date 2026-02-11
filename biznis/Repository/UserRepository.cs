using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace biznis.Repository
{
    public class UserRepository(AppDbContext context) : BaseRepository<UserEntity>(context), IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
