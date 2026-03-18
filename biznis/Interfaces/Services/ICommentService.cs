using Common.Dto;

namespace biznis.Interfaces.Services
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetByProductAsync(Guid productPublicId);
        Task<bool> CreateAsync(CommentCreateDto dto);
        Task<bool> DeleteAsync(Guid publicId);
    }
}