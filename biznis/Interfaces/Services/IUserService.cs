using ClassLibrary1.Entities;
using Common.Dto;
using WebApplication1.Models;

namespace biznis.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> CreateAsync(UserCreateDto dto);
        Task<bool> UpdateAsync(Guid publicId, UserUpdateDto dto);

        Task<bool> CreateAsync(string name, string email);
        Task<bool> CreateAsync(string name, string email, string password);
        Task<bool> UpdateAsync(Guid publicId, string name, string email);
        Task<bool> UpdateAsync(Guid publicId, string name, string email, string password);

        Task<UserEntity?> AuthenticateAsync(string email, string password);
        Task<UserEntity?> GetByPublicIdAsync(Guid publicId);
        Task<UserDto?> GetDtoByPublicIdAsync(Guid publicId);
        Task<List<User>> GetAllAsync();
        Task<bool> DeleteAsync(Guid publicId);

        bool IsAdmin(Guid userPublicId);
        List<UserEntity> GetAllForAdmin();
        bool DeleteByPublicId(Guid publicId);
    }
}
