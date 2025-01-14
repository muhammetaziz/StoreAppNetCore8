using StoreApp.Data.Concrete;

namespace StoreApp.Models
{
    public class CartsModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public virtual void AddItem(Product product, int quantity)
        {
            var items = Items.Where(p => p.Product.ProductId ==product.ProductId).FirstOrDefault();

            if (items == null)
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else { items.Quantity += 1; }
        }
        public virtual void RemoveItem(Product product)
        {
            Items.RemoveAll(i=>i.Product.ProductId==product.ProductId);
            
        }
        public virtual void DecreaseItem(Product product)
        {
            var item = Items.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--; // Sadece miktarı azalt
                }
                else
                {
                    Items.Remove(item); // Miktar 1 ise ürünü tamamen kaldır
                }
            }
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(i=>i.Product.Price*i.Quantity);
        }
        public virtual void Clear()
        {
            Items.Clear();
        }
    }
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
