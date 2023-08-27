using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorComments.Commands.CreateMentorComment
{
    public class CreateMentorCommentCommandHandler : IRequestHandler<CreateMentorCommentCommand, Guid>
    {
      private readonly ICommentService _commentsService;

        public CreateMentorCommentCommandHandler(ICommentService commentsService)
        {
            _commentsService = commentsService;
        }

        public async Task<Guid> Handle(CreateMentorCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentsService.CreateMentorCommentAsync(request);
        }
    }
}
