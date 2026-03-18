using ClassLibrary1.Entities;

namespace biznis.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
    }
}
