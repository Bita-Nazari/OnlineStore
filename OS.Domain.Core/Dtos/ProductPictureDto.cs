using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class ProductPictureDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}
