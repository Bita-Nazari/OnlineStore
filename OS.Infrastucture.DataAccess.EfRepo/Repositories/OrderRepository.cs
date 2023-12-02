using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.Config;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineStoreContext _storeContext;
        private readonly IConfiguration _configuration;
        public OrderRepository(OnlineStoreContext storeContext, IConfiguration configuration)
        {
            _storeContext = storeContext;
            _configuration = configuration;
        }
        public async Task Create(OrderDto orderDto, CancellationToken cancellationToken)
        {
            var products = await _storeContext.ProductCarts.Where(o => o.CartIds == orderDto.CartId).ToListAsync();
            var order = new Order()
            {
                Id = orderDto.Id,
                Commession = CalculateCommission(products),
                Status = orderDto.Status,
                CartId = orderDto.CartId,
                CustomerId = orderDto.CustomerId,
                TotalPrice = orderDto.TotalPrice,
                StatusId = orderDto.StatusId,
                ProductOrders = orderDto.ProductOrders,


            };
            await _storeContext.Orders.AddAsync(order);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetAllCustomerOrder(int customerId, CancellationToken cancellationToken)
        {
          
            var orders = await _storeContext.Orders.Where(o => o.CustomerId == customerId)
                .Include(s=> s.Status)
                .Include(p => p.ProductOrders)
                .ThenInclude(pp => pp.Product)
                .ThenInclude(p => p.Product)
                .ThenInclude(pp => pp.ProductPictures)
                .ThenInclude(p => p.Picture)
                .Select(o => new OrderDto
                {

                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    StatusName = o.Status.Text,
                    ProductBooth = o.ProductOrders.Select(o=> o.Product).ToList(),
                    Pictures = o.ProductOrders
                .SelectMany(po => po.Product.Product.ProductPictures)
                .Select(pp => pp.Picture)
                .ToList(),
                    TotalPrice = o.TotalPrice,
                    
                }).ToListAsync(cancellationToken);
            return orders;
        }

        public int CalculateCommission(List<ProductCart> products)
        {

            int totalCommission = 0;

            foreach (var product in products)
            {

                var MedalId = product.Products.booth.MedalId;
                var commissionRate = GetCommission(MedalId);


                var commission = (int)(product.Products.NewPrice * commissionRate);

                totalCommission += commission;
            }

            return totalCommission;
        }
        private decimal GetCommission(int? MedalId)
        {

            var commissionConfig = _configuration.GetSection("CommessionConfig").Get<CommissionConfig>();

            if (MedalId == 1)
            {
                return commissionConfig.Bronze;
            }
            else if (MedalId == 2)
            {
                return commissionConfig.Silver;
            }
            else
            {
                return commissionConfig.Gold;
            }
        }
    }
}
