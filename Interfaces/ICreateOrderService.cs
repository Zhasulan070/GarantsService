using System.Threading.Tasks;
using GarantsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace GarantsService.Interfaces
{
    public interface ICreateOrderService
    {
        public Task<string> CreateApp(OrderModel order);
    }
}