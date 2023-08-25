using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.CreateAnnouncments
{
    public class CreateAnnouncmentCommandValidator:AbstractValidator<CreateAnnouncmentCommand>
    {
        public CreateAnnouncmentCommandValidator() 
        {
            RuleFor(x => x.MentorId).NotEqual(Guid.Empty);
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).MinimumLength(200).MaximumLength(2000);
            
        }
    }
}
