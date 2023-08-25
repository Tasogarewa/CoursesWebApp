using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommandValidator:AbstractValidator<UpdateSectionCommand>
    {
        public UpdateSectionCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(10).MaximumLength(50);
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
