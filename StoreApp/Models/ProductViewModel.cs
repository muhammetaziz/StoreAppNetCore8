using StoreApp.Models;

namespace StoreApp.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ProductImage { get; set; } = string.Empty;
    }
}

public class ProductListViewModel
{
    public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    public PageInfo PageInfo { get; set; } = new();
}
public class PageInfo
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)(TotalItems / ItemsPerPage));
}