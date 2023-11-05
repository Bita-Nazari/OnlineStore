using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.Configuration;

namespace OS.Infrastucture.Db.SqlServer.DataBase;

public partial class OnlineStoreContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    //public OnlineStoreContext()
    //{
    //}

    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Booth> Booths { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    public virtual DbSet<MedalType> MedalTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCart> ProductCarts { get; set; }

    public virtual DbSet<ProductOrder> ProductOrders { get; set; }

    public virtual DbSet<ProductPicture> ProductPictures { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }
    public virtual DbSet<ProductBooth> ProductBooths { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2SMDACM\\SQLEXPRESS;Initial Catalog=onlineStore;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        modelBuilder.Entity<IdentityRole<int>>(entity =>
        {
            entity.HasKey(e =>e.Id);
        });
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionConfiguration());
        modelBuilder.ApplyConfiguration(new BidConfiguration());
        modelBuilder.ApplyConfiguration(new BoothConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new MedalConfiguration());
        modelBuilder.ApplyConfiguration(new MedalTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());
        modelBuilder.ApplyConfiguration(new ProductBoothConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCartConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductOrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductPictureConfiguration());
        modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
        modelBuilder.ApplyConfiguration(new SellerConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
        //modelBuilder.Entity<Admin>(entity =>
        //{
        //    entity.ToTable("Admin");

        //    entity.Property(e => e.FirstName).HasMaxLength(50);
        //    entity.Property(e => e.LastName).HasMaxLength(50);
        //    entity.HasOne(x => x.User).WithOne(x => x.Admin);
        //});

        //modelBuilder.Entity<Auction>(entity =>
        //{
        //    entity.ToTable("Auction");

        //    entity.Property(e => e.EndTime).HasColumnType("datetime");
        //    entity.Property(e => e.StartTime).HasColumnType("datetime");

        //    entity.HasOne(d => d.Booth).WithMany(p => p.Auctions)
        //        .HasForeignKey(d => d.BoothId)
        //        .HasConstraintName("FK_Auction_Booth");

        //    entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
        //        .HasForeignKey(d => d.ProductId)
        //        .OnDelete(DeleteBehavior.NoAction)
        //        .HasConstraintName("FK_Auction_Product");

        //    entity.HasOne(d => d.Winner).WithMany(p => p.Auctions)
        //        .HasForeignKey(d => d.WinnerId)
        //        .HasConstraintName("FK_Auction_Customer");
        //});

        //modelBuilder.Entity<Bid>(entity =>
        //{
        //    entity.ToTable("Bid");

        //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");

        //    entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
        //        .HasForeignKey(d => d.AuctionId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Bid_Auction");

        //    entity.HasOne(d => d.Customer).WithMany(p => p.Bids)
        //        .HasForeignKey(d => d.CustomerId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Bid_Customer");
        //});

        //modelBuilder.Entity<Booth>(entity =>
        //{
        //    entity.ToTable("Booth");

        //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        //    entity.Property(e => e.Name).HasMaxLength(50);

        //    entity.HasOne(d => d.Medal).WithMany(p => p.Booths)
        //        .HasForeignKey(d => d.MedalId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Booth_Medal");

        //    entity.HasOne(d => d.Seller).WithMany(p => p.Booths)
        //        .HasForeignKey(d => d.SellerId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Booth_Seller");
        //});

        //modelBuilder.Entity<Cart>(entity =>
        //{
        //    entity.ToTable("Cart");

        //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");


        //    entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
        //        .HasForeignKey(d => d.CustomerId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Cart_Customer");
        //});

        //modelBuilder.Entity<Category>(entity =>
        //{
        //    entity.ToTable("Category");

        //    entity.Property(e => e.Name).HasMaxLength(50);
        //});

        //modelBuilder.Entity<City>(entity =>
        //{
        //    entity.ToTable("City");

        //    entity.Property(e => e.Name).HasMaxLength(50);

        //    entity.HasOne(d => d.Province).WithMany(p => p.Cities)
        //        .HasForeignKey(d => d.ProvinceId)
        //        .HasConstraintName("FK_City_Province");
        //});

        //modelBuilder.Entity<Comment>(entity =>
        //{
        //    entity.ToTable("Comment");

        //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");

        //    entity.HasOne(d => d.Booth).WithMany(p => p.Comments)
        //        .HasForeignKey(d => d.BoothId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Comment_Booth");

        //    entity.HasOne(d => d.Customer).WithMany(p => p.Comments)
        //        .HasForeignKey(d => d.CustomerId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Comment_Customer");

        //    entity.HasOne(d => d.Order).WithMany(p => p.Comments)
        //        .HasForeignKey(d => d.OrderId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Comment_Order");
        //});

        //modelBuilder.Entity<Customer>(entity =>
        //{
        //    entity.ToTable("Customer");

        //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        //    entity.Property(e => e.FirstName).HasMaxLength(50);
        //    entity.Property(e => e.LastName).HasMaxLength(50);

        //    entity.HasOne(d => d.City).WithMany(p => p.Customers)
        //        .HasForeignKey(d => d.CityId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Customer_City");

        //    entity.HasOne(d => d.Picture).WithMany(p => p.Customers)
        //        .HasForeignKey(d => d.PictureId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Customer_Picture");

        //    entity.HasOne(x => x.User).WithOne(x => x.Customer);
        //});

        //modelBuilder.Entity<Medal>(entity =>
        //{
        //    entity.ToTable("Medal");

        //    entity.HasOne(d => d.MedalType).WithMany(p => p.Medals)
        //        .HasForeignKey(d => d.MedalTypeId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Medal_MedalType");
        //});

        //modelBuilder.Entity<MedalType>(entity =>
        //{
        //    entity.ToTable("MedalType");

        //    entity.Property(e => e.Type).HasMaxLength(50);
        //});

        //modelBuilder.Entity<Order>(entity =>
        //{
        //    entity.ToTable("Order");

        //    entity.HasOne(d => d.Cart).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.CartId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Order_Cart");

        //    entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.CustomerId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Order_Customer");

        //    entity.HasOne(d => d.Status).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.StatusId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Order_Status");
        //});

        //modelBuilder.Entity<Picture>(entity =>
        //{
        //    entity.ToTable("Picture");

        //    entity.Property(e => e.Url).IsUnicode(false);
        //});

        //modelBuilder.Entity<Product>(entity =>
        //{
        //    entity.ToTable("Product");

        //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        //    entity.Property(e => e.Name).HasMaxLength(50);
        //    entity.Property(e => e.BasePrice).HasColumnName("price");


        //    entity.HasOne(d => d.SubCategory).WithMany(p => p.Products)
        //        .HasForeignKey(d => d.SubCategoryId)
        //        .OnDelete(DeleteBehavior.NoAction)
        //        .HasConstraintName("FK_Product_SubCategory");
        //});

        //modelBuilder.Entity<ProductCart>(entity =>
        //{
        //    entity.HasKey(pb => pb.Id);

        //    entity.Property(e => e.Id).ValueGeneratedOnAdd();

        //    entity.HasOne(d => d.Cart).WithMany()
        //        .HasForeignKey(d => d.CartId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_ProductCart_Cart");

        //    entity.HasOne(d => d.ProductBooth).WithMany()
        //        .HasForeignKey(d => d.ProductBoothId)
        //        .OnDelete(DeleteBehavior.NoAction)
        //        .HasConstraintName("FK_ProductCart_Product");
        //});
        //modelBuilder.Entity<ProductBooth>(entity =>
        //{
        //    entity.ToTable("ProductBooth");

        //    entity.HasOne(d => d.Product)
        //        .WithMany(p => p.ProductBooths)
        //        .HasForeignKey(d => d.ProductId)
        //        .OnDelete(DeleteBehavior.Cascade)
        //        .HasConstraintName("FK_ProductBooth_Product");

        //    entity.HasOne(d => d.booth)  
        //        .WithMany(b => b.ProductBooths)
        //        .HasForeignKey(d => d.BoothId)
        //        .OnDelete(DeleteBehavior.Cascade)
        //        .HasConstraintName("FK_ProductBooth_Booth");

        //});

        //modelBuilder.Entity<ProductOrder>(entity =>
        //{
        //    entity.ToTable("ProductOrder");

        //    entity.HasOne(d => d.Order).WithMany(p => p.ProductOrders)
        //        .HasForeignKey(d => d.OrderId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_ProductOrder_Order");

        //    entity.HasOne(d => d.Product).WithMany(p => p.ProductOrders)
        //        .HasForeignKey(d => d.ProductId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_ProductOrder_Product");
        //});

        //modelBuilder.Entity<ProductPicture>(entity =>
        //{
        //    entity.ToTable("ProductPicture");

        //    entity.HasOne(d => d.Picture).WithMany(p => p.ProductPictures)
        //        .HasForeignKey(d => d.PictureId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_ProductPicture_Picture");

        //    entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
        //        .HasForeignKey(d => d.ProductId)
        //        .HasConstraintName("FK_ProductPicture_Product");
        //});

        //modelBuilder.Entity<Province>(entity =>
        //{
        //    entity.ToTable("Province");

        //    entity.Property(e => e.Name).HasMaxLength(50);
        //});

        //modelBuilder.Entity<Seller>(entity =>
        //{
        //    entity.ToTable("Seller");

        //    entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        //    entity.Property(e => e.FirstName).HasMaxLength(50);
        //    entity.Property(e => e.LastName).HasMaxLength(50);

        //    entity.HasOne(d => d.City).WithMany(p => p.Sellers)
        //        .HasForeignKey(d => d.CityId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Seller_City");

        //    entity.HasOne(d => d.Picture).WithMany(p => p.Sellers)
        //        .HasForeignKey(d => d.PictureId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_Seller_Picture");

        //    entity.HasOne(x => x.User).WithOne(x => x.Seller);
        //});

        //modelBuilder.Entity<Status>(entity =>
        //{
        //    entity.ToTable("Status");
        //});

        //modelBuilder.Entity<SubCategory>(entity =>
        //{
        //    entity.ToTable("SubCategory");

        //    entity.Property(e => e.Name).HasMaxLength(50);

        //    entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
        //        .HasForeignKey(d => d.CategoryId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_SubCategory_Category");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
