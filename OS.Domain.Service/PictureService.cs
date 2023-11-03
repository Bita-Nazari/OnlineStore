using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Service
{
    public class PictureService :IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
            
        }
    }
}
