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
    public class GetArchivedCoursesQueryHandler : IRequestHandler<GetArchivedCoursesQuery, ArchivedCoursesVm>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AppUser> _userRepository;

        public GetArchivedCoursesQueryHandler(IMapper mapper, IRepository<AppUser> userArchivedCoursesRepository)
        {
            _mapper = mapper;
            _userRepository = userArchivedCoursesRepository;
        }

        public async Task<ArchivedCoursesVm> Handle(GetArchivedCoursesQuery request, CancellationToken cancellationToken)
        {
            var archivedCourses = await _userRepository.GetAsync(request.UserId);
            if (archivedCourses == null || request.UserId==Guid.Empty)
            {
                throw new NotFoundException(nameof(archivedCourses), request.UserId);
            }
            else
                return _mapper.Map<ArchivedCoursesVm>(archivedCourses);
        }
    }
}
