using OS.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Areas.Admin.Models
{
    public class AllUserViewModel
    {
        public int Id { get; set; }
        public int SellerId { get; set; }

        [Display(Name = "نام")]
        public string? FirstName { get; set; } = null!;
        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; } = null!;
        [Display(Name = "کد ملی")]
        public long? NationalCode { get; set; }
        [Display(Name = "شماره تماس")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "شهر")]
        public string? CityName { get; set; }

        public int? CityId { get; set; }
        [Display(Name = "ایمیل")]
        public string? Email { get; set; }
        [Display(Name = "یوزرنیم")]
        public string? UserName { get; set; }
        public string? PictureUrl { get; set; }

        public int? PictureId { get; set; }
        public string? Password { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? UserId { get; set; }
        [Display(Name = "شماره شبا")]
        public long? ShabaNumber { get; set; }
        [Display(Name = "کیف پول")]
        public long? Wallet { get; set; }
        [Display(Name = "آدرس")]
        public string? Address { get; set; } = null!;
        [DataType(DataType.Upload)]
        public IFormFile? file { get; set; }
        public Customer? Customer { get; set; }
        //public Seller? Seller { get; set; }
        public List<City>? cities { get; set; }
    }
}
