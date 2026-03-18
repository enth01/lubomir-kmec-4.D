using ClassLibrary1.Entities;

namespace biznis.Interfaces.Repository
{
    public interface IUserAddressRepository : IBaseRepository<UserAddressEntity>
    {
        Task<List<UserAddressEntity>> GetByUserPublicIdAsync(Guid userPublicId);
    }
}