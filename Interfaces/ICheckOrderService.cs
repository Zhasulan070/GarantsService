using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Models;

namespace GarantsService.Interfaces
{
    public interface ICheckOrderService
    {
        public Task<List<OrderModel>> CheckOrder(long bin, string kl);
    }
}