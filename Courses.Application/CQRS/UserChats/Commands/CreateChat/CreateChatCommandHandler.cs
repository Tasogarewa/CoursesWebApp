using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserChats.Commands.CreateChat
{
    public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, Guid>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<Chat> _chatRepository;

        public CreateChatCommandHandler(IRepository<AppUser> userRepository, IRepository<Chat> chatRepository)
        {
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }

        public async Task<Guid> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            var chat = await _chatRepository.Create(new Chat() { Name = request.Name, Users = new List<AppUser>() { user, request.User } });
            return chat.Id;
        }
    }
}
