using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.AnnouncmentComments.Commands.CreateAnnouncmentComment
{
    public class CreateAnnouncmentCommentCommandHandler:IRequestHandler<CreateAnnouncmentCommentCommand,Guid>
    {
        private readonly ICommentService _commentsService;

        public CreateAnnouncmentCommentCommandHandler(ICommentService commentsService)
        {
            _commentsService = commentsService;
        }

        public async Task<Guid> Handle(CreateAnnouncmentCommentCommand request, CancellationToken cancellationToken)
        {

            return await _commentsService.CreateAnnouncmentCommentAsync(request);
        }
    }
}
