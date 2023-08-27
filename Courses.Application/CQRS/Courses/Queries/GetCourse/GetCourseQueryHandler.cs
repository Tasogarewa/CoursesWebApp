using AutoMapper;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Courses.Queries.GetCourse
{
    public class GetCourseQueryHandler:IRequestHandler<GetCourseQuery,CourseVm>
    {
      private readonly ICourseService _courseService;

        public GetCourseQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<CourseVm> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            return await _courseService.GetCourseAsync(request);
        }
    }
}
