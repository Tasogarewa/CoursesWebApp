using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.CodeExs.Commands.UpdateCodeEx
{
    public class UpdateCodeExCommandValidator:AbstractValidator<UpdateCodeExCommand>
    {
        public UpdateCodeExCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).MinimumLength(20).MinimumLength(100);
            RuleFor(x => x.Description).MinimumLength(500).MinimumLength(2000);
            RuleFor(x => x.Hint).NotNull();
            RuleFor(x => x.Solution).NotNull();
        }

    }
}
