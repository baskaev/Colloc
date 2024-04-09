using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders = new List<Order>();

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }

        public Order GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public void EditOrder(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder != null)
            {
                existingOrder.FullName = order.FullName;
                existingOrder.PhoneNumber = order.PhoneNumber;
                existingOrder.OrderType = order.OrderType;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.Status = order.Status;
            }
        }
    }
}
