using ClassLibrary1.Entities;

namespace biznis.Interfaces.Repository
{
    public interface ICommentRepository : IBaseRepository<CommentEntity>
    {
        Task<List<CommentEntity>> GetByProductPublicIdAsync(Guid productPublicId);
    }
}