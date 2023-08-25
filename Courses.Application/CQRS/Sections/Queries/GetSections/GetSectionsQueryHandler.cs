using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Sections.Queries.GetSections
{
    public class GetSectionsQueryHandler : IRequestHandler<GetSectionsQuery, SectionListVm>
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public GetSectionsQueryHandler(IRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<SectionListVm> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(request.CourseId);
            var sections = course.Sections;
            if (course == null || request.CourseId == Guid.Empty)
            {
                throw new NotFoundException(nameof(course), request.CourseId);
            }
            else
                return new SectionListVm() { sectionDtos = await _mapper.ProjectTo<SectionDto>((IQueryable)sections).ToListAsync() };
        }
    }
}
