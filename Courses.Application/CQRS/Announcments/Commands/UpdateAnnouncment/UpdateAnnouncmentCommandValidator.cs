using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.UpdateAnnouncments
{
    public class UpdateAnnouncmentCommandValidator:AbstractValidator<UpdateAnnouncmentCommand>
    {
        public UpdateAnnouncmentCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x=>x.CourseId).NotEqual(Guid.Empty);
            RuleFor(x=>x.MentorId).NotEqual(Guid.Empty);
            RuleFor(x => x.Text).MinimumLength(200).MaximumLength(2000);
        }
    }
}
