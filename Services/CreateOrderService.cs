using System;
using System.Threading.Tasks;
using GarantsService.Context;
using GarantsService.Interfaces;
using GarantsService.Models;

namespace GarantsService.Services
{
    public class CreateOrderService : ICreateOrderService
    {
        private DatabaseContext _context;

        public CreateOrderService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<string> CreateApp(OrderModel createOrder)
        {
            try
            {
                createOrder.Status = null;
                await _context.Database.BeginTransactionAsync();
                await _context.OrderModels.AddAsync(createOrder);
                await _context.SaveChangesAsync();
                _context.Database.CommitTransaction();
                return "Order added to DB";
                
            }
            catch (Exception e)
            {
                _context.Database.RollbackTransaction();
                return "Error with add order";
            }
            
        }
    }
}