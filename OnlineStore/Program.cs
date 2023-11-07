using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

//builder.Services.AddScoped<IAuctionAppService,AuctionAppService>();
//builder.Services.AddScoped<IBidAppService,BidAppService>();
//builder.Services.AddScoped<IBoothAppService,BoothAppService>();
//builder.Services.AddScoped<ICartAppService,CartAppService>();
//builder.Services.AddScoped<ICartProductAppService,CartProductAppService>();
//builder.Services.AddScoped<ICategoryAppService,CategoryAppService>();
//builder.Services.AddScoped<ICityAppService,CityAppService>();
//builder.Services.AddScoped<ICommentAppService,CommentAppService>();
//builder.Services.AddScoped<ICustomerAppService,CustomerAppService>();
//builder.Services.AddScoped<IMedalAppService,MedalAppService>();
//builder.Services.AddScoped<IOrderAppService,OrderAppService>();
//builder.Services.AddScoped<IPictureAppService,PictureAppService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProvinceAppService,ProvinceAppService>();
//builder.Services.AddScoped<ISellerAppService,SellerAppService>();
//builder.Services.AddScoped<ISubCategoryAppService,SubCategoryAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();




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

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashbord}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
