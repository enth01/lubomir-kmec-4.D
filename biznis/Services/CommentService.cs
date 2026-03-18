using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;

namespace biznis.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IUserRepository _userRepo;
        private readonly IProductRepository _productRepo;

        public CommentService(ICommentRepository commentRepo, IUserRepository userRepo, IProductRepository productRepo)
        {
            _commentRepo = commentRepo;
            _userRepo = userRepo;
            _productRepo = productRepo;
        }

        public async Task<List<CommentDto>> GetByProductAsync(Guid productPublicId)
        {
            var comments = await _commentRepo.GetByProductPublicIdAsync(productPublicId);
            return comments.Select(c => new CommentDto
            {
                PublicId = c.PublicId,
                UserPublicId = c.User.PublicId,
                ProductPublicId = c.Product.PublicId,
                Text = c.Text
            }).ToList();
        }

        public async Task<bool> CreateAsync(CommentCreateDto dto)
        {
            var user = await _userRepo.GetByPublicIdAsync(dto.UserPublicId);
            var product = await _productRepo.GetByPublicIdAsync(dto.ProductPublicId);
            if (user == null || product == null) return false;

            var entity = new CommentEntity
            {
                PublicId = Guid.NewGuid(),
                User = user,
                UserId = user.Id,
                Product = product,
                ProductId = product.Id,
                Text = dto.Text
            };
            await _commentRepo.CreateAsync(entity);
            await _commentRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var c = await _commentRepo.GetByPublicIdAsync(publicId);
            if (c == null) return false;
            _commentRepo.Delete(c);
            await _commentRepo.SaveChangesAsync();
            return true;
        }
    }
}