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
      private readonly IArchivedCourseService _archivedCourseService;

        public CreateArchivedCourseCommandHandler(IArchivedCourseService archivedCourseService)
        {
            _archivedCourseService = archivedCourseService;
        }

        public async Task<Guid> Handle(CreateArchivedCourseCommand request, CancellationToken cancellationToken)
        {
            return await _archivedCourseService.CreateArchivedCourseAsync(request);
        }
    }
}
