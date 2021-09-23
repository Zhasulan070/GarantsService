using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Models;

namespace GarantsService.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderModel>> GetOrder(int userId, int positionId);
        public Task<Order> GetOrderByOrderId(int userId, int orderId);
        public Task<string> CreateOrder(Order createOrder);
    }
}