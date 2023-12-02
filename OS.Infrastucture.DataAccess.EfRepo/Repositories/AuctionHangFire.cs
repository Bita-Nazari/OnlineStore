using Microsoft.EntityFrameworkCore;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class AuctionHangFire
    {
        private readonly OnlineStoreContext _onlineStoreContext;
        public AuctionHangFire(OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
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
                .FirstOrDefault();
            if (auction != null)
            {
                if (auction.BidCount!=0)
                {
                    int winner = auction.Bids.OrderByDescending(b => b.SuggestedPrice).First().CustomerId;
                    auction.CustomerId = winner;
                    auction.IsStarted = false;
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
    }
}
