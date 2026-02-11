using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;
using Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace biznis.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<ProductEntity?> GetByPublicIdAsync(Guid publicId)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.PublicId == publicId);
        }

        public async Task AddAsync(ProductEntity product)
        {
            await _db.Products.AddAsync(product);
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            _db.Products.Update(product);
        }

        public void Delete(ProductEntity product)
        {
            _db.Products.Remove(product);
        }

        public async Task AddToCart(CartItemEntity cartItem)
        {
            await _db.CartItems.AddAsync(cartItem);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<CartItemEntity?> GetCartItemAsync(Guid id)
        {
            return await _db.CartItems.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<List<CartItemEntity>> GetAllCartItemsAsync()
        {
            return await _db.CartItems.ToListAsync();
        }
    }
}
