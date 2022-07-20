using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.Entities;
using SportsStore.Models.Repositories;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private Cart _cart;

        public OrderController(IOrderRepository repository, Cart cartService)
        {
            _repository = repository;
            _cart = cartService;
        }

        [Authorize]
        public IActionResult List()
        {
            return View(_repository.Orders.Where(o => !o.Shipped));
        }

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = _repository.Orders.FirstOrDefault(o => o.OrderID == orderID);

            if (order != null)
            {
                order.Shipped = true;
                _repository.SaveOrder(order);
            }

            return RedirectToAction(nameof(List));
        }

        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empry!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }

            else
            {
                return View(order);
            }
        }

        public IActionResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}
