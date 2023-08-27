using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CourseComments.Commands.CreateCourseComment
{
    public class CreateCourseCommentCommandHandler : IRequestHandler<CreateCourseCommentCommand, Guid>
    {
        private readonly ICommentService _commentsService;

        public CreateCourseCommentCommandHandler(ICommentService commentsService)
        {
            _commentsService = commentsService;
        }

        public async Task<Guid> Handle(CreateCourseCommentCommand request, CancellationToken cancellationToken)
        {
            return await _commentsService.CreateCourseCommentAsync(request);      
        }

    }
}
