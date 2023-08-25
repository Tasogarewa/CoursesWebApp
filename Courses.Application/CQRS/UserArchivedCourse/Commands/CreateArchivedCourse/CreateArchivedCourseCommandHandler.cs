using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.CreateArchivedCourse
{
    public class CreateArchivedCourseCommandHandler : IRequestHandler<CreateArchivedCourseCommand, Guid>
    {
        private readonly IRepository<ArchivedCourse> _archivedCourseRepository;
        private readonly IRepository<Course> _courseRepository;

        public CreateArchivedCourseCommandHandler(IRepository<ArchivedCourse> archivedCourseRepository, IRepository<Course> courseRepository)
        {
            _archivedCourseRepository = archivedCourseRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Guid> Handle(CreateArchivedCourseCommand request, CancellationToken cancellationToken)
        {
            var archivedCourse = await _archivedCourseRepository.Create(new ArchivedCourse() { Course = await _courseRepository.GetAsync(request.Id) });
            return  archivedCourse.Id;    
           }
    }
}
