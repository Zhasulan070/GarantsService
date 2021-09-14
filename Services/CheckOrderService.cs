using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarantsService.Interfaces;
using GarantsService.Models;
using GarantsService.Context;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Services
{
    public class CheckOrderService : ICheckOrderService
    {
        private readonly DatabaseContext _context;

        public CheckOrderService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<OrderModel>> CheckOrder(long bin, string kl)
        {
            var list = await _context.OrderModels.Where(x => x.Bin == bin && x.Kl == kl && x.Status == true).ToListAsync();
            return list;
        }
    }
}