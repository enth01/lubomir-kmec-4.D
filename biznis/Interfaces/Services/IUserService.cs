using Common.Dto;

namespace biznis.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByPublicIdAsync(Guid publicId);
        Task<bool> CreateAsync(UserCreateDto userCreateDto);
        Task<bool> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteAsync(Guid publicId);
        Task<UserDto?> GetByEmailAsync(string email);
        Task<UserDto?> LoginAsync(string email, string password);
    }
}
