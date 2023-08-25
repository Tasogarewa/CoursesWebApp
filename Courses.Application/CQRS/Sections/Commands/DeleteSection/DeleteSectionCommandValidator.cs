using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommandValidator:AbstractValidator<DeleteSectionCommand>
    {
        public DeleteSectionCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
