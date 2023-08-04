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
            RuleFor(course => course.Expires).GreaterThan(DateTime.Now);
            RuleFor(course => course.UserId).NotEqual(Guid.Empty);
            RuleFor(course => course.Price).NotEmpty().LessThanOrEqualTo(500).GreaterThan(15);
            RuleFor(course => course.Name).NotEmpty().MaximumLength(30);
            RuleFor(course => course.Description).NotEmpty().MaximumLength(2000);
            RuleFor(course => course.FilePath).NotEmpty();
            RuleFor(course => course.Images).NotEmpty();
           
        }
    }
}
