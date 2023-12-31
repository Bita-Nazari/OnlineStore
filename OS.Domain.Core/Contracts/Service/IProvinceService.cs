﻿using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IProvinceService
    {
        Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken);
    }
}
