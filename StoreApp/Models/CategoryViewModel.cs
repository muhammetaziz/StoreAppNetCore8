using StoreApp.Data.Concrete;

namespace StoreApp.Models
{
    public class CategoryViewModel
    {

        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;// Arama Yapma için.
    }
}
