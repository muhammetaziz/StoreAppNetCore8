using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string City { get; set; } = null!;
        [BindNever]
        public CartsModel? CartsModel { get; set; } =null!;

    }
}
