using ClassLibrary1.Entities;
using Common.Dto;
using Common.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace biznis.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll(CategoryEnum? category = null);
        Task<ProductDto?> GetByPublicId(Guid publicId);
        Task<ProductDto> AddAsync(ProductCreateDto dto);
        Task<ProductDto?> UpdateAsync(ProductUpdateDto dto);
        Task<bool> AddToBasket(CartItemDto dto);
        Task<List<CartItemDto>> GetAllCartItems(Guid userPublicId);
        Task<bool> DeleteAsync(Guid publicId);
    }
}
