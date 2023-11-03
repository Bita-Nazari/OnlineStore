using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class PictureAppService :IPictureAppService
    {
        private readonly IPictureService _pictureService;
        public PictureAppService(IPictureService pictureService)
        {
               _pictureService = pictureService;
        }
    }
}
