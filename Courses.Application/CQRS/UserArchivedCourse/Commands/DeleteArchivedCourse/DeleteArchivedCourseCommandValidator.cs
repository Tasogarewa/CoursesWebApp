using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserArchivedCourse.Commands.DeleteArchivedCourse
{
    public class DeleteArchivedCourseCommandValidator:AbstractValidator<DeleteArchivedCourseCommand>
    {
        public DeleteArchivedCourseCommandValidator() 
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x=>x.Id).NotEqual(Guid.Empty);
        }
    }
}
