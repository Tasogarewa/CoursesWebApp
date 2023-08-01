using AutoMapper;
using AutoMapper.QueryableExtensions;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Tasogarewa.Application.Common.Exceptions;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChats
{
    public class GetChatsQueryHandler : IRequestHandler<GetChatsQuery, ChatsListVm>
    {
        private readonly IRepository<Chat> ChatsRepository;
        private readonly IMapper Mapper;

        public GetChatsQueryHandler(IMapper mapper,Repository<Chat> repository)
        {
            ChatsRepository = repository;
            Mapper = mapper;
        }

        public async Task<ChatsListVm> Handle(GetChatsQuery request, CancellationToken cancellationToken)
        {
            var chats = await ChatsRepository.GetAllAsync();
            if (chats == null)
            {
                throw new NotFoundException(nameof(chats), request.UserId);
            }
            return new ChatsListVm { ChatsList = await Mapper.ProjectTo<ChatsDto>((IQueryable)chats.Where(x=>x.AppUsers.FirstOrDefault(x=>x.Id==request.UserId)).ToListAsync())};
        }

    }
}
