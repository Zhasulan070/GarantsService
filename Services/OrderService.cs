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
        
        public async Task<List<OrderModel>> GetOrder(int userId, int positionId)
        {
            var data = $"CALL GetOrderListByUserId({userId}, {positionId})";
            return await _context.OrderModels.FromSqlRaw(data).ToListAsync();
        }

        public async Task<Order> GetOrderByOrderId(int userId, int orderId)
        {
            FormattableString data = $"CALL GetOrderListByUserIdAndOrderId({userId}, {orderId})";
            var orderModels = await _context.OrderModelWithKl.FromSqlInterpolated(data).ToListAsync();
            var klList = new List<KlArray>();
            var order = new Order();
            foreach (var orderModel in orderModels)
            {
                var kl = new KlArray
                {
                    id = orderModel.Id,
                    kl_type = orderModel.KlNumber,
                    summa = orderModel.Summ,
                    currency = orderModel.CurrencyId,
                    CurrencyName = orderModel.CurrencyName,
                    validDate = orderModel.Mounth
                };
                klList.Add(kl);
                
                order = new Order
                {
                    Uin = orderModel.KmEmail,
                    Name = orderModel.CompanyName,
                    FilialId = orderModel.FilialId,
                    FilialName = orderModel.Filial,
                    Filialcode = orderModel.FilialCode,
                    RequestType = orderModel.TypeId,
                    RequestName = orderModel.RequestType,
                    SegmentId = orderModel.SegmentId,
                    SegmentName = orderModel.Segment,
                    StatusId = orderModel.StatusId,
                    StatusName = orderModel.Status,
                    Beneficator = orderModel.Beneficator,
                    Bin = orderModel.Bin,
                    kl_array = klList
                };
            }

            return order;
        }

        public async Task<string> CreateOrder(Order createOrder)
        {
            await _context.Database.BeginTransactionAsync();
            try
            {
                var order = new OrderModel
                {
                    Bin = createOrder.Bin,
                    Beneficator = createOrder.Beneficator,
                    CompanyName = createOrder.Name,
                    FilialId = createOrder.FilialId,
                    SegmentId = createOrder.SegmentId,
                    TypeId = createOrder.RequestType,
                    StatusId = 1,
                    KmEmail = createOrder.Uin,
                    StartDateTime = DateTime.Now,
                    FinishDateTime = null
                };
                await _context.OrderModels.AddAsync(order); 
                await _context.SaveChangesAsync();

                var id = order.Id;
                var klList = createOrder.kl_array.Select(klArray => new OrderDetailModel
                    {
                        KlNumber = klArray.kl_type,
                        Summ = klArray.summa,
                        CurrencyId = klArray.currency,
                        Mounth = klArray.validDate,
                        OrderId = id
                    })
                    .ToList();

                await _context.OrderDetailModels.AddRangeAsync(klList);
                await _context.SaveChangesAsync();
                _context.Database.CommitTransaction();
                return "Order added to DB";
            }
            catch (Exception e)
            {
                _context.Database.RollbackTransaction();
                return "Error with add order to DB";
            }
            
        }
        
    }
}