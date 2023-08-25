using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.UpdateChat
{
    public class UpdateChatCommandValidator:AbstractValidator<UpdateChatCommand>
    {
        public UpdateChatCommandValidator() 
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
