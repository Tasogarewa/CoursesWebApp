using AutoMapper;
using Courses.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common.Exceptions;
using Tasogarewa.Application.Interfaces;

namespace Tasogarewa.Application.CQRS.UserChats.Queries.GetChat
{
    public  class GetChatQueryHandler:IRequestHandler<GetChatQuery,ChatVm>
    {
        private readonly IRepository<Chat> _chatRepository;
        private readonly IMapper _mapper;

        public GetChatQueryHandler(IRepository<Chat> chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<ChatVm> Handle(GetChatQuery request, CancellationToken cancellationToken)
        {
            var chat = await _chatRepository.GetAsync(request.Id);
            if(chat == null||request.Id==Guid.Empty) 
            {
                throw new NotFoundException(nameof(chat),request.Id);
            }
            else
                return _mapper.Map<ChatVm>(chat);
        }
    }
}
