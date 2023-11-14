using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class MedalAppService :IMedalAppService
    {
        private readonly IMedalService _medalService;
        public MedalAppService(IMedalService medalService)
        {
            _medalService = medalService;
        }

        public Task<List<MedalDto>> GetAll(CancellationToken cancellationToken)
        {
            return _medalService.GetAll(cancellationToken);
        }
    }
}
