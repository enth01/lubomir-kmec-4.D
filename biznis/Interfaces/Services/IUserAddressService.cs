using Common.Dto;

namespace biznis.Interfaces.Services
{
    public interface IUserAddressService
    {
        Task<List<UserAddressDto>> GetByUserAsync(Guid userPublicId);
        Task<bool> CreateAsync(UserAddressCreateDto dto);
        Task<bool> DeleteAsync(Guid publicId);
    }
}