using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public BidRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task Create(BidDto bid, CancellationToken cancellationToken)
        {
            var auction = await _storeContext.Auctions.Where(a=> a.Id == bid.AuctionId).FirstOrDefaultAsync();
            var customer = await _storeContext.Customers.Where(c=> c.Id == bid.CustomerId).FirstOrDefaultAsync();
            var admin = _storeContext.Admins.Where(a => a.Id == 2).FirstOrDefault();
            if (auction == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                if(auction.StartPrice < bid.SuggestedPrice)
                {
                    if(customer.Wallet < bid.SuggestedPrice)
                    {
                        throw new Exception("your wallet is less than your suggested price please charge your wallet");
                    }
                    var item = new Bid()
                    {
                        Id = bid.Id,
                        AuctionId = bid.AuctionId,
                        CreatedAt = DateTime.Now,
                        CustomerId = bid.CustomerId,
                        SuggestedPrice = bid.SuggestedPrice

                    };
                    auction.StartPrice = bid.SuggestedPrice;
                    auction.BidCount ++;
                    customer.Wallet = customer.Wallet - bid.SuggestedPrice;
                    admin.Wallet = admin.Wallet + bid.SuggestedPrice;

                    await _storeContext.Bids.AddAsync(item);
                    await _storeContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("the suggested price is not enough");
                }
               

            }

        }

        public async Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
        {
            var Bidlist = await _storeContext.Bids.AsNoTracking().Select(b => new BidDto()
            {

                Id = b.Id,
                AuctionId = b.AuctionId,
                CreatedAt = b.CreatedAt,
                CustomerId = b.Customer.Id,
                SuggestedPrice = b.SuggestedPrice,
            }).ToListAsync(cancellationToken);
            return Bidlist;
        }

        public Task<List<BidDto>> GetAllCustomerBid(int CustomerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BidDto>> GetAllProductBid(int ProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<BidDto> GetDetail(int bidId, CancellationToken cancellationToken)
        {
            var bid = await _storeContext.Bids.Where(b => b.Id == bidId).FirstOrDefaultAsync(cancellationToken);
            var biddto = new BidDto()
            {
                Id = bid.Id,
                CreatedAt = bid.CreatedAt,
                CustomerId = bid.Customer.Id,
                SuggestedPrice = bid.SuggestedPrice,
            };
            return biddto;


        }

        public async Task HardDelete(int bidId, CancellationToken cancellationToken)
        {
            var bid = await _storeContext.Bids
                 .Where(b => b.Id == bidId)
                 .FirstOrDefaultAsync();
            _storeContext.Bids.Remove(bid);
            await _storeContext.SaveChangesAsync(cancellationToken);

        }

        public async Task SoftDelete(int bidId, CancellationToken cancellationToken)
        {
            var bid = await _storeContext.Bids
            .Where(b => b.Id == bidId)
            .FirstOrDefaultAsync();
            bid.IsDeleted = true;
            await _storeContext.SaveChangesAsync();
        }
    }
}
