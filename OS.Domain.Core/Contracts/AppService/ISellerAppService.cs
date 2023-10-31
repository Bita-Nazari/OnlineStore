using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface ISellerAppService
    {
        Task<List<SellerDto>> GetAll(CancellationToken cancellationToken);
        Task Update(SellerDto sellerDto, CancellationToken cancellationToken);
        Task<SellerDto> GetDetail(int SellerId, CancellationToken cancellationToken);
        Task SoftDelete(int SellerId, CancellationToken cancellationToken);
        Task HardDelete(int SellerId, CancellationToken cancellationToken);
    }
}
