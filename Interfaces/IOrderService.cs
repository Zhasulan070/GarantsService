using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Models;

namespace GarantsService.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderModel>> CheckOrder(int userId);
        public Task<string> CreateOrder(OrderModel createOrder);
    }
}