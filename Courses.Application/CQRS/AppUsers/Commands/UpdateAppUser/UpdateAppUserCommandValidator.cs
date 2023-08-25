using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommandValidator:AbstractValidator<UpdateAppUserCommand>
    {
        public UpdateAppUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Name).NotNull().MinimumLength(4).MaximumLength(35);
            RuleFor(x => x.Surname).NotNull().MinimumLength(4).MaximumLength(35);
        }
    }
}
