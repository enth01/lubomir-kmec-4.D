using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;

namespace biznis.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo) => _repo = repo;

        private static ProductDto ToDto(ProductEntity p) => new()
        {
            PublicId = p.PublicId,
            Name = p.Name,
            Info = p.Info,
            Price = p.Price,
            Categories = p.Categories
        };

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(ToDto).ToList();
        }

        public async Task<ProductDto?> GetByPublicIdAsync(Guid publicId)
        {
            var p = await _repo.GetByPublicIdAsync(publicId);
            return p == null ? null : ToDto(p);
        }

        public async Task<bool> CreateAsync(ProductCreateDto dto)
        {
            var entity = new ProductEntity
            {
                PublicId = Guid.NewGuid(),
                Name = dto.Name,
                Info = dto.Info,
                Price = dto.Price,
                Categories = dto.Categories
            };
            await _repo.CreateAsync(entity);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(ProductUpdateDto dto)
        {
            var p = await _repo.GetByPublicIdAsync(dto.PublicId);
            if (p == null) return false;

            if (dto.Name != null) p.Name = dto.Name;
            if (dto.Info != null) p.Info = dto.Info;
            if (dto.Price.HasValue) p.Price = dto.Price.Value;
            if (dto.Categories != null) p.Categories = dto.Categories;

            await _repo.UpdateAsync(p);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var p = await _repo.GetByPublicIdAsync(publicId);
            if (p == null) return false;
            _repo.Delete(p);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}