using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.CreateUserNamedList
{
    public class CreateUserNamedListCommandValidator:AbstractValidator<CreateUserNamedListCommand>
    {
        public CreateUserNamedListCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4).MaximumLength(50);
        }
    }
}
