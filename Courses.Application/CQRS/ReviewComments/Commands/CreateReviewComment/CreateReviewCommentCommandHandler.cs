using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.ReviewComments.Commands.CreateReviewComment
{
    public class CreateReviewCommentCommandHandler : IRequestHandler<CreateReviewCommentCommand, Guid>
    {
       private readonly ICommentService _commentsService;

        public CreateReviewCommentCommandHandler(ICommentService commentsService)
        {
            _commentsService = commentsService;
        }

        public async Task<Guid> Handle(CreateReviewCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentsService.CreateReviewCommentAsync(request);
        }
    }
}
