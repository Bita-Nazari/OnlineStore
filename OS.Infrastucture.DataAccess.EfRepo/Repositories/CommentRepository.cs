﻿using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public CommentRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(CommentDto commentDto, CancellationToken cancellationToken)
        {
            var comment = new Comment()
            {
                Text = commentDto.Text,
                BoothId = commentDto.BoothId,
                CustomerId = commentDto.CustomerId,
                IsDeleted = false,
                OrderId = commentDto.OrderId,
                CreatedAt = DateTime.Now,
                IsConfirmed = false

            }; 
           await _storeContext.Comments.AddAsync(comment);
           await _storeContext.SaveChangesAsync();


        }

        public Task<CommentDto> Detail(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
           
            var Comments = await _storeContext.Comments.Include(x=> x.Booth).Include(c=>c.Customer).Select(
               x=> new CommentDto
               {
                   Text= x.Text,
                   Id = x.Id,
                   IsDeleted= x.IsDeleted,
                   IsConfirmed= x.IsConfirmed,
                   BoothName = x.Booth.Name,
                   CustomerName = x.Customer.FirstName + " "+ x.Customer.LastName,

               }
                
                
                ).ToListAsync(cancellationToken);
            return Comments;
        }

        public Task<List<CommentDto>> GetProductComments(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Confirm(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _storeContext.Comments.Where(c => c.Id == commentId).FirstOrDefaultAsync();
            comment.IsConfirmed = true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<BoothDto> GetAllBoothComment(int boothid, CancellationToken cancellationToken)
        {
            var booth = await _storeContext.Booths.Where(b=> b.Id == boothid)
                .Include(b=> b.Comments)
                .ThenInclude(c=> c.Customer)
                .FirstOrDefaultAsync();
            var comments = new BoothDto
            {
                Comments = booth.Comments.ToList(),

            };
            return comments;
        }

        public Task IsRestored(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetAllCustomerComment(int id, CancellationToken cancellationToken)
        {
           var comments = await _storeContext.Comments.Where(c=>c.CustomerId == id).
                Include(c=> c.Customer)
                .Include(c=> c.Booth)
                .Select(c=> new CommentDto
                {
                    Id = c.Id,
                    CustomerName = c.Customer.FirstName + " " + c.Customer.LastName,
                    IsDeleted = c.IsDeleted,
                    IsConfirmed = c.IsConfirmed,
                    BoothName = c.Booth.Name,
                    Text = c.Text
                }).ToListAsync();
            return comments;
        }
    }
}
