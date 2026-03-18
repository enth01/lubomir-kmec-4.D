using biznis.Interfaces.Repository;
using biznis.Interfaces.Services;
using ClassLibrary1.Entities;
using Common.Dto;

namespace biznis.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository _addressRepo;
        private readonly IUserRepository _userRepo;

        public UserAddressService(IUserAddressRepository addressRepo, IUserRepository userRepo)
        {
            _addressRepo = addressRepo;
            _userRepo = userRepo;
        }

        public async Task<List<UserAddressDto>> GetByUserAsync(Guid userPublicId)
        {
            var addresses = await _addressRepo.GetByUserPublicIdAsync(userPublicId);
            return addresses.Select(a => new UserAddressDto
            {
                PublicId = a.PublicId,
                UserPublicId = a.User.PublicId,
                Street = a.Street,
                HouseNumber = a.HouseNumber,
                City = a.City,
                Country = a.Country,
                PostalCode = a.PostalCode
            }).ToList();
        }

        public async Task<bool> CreateAsync(UserAddressCreateDto dto)
        {
            var user = await _userRepo.GetByPublicIdAsync(dto.UserPublicId);
            if (user == null) return false;

            var entity = new UserAddressEntity
            {
                PublicId = Guid.NewGuid(),
                User = user,
                UserId = user.Id,
                Street = dto.Street,
                HouseNumber = dto.HouseNumber,
                City = dto.City,
                Country = dto.Country,
                PostalCode = dto.PostalCode
            };
            await _addressRepo.CreateAsync(entity);
            await _addressRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid publicId)
        {
            var a = await _addressRepo.GetByPublicIdAsync(publicId);
            if (a == null) return false;
            _addressRepo.Delete(a);
            await _addressRepo.SaveChangesAsync();
            return true;
        }
    }
}