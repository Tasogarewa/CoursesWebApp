using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.CreateCourseChat
{
    public class CreateCourseChatCommandValidator:AbstractValidator<CreateCourseChatCommand>
    {
        public CreateCourseChatCommandValidator() 
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x => x.MentorId).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(10).MaximumLength(50);

        }
    }
}
