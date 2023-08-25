using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Lections.Commands.CreateLection
{
    public class CreateLectionCommandValidator:AbstractValidator<CreateLectionCommand>
    {
        public CreateLectionCommandValidator() 
        {
            RuleFor(x=>x.Name).NotEmpty().MinimumLength(10).MaximumLength(200);
            RuleFor(x => x.SectionId).NotEqual(Guid.Empty);
        }
    }
}
