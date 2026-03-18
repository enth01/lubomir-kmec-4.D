using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Microsoft.EntityFrameworkCore;

namespace biznis.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByPublicIdAsync(Guid publicId)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.PublicId == publicId);
        }

        public virtual async Task<bool> CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            return true;
        }

        public Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            return Task.FromResult(true);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
