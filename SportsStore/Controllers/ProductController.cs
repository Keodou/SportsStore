using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Repositories;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int pageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List(string category, int productPage = 1)
        {
            return View(new ProductsListViewModel { 
                Products = _repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                        _repository.Products.Count() : 
                        _repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });
        }
    }   
}
