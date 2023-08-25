using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.UpdateLectionNotice
{
    public class UpdateLectionNoticeCommandValidator:AbstractValidator<UpdateLectionNoticeCommand>
    {
        public UpdateLectionNoticeCommandValidator() 
        {
            RuleFor(x => x.From).NotEmpty();
            RuleFor(x => x.Text).NotEmpty().MaximumLength(2000);
        }
    }
}
