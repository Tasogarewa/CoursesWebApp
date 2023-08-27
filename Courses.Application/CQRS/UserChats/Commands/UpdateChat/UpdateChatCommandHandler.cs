using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.UpdateChat
{
    public class UpdateChatCommandHandler : IRequestHandler<UpdateChatCommand, Guid>
    {
        private readonly IChatService _chatService;

        public UpdateChatCommandHandler(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<Guid> Handle(UpdateChatCommand request, CancellationToken cancellationToken)
        {
            return await _chatService.UpdateChatAsync(request);
        }
    }
}
