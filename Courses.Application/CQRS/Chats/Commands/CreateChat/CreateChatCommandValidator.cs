using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Chats.Commands.CreateChat
{
    public class CreateChatCommandValidator:AbstractValidator<CreateChatCommand>
    {
        public CreateChatCommandValidator()
        {
            RuleFor(createChatCommand => createChatCommand.Users).NotEmpty();
        }
    }
}
