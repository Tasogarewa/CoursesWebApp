using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.LectionNotices.Commands.DeleteLectionNotice
{
    public class DeleteLectionNoticeCommandValidator:AbstractValidator<DeleteLectionNoticeCommand>
    {
        public DeleteLectionNoticeCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
