using AutoMapper;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.Chats.Queries.GetChat
{
    public class GetChatQueryHandler : IRequestHandler<GetChatQuery, ChatVm>
    {
        private readonly IRepository<Chat> ChatRepository;
        private readonly IMapper Mapper;

        public GetChatQueryHandler(IMapper mapper,Repository<Chat> repository)
        {
            ChatRepository = repository;
            Mapper = mapper;
        }

        public async Task<ChatVm> Handle(GetChatQuery request, CancellationToken cancellationToken)
        {
            var chat = await ChatRepository.GetAsync(request.Id);
            if(chat==null)
            {
                throw new NotFoundException(nameof(chat),request.Id);
            }
            else {
                return Mapper.Map<ChatVm>(chat);
            }
        }
    }
}
