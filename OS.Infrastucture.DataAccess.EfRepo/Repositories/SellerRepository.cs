using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public SellerRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<List<SellerDto>> GetAll(CancellationToken cancellationToken)
        {
            var sellerList = await _storeContext.Sellers.Select(s => new SellerDto()
            {
                Id = s.Id,
                NationalCode = s.NationalCode,
                FirstName = s.FirstName,
                LastName = s.LastName,
                ShabaNumber = s.ShabaNumber,
                CityId = s.CityId,
                CreatedAt = s.CreatedAt,
                PictureId = s.PictureId,
                PhoneNumber = s.PhoneNumber,

            }).ToListAsync(cancellationToken);
            return sellerList;
        }

        public async Task<SellerDto> GetDetail(int SellerId, CancellationToken cancellationToken)
        {
            var seller = await _storeContext.Sellers
                .Where(c => c.Id == SellerId)
                .FirstOrDefaultAsync(cancellationToken);
            var sellerDto = new SellerDto()
            {
                NationalCode = seller.NationalCode
                ,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                PhoneNumber = seller.PhoneNumber,
                CityId = seller.CityId,
                CreatedAt = seller.CreatedAt,
                PictureId = seller.PictureId,
                ShabaNumber = seller.ShabaNumber,

            };
            return sellerDto;
        }

        public async Task HardDelete(int SellerId, CancellationToken cancellationToken)
        {
            var seller = await _storeContext.Sellers
               .Where(c => c.Id == SellerId)
               .FirstOrDefaultAsync();
            _storeContext.Sellers.Remove(seller);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task SoftDelete(int SellerId, CancellationToken cancellationToken)
        {
            var seller = await _storeContext.Sellers
            .Where(c => c.Id == SellerId)
            .FirstOrDefaultAsync(cancellationToken);
            seller.IsDeleted = true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(SellerDto sellerDto, CancellationToken cancellationToken)
        {
            var seller = await _storeContext.Sellers
            .Where(c => c.Id == sellerDto.Id)
            .FirstOrDefaultAsync(cancellationToken);
            if(seller != null)
            {
                seller.FirstName = sellerDto.FirstName;
                seller.LastName = sellerDto.LastName;
                seller.ShabaNumber = sellerDto.ShabaNumber;
                seller.PhoneNumber = sellerDto.PhoneNumber;
                seller.CityId = sellerDto.CityId;
                seller.NationalCode = sellerDto.NationalCode;
                seller.PictureId = sellerDto.PictureId;

            }
            await _storeContext.SaveChangesAsync(cancellationToken);
        }
    }
}
