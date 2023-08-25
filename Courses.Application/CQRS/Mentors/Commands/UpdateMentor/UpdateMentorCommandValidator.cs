using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Mentors.Commands.UpdateMentor
{
    public class UpdateMentorCommandValidator:AbstractValidator<UpdateMentorCommand>
    {
        public UpdateMentorCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Description).MaximumLength(2000);
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x=>x.Surname).MaximumLength(50);
          
        }
    }
}
