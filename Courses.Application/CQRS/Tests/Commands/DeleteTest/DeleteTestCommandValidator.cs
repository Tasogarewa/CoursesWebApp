using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Tests.Commands.DeleteTest
{
    public class DeleteTestCommandValidator:AbstractValidator<DeleteTestCommand>
    {
        public DeleteTestCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }

    }
}
