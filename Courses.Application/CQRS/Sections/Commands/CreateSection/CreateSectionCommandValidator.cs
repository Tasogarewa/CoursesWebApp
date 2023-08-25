using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Sections.Commands.CreateSection
{
    public class CreateSectionCommandValidator:AbstractValidator<CreateSectionCommand>
    {
        public CreateSectionCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
        }
    }
}
