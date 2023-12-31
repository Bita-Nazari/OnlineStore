using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Entities;
using OS.Domain.Service;
using OS.Infrastucture.DataAccess.EfRepo.Repositories;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<OnlineStoreContext>(options
//    => options.UseSqlServer(connectionString));


builder.Services.AddDbContext<OnlineStoreContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHangfire(configuration => configuration
    .UseSqlServerStorage(@"Data Source=DESKTOP-2SMDACM\SQLEXPRESS;Initial Catalog=onlineStore;TrustServerCertificate=True;Integrated Security=True;")); builder.Services.AddHangfireServer();

builder.Services.AddIdentity<User, IdentityRole<int>>(
    options =>
    {
        options.SignIn.RequireConfirmedEmail = true;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        
    }
    )
.AddEntityFrameworkStores<OnlineStoreContext>();


builder.Services.AddScoped<IAuctionAppService, AuctionAppService>();
builder.Services.AddScoped<IAuctionService , AuctionService>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IBidAppService, BidAppService>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IBoothAppService, BoothAppService>();
builder.Services.AddScoped<IBoothService , BoothService>();
builder.Services.AddScoped<IBoothRepository, BoothRepository>();
builder.Services.AddScoped<ICartAppService, CartAppService>();
builder.Services.AddScoped<ICartService , CartService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartProductAppService, CartProductAppService>();
builder.Services.AddScoped<ICartProductService , CartProductService>();
builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICityAppService, CityAppService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IAdminAppService, AdminAppService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
//builder.Services.AddScoped<ICommentAppService, CommentAppService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IMedalAppService, MedalAppService>();
builder.Services.AddScoped<IMedalRepository, MedalRepository>();
builder.Services.AddScoped<IMedalService, MedalService>();

builder.Services.AddScoped<ICommentAppService, CommentAppService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IOrderAppService, OrderAppService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IPictureAppService,PictureAppService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductBoothService, ProductBoothService>();
builder.Services.AddScoped<IProductBoothAppService, ProductBoothAppService>();
builder.Services.AddScoped<IProductBoothRepository, ProductBoothRepository>();
//builder.Services.AddScoped<IProvinceAppService,ProvinceAppService>();
builder.Services.AddScoped<ISellerAppService, SellerAppService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISubCategoryAppService, SubCategoryAppService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuctionHangFire>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.UseHangfireDashboard();

//app.UseHangfireDashboard("/hangfire", new DashboardOptions
//{
//    Authorization = new[] { new HangfireAuthorizationFilter() }
//});

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashbord}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Seller",
    pattern: "Seller/{controller=Dashbord}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
