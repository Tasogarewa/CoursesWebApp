using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.MentorComments.Commands.CreateMentorComment
{
    public class CreateMentorCommentCommandValidator:AbstractValidator<CreateMentorCommentCommand>
    {
        public CreateMentorCommentCommandValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.MentorId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(3000);
        }
    }
}
