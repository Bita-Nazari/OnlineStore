using OS.Domain.Core.Entities;

namespace OnlineStore.Areas.Seller.Models
{
    public class SellerViewModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public long? NationalCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PicturUrl { get; set; }

        public int? CityId { get; set; }
        public string? CityName { get; set; }
        public bool? HaveBooth { get; set; }
        public int? PictureId { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? UserId { get; set; }

        public long? ShabaNumber { get; set; }

        public long? Wallet { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string MedalName { get; set; }
        public string? ConfirmPassword { get; set; }

        public virtual Booth Booth { get; set; } 

        public virtual City City { get; set; } = null!;

        public virtual Picture Picture { get; set; } = null!;
    }
}
