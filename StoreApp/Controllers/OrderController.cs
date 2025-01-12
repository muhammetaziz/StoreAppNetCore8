using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly CartsModel cart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(CartsModel cartService, IOrderRepository orderRepository)
        {
            cart = cartService;
            _orderRepository = orderRepository;
        }

        public IActionResult Checkout()
        {

            return View(new OrderModel() { CartsModel = cart });
        }
        [HttpPost]
        public IActionResult Checkout(OrderModel orderModel)
        {
            if (cart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Sepetinizde ürün bulunmamaktadır.");

            }
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    Name = orderModel.Name,
                    Address = orderModel.Address,
                    Email = orderModel.Email,
                    Phone = orderModel.Phone,
                    City = orderModel.City,
                    
                    OrderItems = cart.Items.Select(i => new OrderItem()
                    {
                        ProductId = i.Product.ProductId,
                        Price = (double)i.Product.Price,
                        Quantity = i.Quantity
                    }).ToList()
                };
                _orderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Complated", new {OrderId=order.OrderId});
            }
            else
            {
                orderModel.CartsModel = cart;
                return View(orderModel);
            }

        }
    }
}
