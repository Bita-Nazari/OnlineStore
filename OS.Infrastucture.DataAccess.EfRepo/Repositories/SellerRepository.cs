using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public SellerRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        public async Task DeleteSeller(int id, CancellationToken cancellationToken)
        {
            var seller = await _storeContext.Sellers
           .Where(p => p.Id == id)
           .FirstOrDefaultAsync();
            if (seller == null)
            {
                throw new NullReferenceException(nameof(seller));
            }
            seller.IsDeleted = true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }



        public async Task EditSeller(AlluserDto user, CancellationToken cancellationToken)
        {
            var User = await _storeContext.Sellers.Where(s => s.Id == user.Id)
                 .Include(u => u.User)
                 .Include(u => u.City).FirstOrDefaultAsync();
            if (User == null)
            {
                throw new NullReferenceException("user did not found");
            }
            User.FirstName = user.FirstName;
            User.LastName = user.LastName;
            User.CityId = user.CityId;
            User.NationalCode = user.NationalCode;
            User.ShabaNumber = user.ShabaNumber;
            User.Wallet = user.Wallet;
            User.User.Email = user.Email;
            User.User.PhoneNumber = user.PhoneNumber;
            User.User.UserName = user.UserName;
            await _storeContext.SaveChangesAsync(cancellationToken);

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



        public async Task<List<AlluserDto>> GetAllSellers(CancellationToken cancellationToken)
        {
            var user = await _storeContext.Sellers.AsNoTracking().Select(a => new AlluserDto()
            {
                Id = a.Id,
                UserName = a.User.UserName,
                PhoneNumber = a.User.PhoneNumber,
                Email = a.User.Email,
                CreatedAt = a.CreatedAt,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Wallet = a.Wallet,
                ShabaNumber = a.ShabaNumber,
                CityName = a.City.Name,
                NationalCode = a.NationalCode,
                IsDeleted = a.IsDeleted,



            }).ToListAsync();
            return user;
        }








        public async Task<AlluserDto> GetSellerById(int SellerId, CancellationToken cancellationToken)
        {
            var seller = await _storeContext.Sellers
                .Where(c => c.Id == SellerId)
                .Include(u => u.User).Include(c => c.City)
                .FirstOrDefaultAsync(cancellationToken);
            if (seller == null)
            {
                throw new NullReferenceException("User did not found");
            }
            var userdto = new AlluserDto()
            {
                Id = SellerId,
                UserName = seller.User.UserName,
                PhoneNumber = seller.User.PhoneNumber,
                Email = seller.User.Email,
                ShabaNumber = seller.ShabaNumber,
                NationalCode = seller.NationalCode,
                PictureId = seller.PictureId,
                CreatedAt = seller.CreatedAt,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Wallet = seller.Wallet,
                CityName = seller.City?.Name,
                
    

            };
            return userdto;
        }


    }
}

