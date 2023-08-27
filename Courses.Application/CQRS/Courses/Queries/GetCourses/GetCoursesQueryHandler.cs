using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, CourseListVm>
    {
     private readonly ICourseService _courseService;

        public GetCoursesQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<CourseListVm> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _courseService.GetCoursesAsync();
        }
    }
}
