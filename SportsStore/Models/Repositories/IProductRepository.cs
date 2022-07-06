using SportsStore.Models.Entities;

namespace SportsStore.Models.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
