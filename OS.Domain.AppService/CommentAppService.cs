using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;
        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;   
        }
        public async Task Create(CommentDto commentDto, CancellationToken cancellationToken)
        {
           await _commentService.Create(commentDto, cancellationToken);
        }

        public Task<CommentDto> Detail(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            return _commentService.GetAll(cancellationToken);
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
            await _commentService.Confirm(commentId, cancellationToken);
        }

        public Task Update(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<BoothDto> GetAllBoothComment(int boothid, CancellationToken cancellationToken)
        {
          return await _commentService.GetAllBoothComment(boothid, cancellationToken);
        }

        public Task IsRestored(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
