using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.WishedCourses.Commands.DeleteWishedCourse
{
    public class DeleteWishedCourseCommandValidator:AbstractValidator<DeleteWishedCourseCommand>
    {
        public DeleteWishedCourseCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
