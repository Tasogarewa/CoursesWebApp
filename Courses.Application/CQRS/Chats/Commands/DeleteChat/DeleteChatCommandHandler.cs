using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Chats.Commands.DeleteChat
{
    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand,Unit>
    {
        private readonly IRepository<Chat> ChatRepository;
        public DeleteChatCommandHandler(IRepository<Chat> repository) 
        {
            ChatRepository = repository;
        }
        public async Task<Unit> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var chat = await ChatRepository.GetAsync(request.Id);
            if (chat == null||chat.Id!=request.Id||request.UserId!=Guid.Empty)
            {
                throw new NotFoundException(nameof(chat), request.Id);
            }
            else
              ChatRepository.Delete(chat);
            return Unit.Value;
        }
    }
}
