using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.UpdateUserNamedList
{
    public class UpdateUserNamedListCommandValidator:AbstractValidator<UpdateUserNamedListCommand>
    {
        public UpdateUserNamedListCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4).MaximumLength(50);
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
