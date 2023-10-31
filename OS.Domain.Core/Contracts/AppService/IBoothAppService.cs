using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface IBoothAppService
    {
        Task Create(BoothDto boothDto, CancellationToken cancellationToken);
        Task SoftDelete(int BoothId, CancellationToken cancellationToken);
        Task HardDelete(int BoothId, CancellationToken cancellationToken);
        Task Update(int BoothId, CancellationToken cancellationToken);
        Task<BoothDto>Detail(int BoothId, CancellationToken cancellationToken);
        Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
    }
}
