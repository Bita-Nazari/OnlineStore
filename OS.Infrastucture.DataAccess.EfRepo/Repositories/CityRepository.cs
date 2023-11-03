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
    public class CityRepository : ICityRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public CityRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<List<CityDto>> GetAll(CancellationToken cancellationToken)
        {
            var cityList = await _storeContext.Cities.AsNoTracking().Select(c => new CityDto()
            {
                Id = c.Id,
                Name = c.Name,
                ProvinceId = c.ProvinceId,
            }).ToListAsync(cancellationToken);
            return cityList;
        }
    }
}
