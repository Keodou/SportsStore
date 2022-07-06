using SportsStore.Models.Entities;

namespace SportsStore.Models.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}
