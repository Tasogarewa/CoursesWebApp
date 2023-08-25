using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChat
{
    public class GetUserCourseChatQueryHandler : IRequestHandler<GetUserCourseChatQuery, UserCourseChatVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CourseChat> _courseChatRepository;

        public GetUserCourseChatQueryHandler(IMapper mapper, IRepository<CourseChat> courseChatRepository)
        {
            _mapper = mapper;
            _courseChatRepository = courseChatRepository;
        }

        public async Task<UserCourseChatVm> Handle(GetUserCourseChatQuery request, CancellationToken cancellationToken)
        {
            var courseChat = await _courseChatRepository.GetAsync(request.Id);
            if (courseChat == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(courseChat), request.Id);
            }
            else
                return _mapper.Map<UserCourseChatVm>(courseChat);

        }
    }
}
