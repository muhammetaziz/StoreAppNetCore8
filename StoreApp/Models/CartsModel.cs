using StoreApp.Data.Concrete;

namespace StoreApp.Models
{
    public class CartsModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            var items = Items.Where(p => p.Product.ProductId ==product.ProductId).FirstOrDefault();

            if (items == null)
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else { items.Quantity += 1; }
        }
        public void RemoveItem(Product product)
        {

            Items.RemoveAll(i=>i.Product.ProductId==product.ProductId);
        }
        public decimal CalculateTotal()
        {
            return Items.Sum(i=>i.Product.Price*i.Quantity);
        }
        public void Clear()
        {
            Items.Clear();
        }
    }
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}
