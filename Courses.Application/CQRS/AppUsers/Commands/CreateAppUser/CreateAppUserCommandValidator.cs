using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.CreateAppUser
{
    public class CreateAppUserCommandValidator:AbstractValidator<CreateAppUserCommand>
    {
        public CreateAppUserCommandValidator() 
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Name).NotNull().MinimumLength(4).MaximumLength(35);
            RuleFor(x=>x.Surname).NotNull().MinimumLength(4).MaximumLength(35);
        }
    }
}
