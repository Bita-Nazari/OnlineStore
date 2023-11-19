using OS.Domain.Core.Entities;
using System.ComponentModel;

namespace OnlineStore.Areas.Seller.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; } = null!;

        [DisplayName("قیمت")]
        public long Price { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsConfirmed { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? BoothId { get; set; }

        public int SubCategoryId { get; set; }
        [DisplayName("کتگوری")]
        public string? SubcategoryName { get; set; }

        public bool? IsAvailable { get; set; }

        public int? ProductId { get; set; }
        public int? PictureId { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual Booth Booth { get; set; } = null!;

        public virtual ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();

        public virtual SubCategory SubCategory { get; set; } = null!;


        public List<SubCategory> subCategories { get; set; }
    }
}
