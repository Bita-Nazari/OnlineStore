using OS.Domain.Core.Entities;

namespace OnlineStore.Models
{
    public class CommentViewModel
    {
        public int? Id { get; set; }

        public string? Text { get; set; } = null!;

        public int CustomerId { get; set; }

        public int? OrderId { get; set; }

        public int BoothId { get; set; }
        public string? BoothName { get; set; }
        public string? CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Booth Booth { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;
    }
}
