using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.InListCourses.Commands.DeleteInListCourses
{
    public class DeleteInListCourseCommandHandler:IRequestHandler<DeleteInListCourseCommand,Unit>
    {
        public readonly IRepository<InListCourse> _inListCourse;

        public DeleteInListCourseCommandHandler(IRepository<InListCourse> inListCourse)
        {
            _inListCourse = inListCourse;
        }

        public async Task<Unit> Handle(DeleteInListCourseCommand request, CancellationToken cancellationToken)
        {
            var inListCourse = await _inListCourse.GetAsync(request.Id);
            if (inListCourse == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(inListCourse), request.Id);
            }
            else
               await _inListCourse.Delete(inListCourse);
            return Unit.Value;
        }
    }
}
