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
    public class MedalRepository : IMedalRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public MedalRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<List<MedalDto>> GetAll(CancellationToken cancellationToken)
        {
            var cityList = await _storeContext.Medals.AsNoTracking().Include(m=>m.MedalType).Select(c => new MedalDto()
            {
                Id = c.Id,
                MedalTypeId = c.MedalTypeId,
                MedalName = c.MedalType.Type,
            }).ToListAsync(cancellationToken);
            return cityList;
        }
    }
}
