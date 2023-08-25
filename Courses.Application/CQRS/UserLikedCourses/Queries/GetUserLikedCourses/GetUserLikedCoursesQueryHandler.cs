using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserLikedCourses.Queries.GetUserLikedCourses
{
    public class GetUserLikedCoursesQueryHandler : IRequestHandler<GetUserLikedCoursesQuery, UserLikedCoursesVm>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetUserLikedCoursesQueryHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserLikedCoursesVm> Handle(GetUserLikedCoursesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null || request.UserId == Guid.Empty)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }
            else
               return _mapper.Map<UserLikedCoursesVm>(user.LikedCourses);
        }
    }
}
