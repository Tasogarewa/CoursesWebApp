﻿using AutoMapper;
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
        private readonly IMapper Mapper;
        private readonly IRepository<Course> CoursesRepository;
        public GetCoursesQueryHandler(Repository<Course> repository, IMapper mapper)
        {
            CoursesRepository = repository;
            Mapper = mapper;
        }

        public async Task<CourseListVm> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await CoursesRepository.GetAllAsync();
            if (courses == null)
            {
                throw new NotFoundException(nameof(courses), 0);
            }
            else
                return new CourseListVm() { CoursesList = await Mapper.ProjectTo<CourseDto>((IQueryable)courses).ToListAsync() };
        }
    }
}