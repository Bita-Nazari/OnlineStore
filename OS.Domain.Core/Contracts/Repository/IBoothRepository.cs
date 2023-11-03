using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface IBoothRepository
    {
        Task Create(BoothDto boothDto, CancellationToken cancellationToken);
        Task SoftDelete(int BoothId, CancellationToken cancellationToken);
        Task HardDelete(int BoothId, CancellationToken cancellationToken);
        Task Update(BoothDto boothdto, CancellationToken cancellationToken);
        Task<BoothDto> Detail(int BoothId, CancellationToken cancellationToken);
        Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
    }
}
