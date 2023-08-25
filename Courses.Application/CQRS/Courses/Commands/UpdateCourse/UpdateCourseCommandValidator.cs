using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator:AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator() 
        {
            RuleFor(course => course.Id).NotEqual(Guid.Empty);
        }
    }
}
