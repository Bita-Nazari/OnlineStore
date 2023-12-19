using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class DashbordDto
    {
        public int CustomerCount { get; set; }
        public int BoothCount { get; set; }
        public int CommentCount { get; set; }
        public int OrderCount { get; set; }
    }
}
