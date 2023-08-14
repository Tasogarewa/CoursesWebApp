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
        private readonly IMapper Mapper;
        private readonly IRepository<Course> CoursesRepository;
        public GetCourseQueryHandler(IRepository<Course> repository,IMapper mapper)
        {
            CoursesRepository = repository;
            Mapper = mapper;
        }

        public async Task<CourseVm> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await CoursesRepository.GetAsync(request.Id);
            if (course == null|| course.Id!=request.Id)
            {
                throw new NotFoundException(nameof(course), request.Id);
            }
            else
                return Mapper.Map<CourseVm>(course);
        }
    }
}
