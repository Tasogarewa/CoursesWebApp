using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.CourseStudents.Commands.CreateCourseStudents
{
    public class CreateCourseStudentCommandHandler : IRequestHandler<CreateCourseStudentCommand, Guid>
    {
        private readonly ICourseStudentService _courseStudentService;

        public CreateCourseStudentCommandHandler(ICourseStudentService courseStudentService)
        {
            _courseStudentService = courseStudentService;
        }

        public async Task<Guid> Handle(CreateCourseStudentCommand request, CancellationToken cancellationToken)
        {
            return await _courseStudentService.CreateCourseStudentAsync(request);
         }
    }
}
