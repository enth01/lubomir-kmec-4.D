using biznis.Interfaces.Repository;
using ClassLibrary1;
using ClassLibrary1.Entities;

namespace biznis.Repository
{
    public class ProductRepository(AppDbContext context) : BaseRepository<ProductEntity>(context), IProductRepository
    {
    }
}