using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;
using Common.Enum;
using WebApplication1.Models;

namespace biznis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> CreateAsync(UserCreateDto dto)
        {
            var existing = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.Email == dto.Email);

            if (existing != null)
                throw new Exception("Email already exists");

            var user = new UserEntity
            {
                PublicId = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role = RoleEnum.user
            };

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(Guid publicId, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByPublicIdAsync(publicId);
            if (user == null) return false;

            if (!string.IsNullOrWhiteSpace(dto.Name))
                user.Name = dto.Name;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Password))
                user.Password = dto.Password;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }


        public async Task<bool> CreateAsync(string name, string email)
            => await CreateAsync(name, email, "");

        public async Task<bool> CreateAsync(string name, string email, string password)
        {
            var existing = (await _userRepository.GetAllAsync())
                .FirstOrDefault(u => u.Email == email);

            if (existing != null) return false;

            var user = new UserEntity
            {
                PublicId = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password,
                Role = RoleEnum.user
            };

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid publicId, string name, string email)
            => await UpdateAsync(publicId, name, email, "");

        public async Task<bool> UpdateAsync(Guid publicId, string name, string email, string password)
        {
            var user = await _userRepository.GetByPublicIdAsync(publicId);
            if (user == null) return false;

            if (!string.IsNullOrWhiteSpace(name))
                user.Name = name;

            if (!string.IsNullOrWhiteSpace(email))
                user.Email = email;

            if (!string.IsNullOrWhiteSpace(password))
                user.Password = password;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }


        public async Task<UserEntity?> AuthenticateAsync(string email, string password)
        {
            var users = await _userRepository.GetAllAsync();
            return users.FirstOrDefault(u =>
                u.Email == email && u.Password == password);
        }

        public async Task<UserEntity?> GetByPublicIdAsync(Guid publicId)
        {
            return await _userRepository.GetByPublicIdAsync(publicId);
        }

        public async Task<UserDto?> GetDtoByPublicIdAsync(Guid publicId)
        {
            var user = await _userRepository.GetByPublicIdAsync(publicId);
            if (user == null) return null;

            return new UserDto
            {
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new User
            {
                PublicId = u.PublicId,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var user = await _userRepository.GetByPublicIdAsync(publicId);
            if (user == null) return false;

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public bool IsAdmin(Guid userPublicId)
        {
            var user = _userRepository.GetByPublicIdAsync(userPublicId).Result;
            return user != null && user.Role == RoleEnum.admin;
        }

        public List<UserEntity> GetAllForAdmin()
            => _userRepository.GetAllAsync().Result;

        public bool DeleteByPublicId(Guid publicId)
        {
            var user = _userRepository.GetByPublicIdAsync(publicId).Result;
            if (user == null) return false;

            _userRepository.Delete(user);
            _userRepository.SaveChangesAsync().Wait();
            return true;
        }
    }
}
