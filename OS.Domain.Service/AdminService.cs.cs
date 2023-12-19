using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task EditAdmin(AlluserDto user, CancellationToken cancellationToken)
        {
            await _adminRepository.EditAdmin(user, cancellationToken);
        }

        public Task<AlluserDto> GetAdminById(int AdminId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AlluserDto> GetAdminByUserId(int Userid, CancellationToken cancellationToken)
        {
            return await _adminRepository.GetAdminByUserId(Userid, cancellationToken);
        }

        public async Task<DashbordDto> Info(CancellationToken cancellationToken)
        {
            return await _adminRepository.Info(cancellationToken);
        }
    }
}
