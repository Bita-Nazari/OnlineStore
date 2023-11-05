using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public AuctionRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            var item = new Auction
            {
                Id = auctionDto.Id,
                StartPrice = auctionDto.StartPrice,
                StartTime = auctionDto.StartTime,
                EndTime = auctionDto.EndTime,
                CustomerId = auctionDto.WinnerId,
                ProductId = auctionDto.ProductId,
                BoothId = auctionDto.BoothId

            };
            await _storeContext.Auctions.AddAsync(item);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            var auctionList = _storeContext.Auctions.AsNoTracking().Select(a => new AuctionDto
            {
                Id = a.Id,
                StartPrice = a.StartPrice,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                WinnerId = a.CustomerId,
                ProductId = a.ProductId,
                BoothId = a.BoothId

            }

                ).ToListAsync(cancellationToken);
            return auctionList;
        }

        public Task<List<AuctionDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AuctionDto> GetDetail(int AuctionId, CancellationToken cancellationToken)
        {
            var auction = await _storeContext.Auctions
                .Where(a => a.Id == AuctionId)
                .FirstOrDefaultAsync(cancellationToken);
            var auctionDto = new AuctionDto()
            {
                Id = auction.Id,
                StartPrice = auction.StartPrice,
                StartTime = auction.StartTime,
                EndTime = auction.EndTime,
                BoothId = auction.BoothId,
                WinnerId = auction.CustomerId
            };
            return auctionDto;

        }

        public async Task Update(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            var item = await _storeContext.Auctions
                .Where(a => a.Id == auctionDto.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if(item != null)
            {
                item.StartPrice = auctionDto.StartPrice;
                item.ProductId = auctionDto.ProductId;
                item.StartTime = auctionDto.StartTime;
                item.EndTime = auctionDto.EndTime;


            }
            try
            {
                await _storeContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
