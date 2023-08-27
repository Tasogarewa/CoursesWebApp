using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat
{
    public class CreateCourseChatCommandHandler : IRequestHandler<CreateCourseChatCommand, Guid>
    {
        private readonly ICourseChatService _courseChatService;

        public CreateCourseChatCommandHandler(ICourseChatService courseChatService)
        {
            _courseChatService = courseChatService;
        }

        public async Task<Guid> Handle(CreateCourseChatCommand request, CancellationToken cancellationToken)
        {
            return await _courseChatService.CreateCourseChatAsync(request);
        }
    }
}
