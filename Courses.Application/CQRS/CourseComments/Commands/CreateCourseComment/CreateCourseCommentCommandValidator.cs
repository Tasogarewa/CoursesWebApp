using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CourseComments.Commands.CreateCourseComment
{
    public class CreateCourseCommentCommandValidator:AbstractValidator<CreateCourseCommentCommand>
    {
        public CreateCourseCommentCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(3000);
          
        }
    }
}
