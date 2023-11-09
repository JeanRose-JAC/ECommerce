using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<OrdersProvider> logger;
        private readonly IMapper mapper;

        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.OrderItem> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                //FIX 
                var orders = await dbContext.Orders.FirstOrDefaultAsync(o => o.CustomerId == customerId);
                if (orders != null)
                {
                    var orderModel = mapper.Map<Db.Order, Models.Order>(orders);
                    var orderItemModel = mapper.Map<IEnumerable<Db.OrderItem>, IEnumerable<Models.OrderItem>>(orders.Items);
                    return (true, orderItemModel, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
