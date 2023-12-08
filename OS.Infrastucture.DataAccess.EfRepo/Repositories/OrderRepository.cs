using Hangfire.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.Config;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System.Transactions;

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
        public async Task Create(int? CartId, CancellationToken cancellationToken)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var products = await _storeContext.ProductCarts.Where(o => o.CartId == CartId).ToListAsync();
                var admin = await _storeContext.Admins.Where(a => a.Id == 2).FirstOrDefaultAsync();
                var cart = await _storeContext.Carts.Where(c => c.Id == CartId)
                    .Include(c => c.Customer)
                    .Include(c => c.ProductCarts)
                    .ThenInclude(p => p.Products)
                    .ThenInclude(pb => pb.booth)
                    .ThenInclude(b => b.Seller)
                    .ThenInclude(s => s.User)
                    .ThenInclude(u => u.Admin)
                    .FirstOrDefaultAsync();

                var order = new Order()
                {
                    CartId = CartId,
                    CustomerId = cart.CustomerId,
                    TotalPrice = cart.ProductCarts.Sum(p => p.Products.NewPrice),
                    StatusId = 1,
                };
                await _storeContext.Orders.AddAsync(order);
                await _storeContext.SaveChangesAsync(cancellationToken);

                cart.Customer.Wallet -= order.TotalPrice;


                foreach (var product in products)
                {
                    var MedalId = product.Products.booth.MedalId;
                    var commissionRate = GetCommission(MedalId);
                    var commission = (int)(product.Products.NewPrice * commissionRate);

                    var finalPrice = product.Products.NewPrice - commission;
                    admin.Wallet += commission;
                    product.Products.booth.Seller.Wallet += finalPrice;
                    product.Products.booth.TotalCount += 1;
                    product.Products.Count -= 1;


                    UpdateMedal(product.Products.booth.Id);
                }

                await _storeContext.SaveChangesAsync();

                foreach (var product in products)
                {
                    var orderProduct = new ProductOrder()
                    {
                        OrderId = order.Id,
                        ProductBoothId = product.ProductBoothId,
                    };
                    await _storeContext.ProductOrders.AddAsync(orderProduct);
                    await _storeContext.SaveChangesAsync(cancellationToken);

                }
                transactionScope.Complete();
            }


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
                 .Where(o => o.CartId != null)
                .Include(s => s.Status)
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
                    ProductBooths = o.ProductOrders.Select(o => o.Product).ToList(),
                    Pictures = o.ProductOrders
                .SelectMany(po => po.Product.Product.ProductPictures)
                .Select(pp => pp.Picture)
                .ToList(),
                    TotalPrice = o.TotalPrice,
                    CartId = o.CartId,
                    

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
        public decimal GetCommission(int? MedalId)
        {

            var commissionConfig = _configuration.GetSection("CommissionConfig").Get<CommissionConfig>();

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
        public void UpdateMedal(int BoothId)
        {
            var booth = _storeContext.Booths
      .Where(b => b.Id == BoothId)
           .Include(s => s.Seller)
           .Include(m => m.Medal)
           .ThenInclude(mt => mt.MedalType)
      .FirstOrDefault();

            if (booth.TotalCount >= 15)
            {
                booth.MedalId = (int)Domain.Core.Enums.MedalType.Gold;
            }
            else if (booth.TotalCount >= 10)
            {
                booth.MedalId = (int)Domain.Core.Enums.MedalType.Silver;
            }

            else
            {
                booth.MedalId = (int)Domain.Core.Enums.MedalType.Bronze;
            }

            _storeContext.SaveChanges();
        }

        public async Task<OrderDto> Detail(int orderId, CancellationToken cancellationToken)
        {
            var order = await _storeContext.Orders.Where(o => o.Id == orderId)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .ThenInclude(p => p.booth)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.Product)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductPictures)
                .ThenInclude(pp => pp.Picture)
                .Include(o => o.Cart)
                .Include(o => o.Status)
                .FirstOrDefaultAsync();



            if (order == null)
            {
                throw new NullReferenceException("order did not found");
            }
                var customer = await _storeContext.Customers.Where(c => c.Id == order.Cart.CustomerId)
    .Include(c => c.User)
    .FirstOrDefaultAsync();
                var orderdto = new OrderDto
                {
                    Id = order.Id,
                    PhoneNumber = customer.User.PhoneNumber,
                    Email = customer.User.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    ProductBooths = order.ProductOrders.Select(po => po.Product).ToList(),
                    Pictures = order.ProductOrders
                   .SelectMany(po => po.Product.Product.ProductPictures)
                   .Select(pp => pp.Picture)
                   .ToList(),
                    TotalPrice = order.TotalPrice,
                    StatusName = order.Status.Text,
                    //BoothId = order.Auction.BoothId

                };

                return orderdto;
           
 


        }

        public async Task<List<OrderDto>> GetAllAuctionOrder(int customerId ,CancellationToken cancellationToken)
        {
            
            var orders = await _storeContext.Orders.Where(o => o.CustomerId == customerId)
                .Where(o=> o.AuctionId!= null)
    .Include(s => s.Status)
    .Include(o => o.Auction)
    .ThenInclude(a => a.Product)
    .ThenInclude(pp => pp.ProductPictures)
    .ThenInclude(p => p.Picture)
    .Select(o => new OrderDto
    {

        Id = o.Id,
        CustomerId = o.CustomerId,
        StatusName = o.Status.Text,
        ProductName = o.Auction.Product.Name,
        ProductPrice = o.Auction.StartPrice,
        Pictures = o.Auction.Product.ProductPictures.Select(p=> p.Picture).ToList(),
        TotalPrice = o.TotalPrice,
        AuctionId = o.Auction.Id,   


    }).ToListAsync(cancellationToken);
            return orders;
        }
       

        public async Task<OrderDto> DetailAuction(int orderId, CancellationToken cancellationToken)
        {
           
            var orderAuction = await _storeContext.Orders.Where(o => o.Id == orderId)
     .Include(o => o.Auction)
     .ThenInclude(a => a.Product)
     .ThenInclude(p => p.ProductPictures)
     .ThenInclude(pp => pp.Picture)
     .Include(o => o.Status)
     .FirstOrDefaultAsync();
           
            var customerAuction = await _storeContext.Customers.Where(c => c.Id == orderAuction.Auction.CustomerId)
                .Include(c => c.User)
                .FirstOrDefaultAsync();
            var orderdto = new OrderDto
            {

                Id = orderAuction.Id,
                PhoneNumber = customerAuction.User.PhoneNumber,
                Email = customerAuction.User.Email,
                FirstName = customerAuction.FirstName,
                LastName = customerAuction.LastName,
                Address = customerAuction.Address,
                Pictures = orderAuction.Auction.Product.ProductPictures.Select(p => p.Picture).ToList(),
                TotalPrice = orderAuction.TotalPrice,
                StatusName = orderAuction.Status.Text,
                ProductName = orderAuction.Auction.Product.Name,
                ProductPrice = orderAuction.Auction.StartPrice,
                BoothId = orderAuction.Auction.BoothId

            };
            return orderdto;
        }
    }
}
