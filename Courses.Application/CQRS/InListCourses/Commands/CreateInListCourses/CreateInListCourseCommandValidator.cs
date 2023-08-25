using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.InListCourses.Commands.CreateInListCourses
{
    public class CreateInListCourseCommandValidator:AbstractValidator<CreateInListCourseCommand>
    {
        public CreateInListCourseCommandValidator() 
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserNamedListId).NotEqual(Guid.Empty);

        }
    }
}
