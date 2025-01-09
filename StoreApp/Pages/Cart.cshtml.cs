using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Helpers;
using StoreApp.Models;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IStoreRepository _repository;

        public CartModel(IStoreRepository repository,CartsModel cartService)
        {
             
            _repository = repository;
            Cart = cartService;
        }
        public CartsModel? Cart { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int id)
        {
            var product = _repository.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                Cart?.AddItem(product, 1);
            }
            return RedirectToPage("/cart");
        }
          
        public IActionResult OnPostRemove(int id)
        {
            Cart?.RemoveItem(Cart.Items.First(p => p.Product.ProductId == id).Product);
            return RedirectToPage("/cart"); 
        }
        public IActionResult OnPostDecrease(int id)
        {
            var product = Cart?.Items.FirstOrDefault(p => p.Product.ProductId == id)?.Product;

            if (product != null)
            {
                Cart?.DecreaseItem(product); // Miktarý azalt
            }
            return RedirectToPage("/cart");
        }



    }
}
