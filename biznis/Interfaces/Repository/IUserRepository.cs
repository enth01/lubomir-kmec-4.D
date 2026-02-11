using ClassLibrary1.Entities;
using System.Threading.Tasks;

namespace biznis.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
    }
}
