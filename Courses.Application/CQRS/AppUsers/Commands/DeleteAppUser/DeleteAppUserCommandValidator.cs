using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.AppUsers.Commands.DeleteAppUser
{
    public class DeleteAppUserCommandValidator:AbstractValidator<DeleteAppUserCommand>
    {
        public DeleteAppUserCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
