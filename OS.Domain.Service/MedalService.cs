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
    public class MedalService : IMedalService
    {
        private readonly IMedalRepository _medalRepository;
        public MedalService(IMedalRepository medalRepository)
        {
            _medalRepository = medalRepository; 
        }

        public Task<List<MedalDto>> GetAll(CancellationToken cancellationToken)
        {
            return _medalRepository.GetAll(cancellationToken);
        }
    }
}
