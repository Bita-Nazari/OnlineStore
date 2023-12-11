using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IBoothService
    {
        Task Create(BoothDto boothDto, CancellationToken cancellationToken);
        Task SoftDelete(int BoothId, CancellationToken cancellationToken);
        Task HardDelete(int BoothId, CancellationToken cancellationToken);
        Task Update(BoothDto boothdto, CancellationToken cancellationToken);
        Task UpdateMedal(int BoothId, CancellationToken cancellationToken);
        Task<BoothDto> Detail(int BoothId, CancellationToken cancellationToken);
        Task<List<BoothDto>> GetAll(CancellationToken cancellationToken);
        Task<BoothDto> GetBoothBySeller(int sellerId,CancellationToken cancellationToken);
        public Task IsRestored(int id, CancellationToken cancellationToken);
    }
}
