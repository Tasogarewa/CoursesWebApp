using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.DeleteCourseChat
{
    public class DeleteCourseChatCommandHandler : IRequestHandler<DeleteCourseChatCommand, Unit>
    {
      private readonly ICourseChatService _courseChatService;

        public DeleteCourseChatCommandHandler(ICourseChatService courseChatService)
        {
            _courseChatService = courseChatService;
        }

        public async Task<Unit> Handle(DeleteCourseChatCommand request, CancellationToken cancellationToken)
        {
            return await _courseChatService.DeleteCourseChatAsync(request);
        }
    }
}
