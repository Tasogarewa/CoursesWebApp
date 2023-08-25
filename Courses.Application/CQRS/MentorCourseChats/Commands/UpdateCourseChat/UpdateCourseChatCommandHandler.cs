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
        private readonly IRepository<CourseChat> _courseChatRepository;

        public UpdateCourseChatCommandHandler(IRepository<CourseChat> courseChatRepository)
        {
            _courseChatRepository = courseChatRepository;
        }

        public async Task<Guid> Handle(UpdateCourseChatCommand request, CancellationToken cancellationToken)
        {
            var courseChat = await _courseChatRepository.GetAsync(request.Id);
            if (courseChat == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(courseChat), request.Id);
            }
            else
            {
                courseChat.Name = request.Name;
               await _courseChatRepository.Update(courseChat);
            }
            return request.Id;
        }
    }
}
