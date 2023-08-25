using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AnnouncmentComments.Commands.CreateAnnouncmentComment
{
    public class CreateAnnouncmentCommentCommandValidator:AbstractValidator<CreateAnnouncmentCommentCommand>
    {
        public CreateAnnouncmentCommentCommandValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.AnnouncmentId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(3000);
        }
    }
}
