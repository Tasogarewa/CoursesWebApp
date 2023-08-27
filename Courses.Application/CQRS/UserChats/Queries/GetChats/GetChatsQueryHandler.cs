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
        private readonly IChatService _chatService;

        public GetChatsQueryHandler(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<ChatListVm> Handle(GetChatsQuery request, CancellationToken cancellationToken)
        {

            return await _chatService.GetChatsAsync(request);
        }
    }
}
