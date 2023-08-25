using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.CreateWishedCourse
{
    public class CreateWishedCourseCommandValidator:AbstractValidator<CreateWishedCourseCommand>
    {
        public CreateWishedCourseCommandValidator() 
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
