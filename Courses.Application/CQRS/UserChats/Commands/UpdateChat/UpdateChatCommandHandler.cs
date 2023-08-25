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
        private readonly IRepository<Chat> _chatRepository;

        public UpdateChatCommandHandler(IRepository<Chat> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<Guid> Handle(UpdateChatCommand request, CancellationToken cancellationToken)
        {
            var chat = await _chatRepository.GetAsync(request.Id);
            if (chat == null || request.Id == Guid.Empty)
            {
                throw new NotFoundException(nameof(chat), request.Id);
            }
            else
            {
                chat.Name = request.Name;
               await _chatRepository.Update(chat);
            }
            return chat.Id;
        }
    }
}
