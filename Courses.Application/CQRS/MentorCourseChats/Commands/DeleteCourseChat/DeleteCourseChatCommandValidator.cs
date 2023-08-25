using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorCourseChats.Commands.DeleteCourseChat
{
    public class DeleteCourseChatCommandValidator:AbstractValidator<DeleteCourseChatCommand>
    {
        public DeleteCourseChatCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }

    }
}
