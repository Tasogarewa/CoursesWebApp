using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserLikedCourse.Commands.DeleteUserLikedCourse
{
    public class DeleteUserNamedCourseCommandValidator:AbstractValidator<DeleteUserLikedCourseCommand>
    {
        public DeleteUserNamedCourseCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
