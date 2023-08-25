using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.CreateLectionNotice
{
    public class CreateLectionNoticeCommandValidator:AbstractValidator<CreateLectionNoticeCommand>
    {
        public CreateLectionNoticeCommandValidator() 
        {
            RuleFor(x => x.From).NotEmpty();
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x=>x.LectionId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).NotEmpty().MaximumLength(2000);
        }
    }
}
