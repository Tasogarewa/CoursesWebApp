using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.DeleteArchivedCourse
{
    public class DeleteArchivedCourseCommandHandler : IRequestHandler<DeleteArchivedCourseCommand, Unit>
    {
        private readonly IRepository<ArchivedCourse> _archivedCourseRepository;

        public DeleteArchivedCourseCommandHandler(IRepository<ArchivedCourse> archivedCourseRepository)
        {
            _archivedCourseRepository = archivedCourseRepository;
        }

        public async Task<Unit> Handle(DeleteArchivedCourseCommand request, CancellationToken cancellationToken)
        {
            var archivedCourse = await _archivedCourseRepository.GetAsync(request.Id);

            if (archivedCourse == null||request.CourseId==Guid.Empty) 
            {
                throw new NotFoundException(nameof(archivedCourse), request.Id);
            }
            else
            {
                 await _archivedCourseRepository.Delete(archivedCourse);
            }
            return Unit.Value;
        }
    }
}
