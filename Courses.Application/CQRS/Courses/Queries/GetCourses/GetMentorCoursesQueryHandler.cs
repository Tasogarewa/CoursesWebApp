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
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IMapper _mapper;

        public GetMentorCoursesQueryHandler(IRepository<Mentor> mentorRepository, IMapper mapper)
        {
            _mentorRepository = mentorRepository;
            _mapper = mapper;
        }

        public async Task<CourseListVm> Handle(GetMentorCoursesQuery request, CancellationToken cancellationToken)
        {
            var mentor = await _mentorRepository.GetAsync(request.MentorId);
            if (mentor == null || request.MentorId == Guid.Empty)
            {
                throw new NotFoundException(nameof(mentor), 0);
            }
            else
                return new CourseListVm() { CoursesList = await _mapper.ProjectTo<CourseDto>((IQueryable)mentor.Courses).ToListAsync() };
        }
    }
}
