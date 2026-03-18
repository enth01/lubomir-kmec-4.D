using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;
using Common.Enum;

namespace biznis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDto
            {
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            }).ToList();
        }

        public async Task<UserDto?> GetByPublicIdAsync(Guid publicId)
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

        public async Task<bool> CreateAsync(UserCreateDto userCreateDto)
        {
            var user = await _userRepository.GetByEmailAsync(userCreateDto.Email);
            if (user != null) return false;

            var userEntity = new UserEntity
            {
                PublicId = Guid.NewGuid(),
                Name = userCreateDto.Name,
                Email = userCreateDto.Email,
                Password = userCreateDto.Password,
                Role = RoleEnum.user
            };

            await _userRepository.CreateAsync(userEntity);
            await _userRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetByPublicIdAsync(userUpdateDto.PublicId);
            if (user == null) return false;

            if (userUpdateDto.Email != null)
            {
                var user_for_checking_mail = await _userRepository.GetByEmailAsync(userUpdateDto.Email);
                if (user_for_checking_mail != null) return false;
            }

            if (userUpdateDto.Name != null) user.Name = userUpdateDto.Name;
            if (userUpdateDto.Email != null) user.Email = userUpdateDto.Email;
            if (userUpdateDto.Password != null) user.Password = userUpdateDto.Password;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var user = await _userRepository.GetByPublicIdAsync(publicId);
            if (user == null) return false;

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return null;

            return new UserDto
            {
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<UserDto?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || user.Password != password) return null;

            return new UserDto
            {
                PublicId = user.PublicId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
