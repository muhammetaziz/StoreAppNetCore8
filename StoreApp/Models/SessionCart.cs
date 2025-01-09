using System.Text.Json.Serialization;
using StoreApp.Data.Concrete;
using StoreApp.Helpers;

namespace StoreApp.Models
{
    public class SessionCart : CartsModel
    {
        public static CartsModel GetCarts(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession? Session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson("Cart", this);

        }
        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session?.SetJson("Cart", this);
        }
        public override void DecreaseItem(Product product)
        {
            base.DecreaseItem(product); // Ana işlevi çağır
            Session?.SetJson("Cart", this); // Güncellenmiş sepeti oturuma kaydet
        }


        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Cart");
        }
    }
}
