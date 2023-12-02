using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System.Globalization;
using System.Security.Claims;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly OnlineStoreContext _storeContext;
        private readonly AuctionHangFire _auctionHangFire;
        public AuctionRepository(OnlineStoreContext storeContext, AuctionHangFire auctionHangFire , UserManager<User> userManager)
        {
            _storeContext = storeContext;
            _auctionHangFire = auctionHangFire;
            _userManager = userManager;

        }
        public DateTime ConvertToPersianTime(DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            int year = persianCalendar.GetYear(dateTime);
            int month = persianCalendar.GetMonth(dateTime);
            int day = persianCalendar.GetDayOfMonth(dateTime);
            int hour = dateTime.Hour;
            int minute = dateTime.Minute;
            int second = dateTime.Second;

            DateTime persianDateTime = new DateTime(year, month, day, hour, minute, second, persianCalendar);
            return persianDateTime;
        }
        public async Task Create(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            var persianStart = ConvertToPersianTime(auctionDto.StartTime);

            var item = new Auction
            {

                StartPrice = auctionDto.StartPrice,
                StartTime = auctionDto.StartTime,
                EndTime = auctionDto.EndTime,
                CustomerId = auctionDto.WinnerId,
                ProductId = auctionDto.ProductId,
                BoothId = auctionDto.BoothId

            };
            await _storeContext.Auctions.AddAsync(item);
            await _storeContext.SaveChangesAsync(cancellationToken);

            BackgroundJob.Schedule(() => _auctionHangFire.StartAuction(item.Id), item.StartTime - DateTime.Now);
            BackgroundJob.Schedule(() => _auctionHangFire.CloseAuction(item.Id), item.EndTime - DateTime.Now);
        }

        public Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            var auctionList = _storeContext.Auctions.AsNoTracking()
                .Include(p => p.Product)
                .ThenInclude(c => c.SubCategory)
                .Include(pt => pt.Product)
                .ThenInclude(pp => pp.ProductPictures)
                .Include(pi => pi.Product)
                .ThenInclude(b => b.ProductPictures)
                .ThenInclude(pp => pp.Picture)

                .Select(a => new AuctionDto
                {
                    Id = a.Id,
                    StartPrice = a.StartPrice,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    WinnerId = a.CustomerId,
                    ProductId = a.ProductId,
                    BoothId = a.BoothId,
                    Description = a.Product.Description,
                    ProductName = a.Product.Name,
                    SubcategoryName = a.Product.SubCategory.Name,
                    Pictures = a.Product.ProductPictures.Select(p => p.Picture).ToList(),
                    IsStarted = a.IsStarted,
                    IsDisabled = a.IsDisabled,


                }

                ).ToListAsync(cancellationToken);
            return auctionList;
        }

        public Task<List<AuctionDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            //var booth = _storeContext.Booths.Where(b=> b.Id == BoothId).FirstOrDefault();
            var auctionList = _storeContext.Auctions.Where(a => a.BoothId == BoothId).AsNoTracking()
      .Include(p => p.Product)
      .ThenInclude(c => c.SubCategory)
      .Include(pt => pt.Product)
      .ThenInclude(pp => pp.ProductPictures)
      .Include(pi => pi.Product)
      .ThenInclude(b => b.ProductPictures)
      .ThenInclude(pp => pp.Picture)

      .Select(a => new AuctionDto
      {
          Id = a.Id,
          StartPrice = a.StartPrice,
          StartTime = a.StartTime,
          EndTime = a.EndTime,
          WinnerId = a.CustomerId,
          ProductId = a.ProductId,
          BoothId = a.BoothId,
          Description = a.Product.Description,
          ProductName = a.Product.Name,
          SubcategoryName = a.Product.SubCategory.Name,
          Pictures = a.Product.ProductPictures.Select(p => p.Picture).ToList(),
          IsStarted = a.IsStarted,
          IsDisabled = a.IsDisabled,



      }

      ).ToListAsync(cancellationToken);
            return auctionList;
        }

        public async Task<AuctionDto> GetDetail(int AuctionId, CancellationToken cancellationToken)
        {
           
            var auction = await _storeContext.Auctions
                .Where(a => a.Id == AuctionId)
                      .Include(pt => pt.Product)
      .ThenInclude(pp => pp.ProductPictures)
      .ThenInclude(p=>p.Picture)
                .Include(b=>b.Booth)
                .FirstOrDefaultAsync(cancellationToken);
            var auctionDto = new AuctionDto()
            {
                Id = auction.Id,
                StartPrice = auction.StartPrice,
                StartTime = auction.StartTime,
                EndTime = auction.EndTime,
                BoothId = auction.BoothId,
                WinnerId = auction.CustomerId,
                BoothName =auction.Booth.Name,
                Description =auction.Product.Description,
                Pictures = auction.Product.ProductPictures.Select(p => p.Picture).ToList(),

            };
            return auctionDto;

        }

        public async Task Update(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            var item = await _storeContext.Auctions
                .Where(a => a.Id == auctionDto.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if (item != null)
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
