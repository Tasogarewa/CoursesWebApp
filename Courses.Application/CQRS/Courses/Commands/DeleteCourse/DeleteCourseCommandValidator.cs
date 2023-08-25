using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandValidator:AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator() 
        {
  
            RuleFor(course => course.Id).NotEqual(Guid.Empty);
        }
    }
}
