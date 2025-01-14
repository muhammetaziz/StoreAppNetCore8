using StoreApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Concrete
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _context;

        public EfOrderRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> Orders => _context.Orders;
         
        public void SaveOrder(Order order)
        {
            _context.Orders.AddAsync(order);
            _context.SaveChangesAsync();
        }
        
        public Order GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
