using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.InListCourses.Commands.DeleteInListCourses
{
    public class DeleteInListCourseCommandValidator:AbstractValidator<DeleteInListCourseCommand>
    {
        public DeleteInListCourseCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
