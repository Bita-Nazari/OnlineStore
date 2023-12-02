using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Enums;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{

    public class BoothRepository : IBoothRepository
    {
        private readonly OnlineStoreContext _storeContext;
        private readonly ISellerRepository _sellerRepository;
        public BoothRepository(OnlineStoreContext storeContext, ISellerRepository sellerRepository)
        {
            _storeContext = storeContext;
            _sellerRepository = sellerRepository;
        }
        public async Task Create(BoothDto boothDto, CancellationToken cancellationToken)
        {
            var seller = await _storeContext.Sellers.Where(c=>c.Id == boothDto.SellerId).FirstOrDefaultAsync();

            var booth = new Booth()
            {
                Id = boothDto.Id,
                Name = boothDto.Name,
                CreatedAt = DateTime.Now,
                Description = boothDto.Description,
                IsDeleted = false,
                MedalId = 2,
                SellerId = boothDto.SellerId,


            };

            seller.HaveBooth = true;


            await _storeContext.Booths.AddAsync(booth);
            await _storeContext.SaveChangesAsync(cancellationToken);

        }

        public async Task<BoothDto> Detail(int BoothId, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths
                .Where(b => b.Id == BoothId)

                .Include(s => s.Seller)
                .Include(m => m.Medal)
                .ThenInclude(mt => mt.MedalType)
                .Include(p => p.ProductBooths).ThenInclude(m => m.Product)
                .FirstOrDefaultAsync(cancellationToken);
            var product = await _storeContext.ProductBooths
                .Where(p => p.Id == BoothId)
                .FirstOrDefaultAsync(cancellationToken);
            if (booth != null)
            {
                var boothdto = new BoothDto()
                {
                    Id = booth.Id,
                    Name = booth.Name,
                    CreatedAt = booth.CreatedAt,
                    Description = booth.Description,
                    MedalId = booth.MedalId,
                    Medalname = booth.Medal.MedalType.Type,
                    Products = booth.ProductBooths.Select(p => p.Product).ToList(),
                    HaveBooth = booth.Seller.HaveBooth,
                    TotalCount = booth.TotalCount
                };
                return boothdto;
            }

            throw new NullReferenceException();

        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
        {
            var boothproduct = await _storeContext.ProductBooths.Include(p => p.Product).ToListAsync();
            var boothList = await _storeContext.Booths
                .Include(p => p.ProductBooths)
                .ThenInclude(pp => pp.Product)
                .Include(s => s.Seller)
                .Include(m => m.Medal)
                .ThenInclude(mt => mt.MedalType)
                .Select(b => new BoothDto()
                {
                    Id = b.Id,
                    Name = b.Name,
                    CreatedAt = b.CreatedAt,
                    Description = b.Description,
                    MedalId = b.MedalId,
                    Medalname = b.Medal.MedalType.Type,
                    SellerName = b.Seller.FirstName + " " + b.Seller.LastName,
                    IsDeleted = b.IsDeleted,
                    TotalCount =b.TotalCount,
                    //HaveBooth = b.Seller.HaveBooth

                }
            ).ToListAsync(cancellationToken);
            return boothList;
        }

        public async Task<BoothDto> GetBoothBySeller(int sellerId, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths
                 .Where(b => b.SellerId == sellerId)
                 .Include(m => m.Medal)
                 .ThenInclude(mt => mt.MedalType)
                 .FirstOrDefaultAsync(cancellationToken);

            var boothdto = new BoothDto()
            {
                Id = booth.Id,
                Name = booth.Name,
                CreatedAt = booth.CreatedAt,
                Description = booth.Description,
                Medalname = booth.Medal.MedalType.Type,
                //TotalCount = booth.TotalCount,
            };

            return boothdto;

            
        }

        public async Task HardDelete(int BoothId, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths
                .Where(b => b.Id == BoothId)
                .FirstOrDefaultAsync();
            _storeContext.Remove(booth);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task SoftDelete(int BoothId, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths
                .Where(b => b.Id == BoothId)
            .FirstOrDefaultAsync();
            booth.IsDeleted = true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(BoothDto boothdto, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths
           .Where(b => b.Id == boothdto.Id)
                .Include(p => p.ProductBooths)
                .ThenInclude(pp => pp.Product)
                .Include(s => s.Seller)
                .Include(m => m.Medal)
                .ThenInclude(mt => mt.MedalType)
           .FirstOrDefaultAsync();
            if (booth != null)
            {
                booth.Name = boothdto.Name;
                booth.Description = boothdto.Description;



            }
            try
            {
                await _storeContext.SaveChangesAsync(cancellationToken);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task UpdateMedal(int BoothId, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths
      .Where(b => b.Id == BoothId)
           .Include(s => s.Seller)
           .Include(m => m.Medal)
           .ThenInclude(mt => mt.MedalType)
      .FirstOrDefaultAsync();

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
        }
    }
}
