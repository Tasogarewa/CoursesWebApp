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
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Announcments.Queries.GetAnnouncments
{
    public class GetAnnouncmentsQueryHandler : IRequestHandler<GetAnnouncmentsQuery, AnnouncmentListVm>
    {
            private readonly IRepository<Course> _courseRepository;
            private readonly IMapper _mapper;
        public GetAnnouncmentsQueryHandler(IRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<AnnouncmentListVm> Handle(GetAnnouncmentsQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(request.CourseId);
            if(course == null||request.CourseId==Guid.Empty)
            {
                throw new NotFoundException(nameof(course), request.CourseId);
            }
            else
            {
                return new AnnouncmentListVm { AnnouncmentDtos = await _mapper.ProjectTo<AnnouncmentDto>((IQueryable)course.Announcements).ToListAsync() };
            }
        }
    }
}
