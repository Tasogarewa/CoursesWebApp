using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Comments.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Guid>
    {
        private readonly IRepository<Comment> _commentRepository;

        public UpdateCommentCommandHandler(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Guid> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetAsync(request.Id);
            if (comment == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(comment), request.Id);
            }
            else
            {
                comment.UpdateAt = DateTime.Now;
                comment.Text = request.Text;
                comment.Replay = request.Replay;
              await  _commentRepository.Update(comment);
            }
            return comment.Id;
        }
    }
}
