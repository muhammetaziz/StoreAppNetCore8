using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Components
{
    public class CartSummeryViewComponenet:ViewComponent
    {
        private CartsModel Cart;
        public CartSummeryViewComponenet(CartsModel cartService)
        {
            Cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(Cart);
        }
    }
}
