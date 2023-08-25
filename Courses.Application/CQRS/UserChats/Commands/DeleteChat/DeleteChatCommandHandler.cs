using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.DeleteChat
{
    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand, Unit>
    {
        private readonly IRepository<Chat> _chatRepository;

        public DeleteChatCommandHandler(IRepository<Chat> chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<Unit> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var chat = await _chatRepository.GetAsync(request.Id);
            if (chat == null||request.Id==Guid.Empty)
            {
                throw new NotFoundException(nameof(chat), request.Id);
            }
            else
              await  _chatRepository.Delete(chat);
            return Unit.Value;
        }
    }
}
