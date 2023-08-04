using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.CQRS.Chats.Commands.DeleteChat
{
    public class DeleteChatCommandValidator:AbstractValidator<DeleteChatCommand>
    {
        public DeleteChatCommandValidator()
        {
            RuleFor(updateChatCommand => updateChatCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateChatCommand => updateChatCommand.UserId).NotEqual(Guid.Empty);
        }

    }
}
