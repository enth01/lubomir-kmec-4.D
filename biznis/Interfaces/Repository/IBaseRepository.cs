using ClassLibrary1.Entities;

namespace biznis.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByPublicIdAsync(Guid publicId);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
