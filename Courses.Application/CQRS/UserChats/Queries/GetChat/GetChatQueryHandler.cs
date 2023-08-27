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
        private readonly IChatService _chatService;

        public GetChatQueryHandler(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<ChatVm> Handle(GetChatQuery request, CancellationToken cancellationToken)
        {
            return await _chatService.GetChatAsync(request);
        }
    }
}
