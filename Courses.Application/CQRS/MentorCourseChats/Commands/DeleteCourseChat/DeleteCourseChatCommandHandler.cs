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
        private readonly IRepository<CourseChat> _courseChatRepository;

        public DeleteCourseChatCommandHandler(IRepository<CourseChat> courseChatRepository)
        {
            _courseChatRepository = courseChatRepository;
        }

        public async Task<Unit> Handle(DeleteCourseChatCommand request, CancellationToken cancellationToken)
        {
            var courseChat = await _courseChatRepository.GetAsync(request.Id);
            if (courseChat == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(courseChat), request.Id);
            }
            else
              await  _courseChatRepository.Delete(courseChat);
            return Unit.Value;
        }
    }
}
