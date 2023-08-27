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

namespace Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Guid>
    {
        private readonly ICourseService _courseService;

        public UpdateCourseCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<Guid> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            return await _courseService.UpdateCourseAsync(request);
        }
    }
}
