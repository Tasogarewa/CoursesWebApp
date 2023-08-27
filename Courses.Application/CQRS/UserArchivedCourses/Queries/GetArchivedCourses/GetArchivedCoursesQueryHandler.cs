using AutoMapper;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.CQRS.Courses.Queries.GetCourse;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserArchivedCourses.Queries.GetArchivedCourses
{
    public class GetArchivedCoursesQueryHandler : IRequestHandler<GetArchivedCoursesQuery, ArchivedCourseVm>
    {
       private readonly IUserService _userService;

        public GetArchivedCoursesQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ArchivedCourseVm> Handle(GetArchivedCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetArchivedCoursesAsync(request);
        }
    }
}
