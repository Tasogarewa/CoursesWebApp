using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CourseStudents.Commands.CreateCourseStudents
{
    public class CreateCourseStudentCommandValidator:AbstractValidator<CreateCourseStudentCommand>
    {
        public CreateCourseStudentCommandValidator()
         {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x=>x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Lections).NotEqual(0);
        }
    }
}
