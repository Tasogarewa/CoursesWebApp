using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Chats.Commands.CreateChat
{
    public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, Guid>
    {
        private readonly IRepository<Chat> ChatRepository;
        public CreateChatCommandHandler(Repository<Chat> repository)
        {
            ChatRepository = repository;
        }

        public async Task<Guid> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
           var chat = await ChatRepository.Create(new Chat() { Id = request.Id, AppUsers = request.Users});
            return chat.Id;
         
        }
    }
}
