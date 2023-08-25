using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.CreateChat
{
    public class CreateChatCommandValidator:AbstractValidator<CreateChatCommand>
    {
        public CreateChatCommandValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.User).NotNull();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
