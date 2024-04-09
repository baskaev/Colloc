using System.Collections.Generic;

namespace WebApplication1.Models.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void EditOrder(Order order);
    }
}
