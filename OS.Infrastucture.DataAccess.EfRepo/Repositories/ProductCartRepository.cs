using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class ProductCartRepository : ICartProductRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public ProductCartRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<List<CartProductDto>> GetAllProduct(CartProductDto cartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
