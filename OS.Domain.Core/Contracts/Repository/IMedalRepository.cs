using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface IMedalRepository
    {
        Task<List<MedalDto>> GetAll(CancellationToken cancellationToken);
    }
}
