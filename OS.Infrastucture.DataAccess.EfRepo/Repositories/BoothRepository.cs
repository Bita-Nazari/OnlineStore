using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class BoothRepository : IBoothRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public BoothRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(BoothDto boothDto, CancellationToken cancellationToken)
        {
            var booth = new Booth()
            {
                Id = boothDto.Id,
                Name = boothDto.Name,
                CreatedAt = DateTime.Now,
                Description = boothDto.Description,
                MedalId = boothDto.MedalId,
                SellerId = boothDto.SellerId,

            };
             await _storeContext.Booths.AddAsync(booth);
            await _storeContext.SaveChangesAsync(cancellationToken);

        }

        public async Task<BoothDto> Detail(int BoothId, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths
                .Where(b=> b.Id == BoothId)
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
                    SellerId = booth.SellerId,
                };
                return boothdto;
            }
           
            throw new NullReferenceException();
            
        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
        {
            var boothList = await _storeContext.Booths
                .Select(b => new BoothDto()
            {
                Id= b.Id,
                Name = b.Name,
                CreatedAt = b.CreatedAt,
                Description = b.Description,
                MedalId = b.MedalId,
                SellerId = b.SellerId
            }
            ).ToListAsync(cancellationToken);
            return boothList;
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
           .FirstOrDefaultAsync();
           if(booth != null)
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
    }
}
