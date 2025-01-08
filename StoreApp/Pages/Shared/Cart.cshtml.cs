using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Helpers;
using StoreApp.Models;

namespace StoreApp.Pages.Shared
{
    public class CartModel : PageModel
    {
        private readonly IStoreRepository _repository;

        public CartModel(IStoreRepository repository)
        {
            _repository = repository;
        }
        public CartsModel? Cart { get; set; }
        public void OnGet()
        {
            Cart = HttpContext.Session.GetJson<CartsModel>("cart") ?? new CartsModel();
        }
        public IActionResult OnPost(int id)
        {
            var product = _repository.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<CartsModel>("cart") ?? new CartsModel();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart" ,Cart);
            }
            return RedirectToPage("/cart");
        }
    }
}
