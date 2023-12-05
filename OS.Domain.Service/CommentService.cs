using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task Create(CommentDto commentDto, CancellationToken cancellationToken)
        {
            await _commentRepository.Create(commentDto, cancellationToken);
        }

        public Task<CommentDto> Detail(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            return _commentRepository.GetAll(cancellationToken);
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
            await _commentRepository.Confirm(commentId, cancellationToken);
        }

        public async Task<BoothDto> GetAllBoothComment(int boothid, CancellationToken cancellationToken)
        {
           return await _commentRepository.GetAllBoothComment(boothid, cancellationToken);
        }
    }
}
