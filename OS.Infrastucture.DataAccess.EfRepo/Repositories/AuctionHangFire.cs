using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;
using OS.Infrastucture.DataAccess.EfRepo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OS.Infrastucture.Db.SqlServer.Config;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class AuctionHangFire
    {
        private readonly OnlineStoreContext _onlineStoreContext;
        private readonly IConfiguration _configuration;
        public AuctionHangFire(OnlineStoreContext onlineStoreContext, IConfiguration configuration)
        {
            _onlineStoreContext = onlineStoreContext;
            _configuration = configuration;

        }


        public  void StartAuction(int auctionId)
        {
           var auction =  _onlineStoreContext.Auctions.Where(a=> a.Id== auctionId).FirstOrDefault();
            if (auction != null)
            {
                auction.IsDisabled = false;
                auction.IsStarted = true;
                _onlineStoreContext.SaveChanges();
            }
        }

        public  void CloseAuction(int auctionId)
        {
            var auction =  _onlineStoreContext.Auctions.Where(a => a.Id == auctionId)
                .Include(b=> b.Bids)
                .ThenInclude(b=> b.Customer)
                .Include(b=> b.Booth)
                .ThenInclude(b=> b.Seller)
                .Include(b => b.Booth)
                .ThenInclude(b=>b.Medal)
                .FirstOrDefault();
            var admin = _onlineStoreContext.Admins.Where(a=> a.Id == 2).FirstOrDefault();
            if (auction != null)
            {
                if (auction.BidCount != 0)
                {
                    int winnerId = auction.Bids.OrderByDescending(b => b.SuggestedPrice).First().CustomerId;
                    auction.CustomerId = winnerId;
                    auction.IsStarted = false;
                    _onlineStoreContext.SaveChanges();

                    foreach (var customer in auction.Bids)
                    {
                        customer.Customer.Wallet += customer.SuggestedPrice;
                        admin.Wallet -= customer.SuggestedPrice;
                    }

                    var winner = _onlineStoreContext.Customers.Where(c => c.Id == auction.CustomerId).FirstOrDefault();
                    winner.Wallet = winner.Wallet - auction.StartPrice;
                    //auction.Booth.Seller.Wallet += auction.StartPrice;
                    _onlineStoreContext.SaveChanges();
                    var order = new Order()
                    {
                        AuctionId = auction.Id,
                        CustomerId = winner.Id,
                        TotalPrice = auction.StartPrice,
                        StatusId = 1
                    };
                    _onlineStoreContext.Orders.Add(order);

                    var MedalId = auction.Booth.MedalId;
                    var commissionRate = GetCommission(MedalId);
                    var commission = (int)(auction.StartPrice * commissionRate);
                    var finalPrice = auction.StartPrice - commission;
                    admin.Wallet += commission;
                    auction.Booth.Seller.Wallet += finalPrice;
                   auction.Booth.TotalCount += 1;

                   
                    _onlineStoreContext.SaveChanges();


                }
                else
                {
                    auction.IsDisabled=true;
                    auction.IsStarted=false;
                _onlineStoreContext.SaveChanges();
                }
            }
        }
        public decimal GetCommission(int? MedalId)
        {

            var commissionConfig = _configuration.GetSection("CommissionConfig").Get<CommissionConfig>();

            if (MedalId == 1)
            {
                return commissionConfig.Bronze;
            }
            else if (MedalId == 2)
            {
                return commissionConfig.Silver;
            }
            else
            {
                return commissionConfig.Gold;
            }
        }
    }
  
}
