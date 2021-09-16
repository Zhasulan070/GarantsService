using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarantsService.Context;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Services
{
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<List<OrderModel>> CheckOrder(int userId)
        {
            var list = await _context.OrderModels.Where(x => x.UserId == userId).ToListAsync();
            return list;
        }
        
        public async Task<string> CreateOrder(OrderModel createOrder)
        {
            try
            {
                createOrder.Status = false;
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