using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;

namespace biznis.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartRepo;
        private readonly IProductRepository _productRepo;

        public CartItemService(ICartItemRepository cartRepo, IProductRepository productRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }

        public async Task<List<CartItemDto>> GetByUserAsync(Guid userPublicId)
        {
            var items = await _cartRepo.GetByUserPublicIdAsync(userPublicId);
            return items.Select(i => new CartItemDto
            {
                PublicId = i.PublicId,
                UserPublicId = i.UserId,
                ProductPublicId = i.Product.PublicId,
                ProductName = i.Product.Name,
                ProductPrice = i.Product.Price,
                Quantity = i.Quantity
            }).ToList();
        }

        public async Task<bool> AddAsync(CartItemCreateDto dto)
        {
            var product = await _productRepo.GetByPublicIdAsync(dto.ProductPublicId);
            if (product == null) return false;

            var entity = new CartItemEntity
            {
                PublicId = Guid.NewGuid(),
                UserId = dto.UserPublicId,
                ProductId = product.Id,
                Product = product,
                Quantity = dto.Quantity
            };
            await _cartRepo.CreateAsync(entity);
            await _cartRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(Guid publicId)
        {
            var item = await _cartRepo.GetByPublicIdAsync(publicId);
            if (item == null) return false;
            _cartRepo.Delete(item);
            await _cartRepo.SaveChangesAsync();
            return true;
        }
    }
}