using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Text { get; set; } = null!;

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public int BoothId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Booth Booth { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;
    }
}
