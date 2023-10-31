using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface IAuctionAppService
    {
        Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken);
        Task<List<AuctionDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken);
        Task Create(AuctionDto auctionDto , CancellationToken cancellationToken);
        Task Update (AuctionDto auctionDto , CancellationToken cancellationToken);
        Task<AuctionDto> GetDetail(int AuctionId ,CancellationToken cancellationToken);
    }
}
