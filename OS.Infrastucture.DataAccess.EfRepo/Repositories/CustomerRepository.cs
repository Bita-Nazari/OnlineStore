﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OnlineStoreContext _storeContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CustomerRepository(OnlineStoreContext storeContext , IWebHostEnvironment hostEnvironment)
        {
            _storeContext = storeContext;
            _hostingEnvironment = hostEnvironment;
        }

        public async Task ChargeWallet(int Customerid, CustomerDto customerdto, CancellationToken cancellationToken)
        {
            var customer = await _storeContext.Customers.Where(c=> c.Id == Customerid).FirstOrDefaultAsync();
            if (customer == null)
            {
                throw new NullReferenceException("User did not found");
            }
            customer.Wallet += customerdto.Wallet;
            await _storeContext.SaveChangesAsync(); 
        }

        public async Task DeleteCustomer(int id , CancellationToken cancellationToken)
        {
                var customer = await _storeContext.Customers
               .Where(p => p.Id == id)
               .FirstOrDefaultAsync();
                if (customer == null)
                {
                    throw new NullReferenceException(nameof(customer));
                }
                customer.IsDeleted = true;
                await _storeContext.SaveChangesAsync(cancellationToken);
            
        }



        public async Task EditCustomer(AlluserDto user ,IFormFile file, CancellationToken cancellationToken)
        {

            var User = await _storeContext.Customers.Where(s => s.Id == user.Id)
            .Include(u => u.User)
            .Include(u => u.City).FirstOrDefaultAsync();
            if (User == null)
            {
                throw new NullReferenceException("user did not found");
            }

            if (file != null && file.Length > 0)
            {

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                var picture = new Picture
                {

                    Url = "/upload/" + uniqueFileName,
                    IsDeleted = false,
                    IsConfirmed = false,
                    IsProfilePicture = false


                };
                await _storeContext.Pictures.AddAsync(picture);
                await _storeContext.SaveChangesAsync();

                var webRootPath = _hostingEnvironment.WebRootPath;

                // Combine with the upload folder path
                var uploadPath = Path.Combine(webRootPath, "upload");


                var filePath = Path.Combine(uploadPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream, cancellationToken);
                }
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.CityId = user.CityId;
                User.Address = user.Address;
                User.User.Email = user.Email;
                User.User.PhoneNumber = user.PhoneNumber;
                User.User.UserName = user.UserName;
                User.PictureId = picture.Id;
                await _storeContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.CityId = user.CityId;
                User.Address = user.Address;
                User.User.Email = user.Email;
                User.User.PhoneNumber = user.PhoneNumber;
                User.User.UserName = user.UserName;
                await _storeContext.SaveChangesAsync(cancellationToken);
            }
        }




        public async Task<List<UserDto>> GetAll(CancellationToken cancellationToken)
        {
            var UserList = await _storeContext.Users.AsNoTracking().Select(x => new UserDto()
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            }).ToListAsync();
            return UserList;
        }

        public async Task<List<AlluserDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            var user = await _storeContext.Customers.AsNoTracking().Select(a => new AlluserDto()
            {
                Id = a.Id,
                UserName = a.User.UserName,
                PhoneNumber = a.User.PhoneNumber,
                Email = a.User.Email,
                Address = a.Address,
                CreatedAt = a.CreatedAt,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Wallet = a.Wallet,
                CityName = a.City.Name,
                IsDeleted = a.IsDeleted,

            }).ToListAsync();
            return user;
        }






        public async Task<AlluserDto> GetCustomerById(int CustomerId, CancellationToken cancellationToken)
        {
            var customer = await _storeContext.Customers.Where(c => c.Id == CustomerId)
                .Include(u => u.User)
                .Include(c => c.City)
                .Include(c=> c.Picture)
                .FirstOrDefaultAsync(cancellationToken);
            if (customer == null)
            {
                throw new NullReferenceException("User did not found");
            }
            var userdto = new AlluserDto()
            {
                Id = customer.Id,
                UserName = customer.User.UserName,
                PhoneNumber = customer.User.PhoneNumber,
                Email = customer.User.Email,
                Address = customer.Address,
                CreatedAt = customer.CreatedAt,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Wallet = customer.Wallet,
                CityName = customer.City?.Name,
                PictureId = customer.PictureId,
                ActiveCartId = customer.ActiveCartId,
                PictureUrl = customer.Picture.Url

            };
            return userdto;
        }

        public async Task<AlluserDto> GetCustomerByUserId(int Userid, CancellationToken cancellationToken)
        {
            var customer = await _storeContext.Customers.Where(c=> c.UserId == Userid)
                .Include(u => u.User)
                .Include(c => c.City)
                .FirstOrDefaultAsync(cancellationToken);
            if (customer == null)
            {
                throw new NullReferenceException("User did not found");
            }
            var userdto = new AlluserDto()
            {
                Id = customer.Id,
                UserName = customer.User.UserName,
                PhoneNumber = customer.User.PhoneNumber,
                Email = customer.User.Email,
                Address = customer.Address,
                CreatedAt = customer.CreatedAt,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Wallet = customer.Wallet,
                CityName = customer.City?.Name,
                PictureId = customer.PictureId,
                ActiveCartId = customer.ActiveCartId,

            };
            return userdto;



        }

        public  async Task IsRestored(int id, CancellationToken cancellationToken)
        {
            var record = await _storeContext.Customers
      .Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
            record.IsDeleted = false;

            await _storeContext.SaveChangesAsync(cancellationToken);
        }
    }
}

