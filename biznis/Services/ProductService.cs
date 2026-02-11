using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;
using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace biznis.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProductDto>> GetAll(CategoryEnum? category = null)
        {
            var products = await _repo.GetAllAsync();

            if (category.HasValue)
                products = products.Where(p => p.Categories.Contains(category.Value)).ToList();

            return products.Select(p => new ProductDto
            {
                PublicId = p.PublicId,
                Name = p.Name,
                Info = p.Info,
                Categories = p.Categories,
                Price = p.Price
            }).ToList();
        }

        public async Task<ProductDto?> GetByPublicId(Guid publicId)
        {
            var product = await _repo.GetByPublicIdAsync(publicId);
            if (product == null) return null;

            return new ProductDto
            {
                PublicId = product.PublicId,
                Name = product.Name,
                Info = product.Info,
                Categories = product.Categories,
                Price = product.Price
            };
        }

        public async Task<ProductDto> AddAsync(ProductCreateDto dto)
        {
            var entity = new ProductEntity
            {
                PublicId = Guid.NewGuid(),
                Name = dto.Name,
                Info = dto.Info,
                Categories = dto.Categories,
                Price = dto.Price
            };

            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();

            return new ProductDto
            {
                PublicId = entity.PublicId,
                Name = entity.Name,
                Info = entity.Info,
                Categories = entity.Categories,
                Price = entity.Price
            };
        }

        public async Task<ProductDto?> UpdateAsync(ProductUpdateDto dto)
        {
            var product = await _repo.GetByPublicIdAsync(dto.PublicId);
            if (product == null) return null;

            if (!string.IsNullOrWhiteSpace(dto.Name)) product.Name = dto.Name;
            if (!string.IsNullOrWhiteSpace(dto.Info)) product.Info = dto.Info;
            if (dto.Categories != null) product.Categories = dto.Categories;
            if (dto.Price.HasValue) product.Price = dto.Price.Value;

            await _repo.UpdateAsync(product);
            await _repo.SaveChangesAsync();

            return new ProductDto
            {
                PublicId = product.PublicId,
                Name = product.Name,
                Info = product.Info,
                Categories = product.Categories,
                Price = product.Price
            };
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var product = await _repo.GetByPublicIdAsync(publicId);
            if (product == null) return false;

            _repo.Delete(product);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddToBasket(CartItemDto dto)
        {
            var product = await _repo.GetByPublicIdAsync(dto.productPublicId);
            var cartItem = await _repo.GetCartItemAsync(dto.productPublicId);
            if (cartItem == null)
            {
                var cartItemEntity = new CartItemEntity { Product = product, Quantity = 1, UserId = dto.userPublicId };
                await _repo.AddToCart(cartItemEntity);
            }
            else
            {
                cartItem.Quantity += 1;
            }
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<List<CartItemDto>> GetAllCartItems(Guid userPublicId)
        {
            var cartItemList = await _repo.GetAllCartItemsAsync();
            var cartItems = new List<CartItemDto>();
            for (int i = 0; i < cartItemList.Count; i++)
            {
                
                var cartItem = cartItemList[i];
                var productPublicId = cartItem.ProductId;
                var dto = new CartItemDto { productPublicId = productPublicId, userPublicId = userPublicId };
                cartItems.Add(dto);
            }
            return cartItems;
        }
    }
}
