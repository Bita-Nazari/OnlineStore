using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class AdminAppService : IAdminAppService 
    {
        private readonly IAdminService _adminService;
        public AdminAppService(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task EditAdmin(AlluserDto user, CancellationToken cancellationToken)
        {
            await _adminService.EditAdmin(user, cancellationToken);
        }

        public  Task<AlluserDto> GetAdminById(int AdminId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AlluserDto> GetAdminByUserId(int Userid, CancellationToken cancellationToken)
        {
           
            return await _adminService.GetAdminByUserId(Userid, cancellationToken);
        }

        public async Task<DashbordDto> Info(CancellationToken cancellationToken)
        {
            return await _adminService.Info(cancellationToken);
        }
    }
}
