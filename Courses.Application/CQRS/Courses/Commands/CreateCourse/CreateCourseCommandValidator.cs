using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator:AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator() 
        {
            RuleFor(x => x.CourseTags).NotEmpty();
            RuleFor(x => x.MentorId).NotEqual(Guid.Empty);
            RuleFor(course => course.Name).NotEmpty().MaximumLength(100);
          
           
        }
    }
}
