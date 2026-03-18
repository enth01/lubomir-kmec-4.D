using Common.Dto;

namespace biznis.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByPublicIdAsync(Guid publicId);
        Task<bool> CreateAsync(ProductCreateDto dto);
        Task<bool> UpdateAsync(ProductUpdateDto dto);
        Task<bool> DeleteAsync(Guid publicId);
    }
}