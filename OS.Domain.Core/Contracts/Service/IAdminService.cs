using Microsoft.AspNetCore.Http;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IAdminService
    {
        public Task<AlluserDto> GetAdminById(int AdminId, CancellationToken cancellationToken);
        public Task<AlluserDto> GetAdminByUserId(int Userid, CancellationToken cancellationToken);
        public Task EditAdmin(AlluserDto user, CancellationToken cancellationToken);
        public Task<DashbordDto> Info(CancellationToken cancellationToken);
    }
}
