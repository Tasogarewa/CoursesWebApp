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
        private readonly IArchivedCourseService _archivedCourseService;

        public DeleteArchivedCourseCommandHandler(IArchivedCourseService archivedCourseService)
        {
            _archivedCourseService = archivedCourseService;
        }

        public async Task<Unit> Handle(DeleteArchivedCourseCommand request, CancellationToken cancellationToken)
        {
            return await _archivedCourseService.DeleteArchivedCourseAsync(request);
        }
    }
}
