using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace biznis.Repository
{
    public class CommentRepository(AppDbContext context) : BaseRepository<CommentEntity>(context), ICommentRepository
    {
        public async Task<List<CommentEntity>> GetByProductPublicIdAsync(Guid productPublicId)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Product)
                .Where(c => c.Product.PublicId == productPublicId)
                .ToListAsync();
        }
    }
}