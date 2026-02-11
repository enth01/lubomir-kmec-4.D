using ClassLibrary1.Entities;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace biznis.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllAsync();
        Task<ProductEntity?> GetByPublicIdAsync(Guid publicId);
        Task AddAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
        void Delete(ProductEntity product);
        Task AddToCart(CartItemEntity cartItem);
        Task<List<CartItemEntity>> GetAllCartItemsAsync();
        Task<CartItemEntity?> GetCartItemAsync(Guid id);
        Task SaveChangesAsync();
    }
}
