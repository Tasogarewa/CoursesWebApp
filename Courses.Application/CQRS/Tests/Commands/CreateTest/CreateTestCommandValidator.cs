using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Tests.Commands.CreateTest
{
    public class CreateTestCommandValidator:AbstractValidator<CreateTestCommand>
    {
        public CreateTestCommandValidator() 
        {
            RuleFor(x => x.Questions).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(10).MaximumLength(50);
            RuleFor(x=>x.Description).NotEmpty().MinimumLength(50).MaximumLength(500);
            RuleFor(x => x.LectionId).NotEqual(Guid.Empty);
        }
    }
}
