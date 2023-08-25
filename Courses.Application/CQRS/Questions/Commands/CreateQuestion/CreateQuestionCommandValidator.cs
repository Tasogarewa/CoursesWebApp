using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator:AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator() 
        {
            RuleFor(x => x.FirstAnswer).NotEmpty().MaximumLength(500);
            RuleFor(x => x.SecondAnswer).NotEmpty().MaximumLength(500);
            RuleFor(x => x.ThirdAnswer).NotEmpty().MaximumLength(500);
            RuleFor(x => x.FourthAnswer).NotEmpty().MaximumLength(500);
            RuleFor(x => x.CorrectAnswer).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.TestId).NotEqual(Guid.Empty);


        }
    }
}
