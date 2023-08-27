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
      private readonly IUserService _userService;

        public GetUserLikedCoursesQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserLikedCoursesVm> Handle(GetUserLikedCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetLikedCoursesAsync(request);
        }
    }
}
