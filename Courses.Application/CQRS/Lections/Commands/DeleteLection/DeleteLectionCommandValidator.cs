using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Commands.DeleteLection
{
    public class DeleteLectionCommandValidator:AbstractValidator<DeleteLectionCommand>
    {
        public DeleteLectionCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
