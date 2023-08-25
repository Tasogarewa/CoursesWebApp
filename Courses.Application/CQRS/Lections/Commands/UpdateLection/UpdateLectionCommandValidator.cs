using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Commands.UpdateLection
{
    public class UpdateLectionCommandValidator:AbstractValidator<UpdateLectionCommand>
    {
        public UpdateLectionCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(10).MaximumLength(200);
            RuleFor(x => x.FilePath).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().MinimumLength(100).MaximumLength(500);
        }
    }
}
