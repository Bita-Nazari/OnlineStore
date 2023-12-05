using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{

    public class CartRepository : ICartRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public CartRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(int CustomerId, CancellationToken cancellationToken)
        {
            var customer = await _storeContext.Customers.Where(c=> c.Id == CustomerId).FirstOrDefaultAsync();
            var Cart = new Cart()
            {
                CustomerId = customer.Id,
                CreatedAt = DateTime.Now
            };
            await _storeContext.Carts.AddAsync(Cart);

            await _storeContext.SaveChangesAsync(cancellationToken);
            customer.ActiveCartId = Cart.Id;
            await _storeContext.SaveChangesAsync();

        }

        public async Task<CartDto> Detail(int? CartId, CancellationToken cancellationToken)
        {
            var cart = await _storeContext.Carts
                .Where(c => c.Id == CartId)
                .Include(c => c.ProductCarts)
                .ThenInclude(p => p.Products)
                 .ThenInclude(pb => pb.Product)
                .ThenInclude(p => p.ProductPictures)
                .ThenInclude(p => p.Picture)
                .Include(c=>c.Customer)
                .FirstOrDefaultAsync(cancellationToken);
            var cartDto = new CartDto()
            {

                Wallet = cart.Customer.Wallet,
                CreatedAt = cart.CreatedAt,
                Products = cart.ProductCarts.Select(p => p.Products).ToList(),
                Pictures = cart.ProductCarts.SelectMany(po => po.Products.Product.ProductPictures)
                .Select(pp => pp.Picture)
                .ToList(),
                TotalPrice = cart.ProductCarts.Sum(p => p.Products.NewPrice),


            };
            return cartDto;
        }

        public async Task<List<CartDto>> GetAll(CancellationToken cancellationToken)
        {
            var CartList = await _storeContext.Carts
                .AsNoTracking()
                .Select(c => new CartDto()
                {
                    //CustomerId = c.CustomerId,
                    //CreatedAt= c.CreatedAt,
                }).ToListAsync(cancellationToken);
            return CartList;
        }

        public Task<List<CartDto>> GetAllBoothCarts(int boothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllProduct(int cartId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllProduct(CartDto cartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HardDelete(int CartId, CancellationToken cancellationToken)
        {
            var cart = await _storeContext.Carts.Where(c => c.Id == CartId).FirstOrDefaultAsync();
            _storeContext.Remove(cart);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public Task Update(int CartId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
