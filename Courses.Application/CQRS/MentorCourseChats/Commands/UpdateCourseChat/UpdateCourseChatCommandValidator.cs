using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.UpdateCourseChat
{
    public class UpdateCourseChatCommandValidator:AbstractValidator<UpdateCourseChatCommand>
    {
        public UpdateCourseChatCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(10).MaximumLength(50);
        }
    }
}
