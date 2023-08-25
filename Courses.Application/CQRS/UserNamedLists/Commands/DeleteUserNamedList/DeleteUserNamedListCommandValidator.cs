using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserNamedLists.Commands.DeleteUserNamedList
{
    public class DeleteUserNamedListCommandValidator:AbstractValidator<DeleteUserNamedListCommand>
    {
        public DeleteUserNamedListCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
