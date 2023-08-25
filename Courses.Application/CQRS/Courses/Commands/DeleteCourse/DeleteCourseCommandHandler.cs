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

namespace Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly IRepository<Course> _courseRepository;

        public DeleteCourseCommandHandler(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAsync(request.Id);
            if (course == null || request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(course), request.Id);
            }
            else
              await  _courseRepository.Delete(course);
            return Unit.Value;
        }
    }
}
