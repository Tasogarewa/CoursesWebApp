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

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourses
{
    public class GetMentorCoursesQueryHandler : IRequestHandler<GetMentorCoursesQuery, CourseListVm>
    {
      private readonly ICourseService _courseService;

        public GetMentorCoursesQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<CourseListVm> Handle(GetMentorCoursesQuery request, CancellationToken cancellationToken)
        {
            return await _courseService.GetMentorCoursesAsync(request);
        }
    }
}
