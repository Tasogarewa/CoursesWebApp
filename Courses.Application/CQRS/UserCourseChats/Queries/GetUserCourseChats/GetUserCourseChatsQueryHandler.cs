using AutoMapper;
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

namespace Tasogarewa.Application.CQRS.UserCourseChats.Queries.GetUserCourseChats
{
    public class GetUserCourseChatsQueryHandler : IRequestHandler<GetUserCourseChatsQuery, UserCourseChatListVm>
    {
        private readonly ICourseChatService _courseChatService;

        public GetUserCourseChatsQueryHandler(ICourseChatService courseChatService)
        {
            _courseChatService = courseChatService;
        }

        public async Task<UserCourseChatListVm> Handle(GetUserCourseChatsQuery request, CancellationToken cancellationToken)
        {
            return await _courseChatService.GetUserCourseChatsAsync(request);
        }
    }
}
