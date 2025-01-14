using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Data.Concrete;

namespace StoreApp.Pages
{
    public class ComplatedModel : PageModel
    {
        private readonly IOrderRepository _OrderRepository;

        public ComplatedModel(IOrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string? OrderId { get; set; }

        public Order? Order { get; set; }

        //public void OnGet()
        //{
        //    if (!string.IsNullOrEmpty(OrderId))
        //    {
        //        Order = _OrderRepository.GetOrderById(OrderId);
        //    }
        //}
    }
}
