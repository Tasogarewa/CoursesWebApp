using AutoMapper;
using Courses.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;

namespace Tasogarewa.Application.CQRS.UserChats.Queries.GetChats
{
    public class GetChatsQueryHandler : IRequestHandler<GetChatsQuery, ChatListVm>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetChatsQueryHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ChatListVm> Handle(GetChatsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserId);
            if (user == null || request.UserId == Guid.Empty)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }
            else
                return new ChatListVm() { chatDtos = await _mapper.ProjectTo<ChatDto>((IQueryable)user.Chats).ToListAsync() };
        }
    }
}
