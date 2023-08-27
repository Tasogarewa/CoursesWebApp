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
       private readonly ICommentService _commentsService;

        public UpdateCommentCommandHandler(ICommentService commentsService)
        {
            _commentsService = commentsService;
        }

        public async Task<Guid> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentsService.UpdateCommentAsync(request);
        }
    }
}
