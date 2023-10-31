using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class SellerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public long NationalCode { get; set; }

        public long PhoneNumber { get; set; }

        public int CityId { get; set; }

        public int PictureId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserId { get; set; }

        public long ShabaNumber { get; set; }

        public long Wallet { get; set; }

        public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

        public virtual City City { get; set; } = null!;

        public virtual Picture Picture { get; set; } = null!;
    }
}
