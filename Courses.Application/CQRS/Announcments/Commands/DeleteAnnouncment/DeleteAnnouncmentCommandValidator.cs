using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Announcments.Commands.DeleteAnnouncments
{
    public class DeleteAnnouncmentCommandValidator:AbstractValidator<DeleteAnnouncmentCommand>
    {
        public DeleteAnnouncmentCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x=>x.Id).NotEqual(Guid.Empty);
        }
    }
}
