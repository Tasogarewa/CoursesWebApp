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
        private readonly IMapper _mapper;
        private readonly IRepository<Course> _courseRepository;

        public GetCoursesQueryHandler(IMapper mapper, IRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<CourseListVm> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetAllAsync();
            if (courses == null||request.UserId==Guid.Empty)
            {
                throw new NotFoundException(nameof(courses), 0);
            }
            else
                return new CourseListVm() { CoursesList = await _mapper.ProjectTo<CourseDto>((IQueryable)courses).ToListAsync() };
        }
    }
}
