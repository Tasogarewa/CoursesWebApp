using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserLikedCourse.Commands.CreateUserLikedCourse
{
    public class CreateUserLikedCourseCommandValidator:AbstractValidator<CreateUserLikedCourseCommand>
    {
        public CreateUserLikedCourseCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x=>x.UserId).NotEqual(Guid.Empty);
        }
    }
}
