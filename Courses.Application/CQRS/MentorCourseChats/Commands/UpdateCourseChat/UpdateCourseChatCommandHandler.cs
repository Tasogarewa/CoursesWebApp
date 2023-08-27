using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.UpdateCourseChat
{
    public class UpdateCourseChatCommandHandler : IRequestHandler<UpdateCourseChatCommand, Guid>
    {
        private readonly ICourseChatService _courseChatService;

        public UpdateCourseChatCommandHandler(ICourseChatService courseChatService)
        {
            _courseChatService = courseChatService;
        }

        public async Task<Guid> Handle(UpdateCourseChatCommand request, CancellationToken cancellationToken)
        {

            return await _courseChatService.UpdateCourseChatAsync(request);
        }
    }
}
