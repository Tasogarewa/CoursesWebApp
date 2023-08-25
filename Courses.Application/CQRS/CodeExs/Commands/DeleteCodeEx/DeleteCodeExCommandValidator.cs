using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CodeExs.Commands.DeleteCodeEx
{
    public class DeleteCodeExCommandValidator:AbstractValidator<DeleteCodeExCommand>
    {
        public DeleteCodeExCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
