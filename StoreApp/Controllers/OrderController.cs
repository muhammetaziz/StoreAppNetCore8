using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly CartsModel cart;
        public OrderController(CartsModel cartservice)
        {
            cart = cartservice;
        }
        public IActionResult Checkout()
        {

            return View(new OrderModel() { CartsModel=cart});
        }
    }
}
