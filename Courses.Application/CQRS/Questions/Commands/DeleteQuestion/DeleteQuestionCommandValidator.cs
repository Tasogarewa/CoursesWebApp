using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandValidator:AbstractValidator<DeleteQuestionCommand>
    {
        public DeleteQuestionCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
