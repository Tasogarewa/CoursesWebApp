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

namespace Tasogarewa.Application.CQRS.UserNamedCourseLists.Queries.GetUserNamedCoureList
{
    public class GetUserNamedCourseListQueryHandler : IRequestHandler<GetUserNamedCourseListQuery, UserNamedCourseListVm>
    {
    private readonly IUserService _userService;

        public GetUserNamedCourseListQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserNamedCourseListVm> Handle(GetUserNamedCourseListQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetNamedCourseListsAsync(request);
        }
    }
}
