using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChats
{
    public class GetUserCourseChatsQueryHandler : IRequestHandler<GetUserCourseChatsQuery, UserCourseChatListVm>
    {
        private readonly IMapper _mapper;
        private IRepository<AppUser> _userRepository;

        public GetUserCourseChatsQueryHandler(IMapper mapper, IRepository<AppUser> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserCourseChatListVm> Handle(GetUserCourseChatsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null || request.UserId == Guid.Empty)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }
            else
                return new UserCourseChatListVm() { courseChatDtos = await _mapper.ProjectTo<UserCourseChatDto>((IQueryable)user.CourseChats).ToListAsync()};
        }
    }
}
